using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartilhaMagica.Manager
{
    public enum Level
    {
        Undefined = 0,
        Easy = 1,
        Average = 2,
        Hard = 3
    }

    public class SyllableSpeakConfig
    {
        public string[] Syllables { get; set; }
        public Action<string> SpeakHandler { get; set; }
        public Action<int> OnBeforeSpeak { get; set; }
        public Action<int, string> OnSpeakSyllable { get; set; }
        public Action OnFinishSpeak { get; set; }
    }

    public class WordManager : Settings
    {
        public WordManager() : base()
        {

        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public string[] GetWords(Level level, bool randomize = true, bool exclusive = false)
        {


            string[] denyWords = new string[0];

            if (exclusive)
            {
                switch (level)
                {
                    case Level.Easy:
                        break;

                    case Level.Average:
                        denyWords = GetWords(Level.Easy, false, false);
                        break;

                    case Level.Hard:
                        denyWords = GetWords(Level.Average, false, false);
                        break;
                }
            }


            if (level == Level.Undefined)
                throw new Exception("nível não suportado! " + level);
            var xmlConfig = GetXmlConfig();
            if (xmlConfig == null)
                throw new Exception("Arquivo de configuração não foi encontrado!");
            string[] words = xmlConfig.Element("words")?.Value?.Split(',');
            if (words == null)
                throw new Exception("Arquivo de configuração não contém palavras!");

            words = applyLevel(level, words);

            words = words.Distinct().ToArray();

            if (denyWords.Any())
                words = words.Where(w => !denyWords.Contains(w)).ToArray();


            if (randomize)
                words = randomizeWords(words);

            return words;

        }

        private string[] randomizeWords(string[] words)
        {
            Random rand = new Random();
            int numOfInts = words.Length;
            var ints = Enumerable.Range(0, numOfInts)
                                         .Select(i => new Tuple<int, int>(rand.Next(numOfInts), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2);
            List<string> randomizedWords = new List<string>();
            foreach (int i in ints)
            {
                randomizedWords.Add(words[i]);
            }
            return randomizedWords.ToArray();
        }

        private string[] applyLevel(Level l, string[] words)
        {
            var xmlConfig = GetXmlConfig();
            int max; bool doubleConsonant, endsWithConsonant;
            var levelConfig = xmlConfig.Element("levels").Elements("level").FirstOrDefault(i => int.Parse(i.Attribute("value").Value) == (int)l);
            if (levelConfig == null)
                throw new Exception("módulo de níveis inexistente ou inadequado");

            max = int.Parse(levelConfig.Attribute("max").Value.Replace('+', '9'));
            doubleConsonant = bool.Parse(levelConfig.Attribute("doubleConsonant").Value);
            endsWithConsonant = bool.Parse(levelConfig.Attribute("endsWithConsonant").Value);

            //max size
            words = words.Where(w => w.Length <= max).ToArray();

            //sem restrições
            if (endsWithConsonant && doubleConsonant)
                return words;

            //não aceita palavra terminada em consoante
            if (!endsWithConsonant)
            {
                Regex rxEndsWithConsonant = new Regex(@"^\w+[áéíóúêôãaeiou]$", RegexOptions.IgnoreCase);
                words = words.Where(w => rxEndsWithConsonant.IsMatch(w)).ToArray();
            }

            //não aceita encontro consonantal
            if (!doubleConsonant)
            {
                Regex rxDoubleConsonant = new Regex(@"[^áéíóúêôãaeiou]{2,}", RegexOptions.IgnoreCase);
                words = words.Where(w => !rxDoubleConsonant.IsMatch(w)).ToArray();
            }

            return words;
        }

        public List<string[]> GetSyllables()
        {
            var xml = GetXmlConfig();

            string[] letters = xml?.Element("syllable")?.Value?.Split(',');
            if (letters == null)
                throw new Exception("sílabas não encontradas");

            string[] vowels = xml?.Element("vowel")?.Value?.Split(',') ?? new string[] { "a", "e", "i", "o", "u" };

            var deny = xml.Element("deny")?.Value?.Split(',') ?? new string[0];

            List<string> list = new List<string>();
            List<string[]> result = new List<string[]>();
            string l0 = "", s = "";
            foreach (var l in letters)
            {
                if (l0 != l)
                {
                    list.Clear();
                    l0 = l;
                }
                foreach (var v in vowels)
                {
                    if (l.Length > 1 && l.Contains("x"))
                    {
                        s = l.Replace("x", v);
                    }
                    else
                    {
                        s = l + v;
                    }
                    if (!deny.Contains(s))
                        list.Add(s);
                }
                result.Add(list.ToArray());
            }

            return result;
        }

        public void SyllableSpeak(SyllableSpeakConfig config)
        {
            if (config?.Syllables == null)
                throw new ArgumentNullException();
            config?.OnBeforeSpeak.Invoke(config.Syllables?.Length ?? 0);
            List<string> syllables = new List<string>();
            string s2 = "";
            foreach (string s in config.Syllables)
            {
                s2 = s.ToLower().Replace("a", "á").Replace("e", "ê").Replace("o", "ó").Replace("i", "í").Replace("u", "ú");
                s2 = s2.Replace("que", "ke").Replace("qui", "ki");
                if (Regex.IsMatch(s, @"[aeiou]$", RegexOptions.IgnoreCase))
                    s2 += "h";
                syllables.Add(s2);
            }
            int index = 0;
            foreach (string s in syllables)
            {
                config?.OnSpeakSyllable?.Invoke(index + 1, config.Syllables[index]);
                config?.SpeakHandler?.Invoke(s);
                index++;
            }
            config?.OnFinishSpeak?.Invoke();

        }

        public void SaveWords(string[] words)
        {
            words = words.OrderBy(w => w).Distinct().ToArray();
            var xmlWord = xmlConfig.Element("words");
            xmlWord.RemoveAll();
            xmlWord.Add(new XCData(string.Join(",", words)));
            SaveXmlConfig();
        }

    }
}
