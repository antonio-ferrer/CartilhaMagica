using CartilhaMagica.Entities;
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

    public enum CurrentItemType
    {
        Words,
        Syllables
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
            string[] words = xmlConfig.Element("words")?.Value?.Split(',')?.Select(w => w.ToLower())?.ToArray();
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
            return randomize(words);
        }

        private T[] randomize<T>(T[] collection)
        {
            Random rand = new Random();
            int numOfInts = collection.Length;
            var ints = Enumerable.Range(0, numOfInts)
                                         .Select(i => new Tuple<int, int>(rand.Next(numOfInts), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2);
            List<T> randomized = new List<T>();
            foreach (int i in ints)
            {
                randomized.Add(collection[i]);
            }
            return randomized.ToArray();
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
                Regex rxEndsWithVowel = GetRxEndsWithVowel();
                words = words.Where(w => rxEndsWithVowel.IsMatch(w)).ToArray();
            }

            //não aceita encontro consonantal
            if (!doubleConsonant)
            {
                Regex rxDoubleConsonant = new Regex($@"[^{GetVowelRegexList()}]{{2,}}", RegexOptions.IgnoreCase);
                words = words.Where(w => !rxDoubleConsonant.IsMatch(w)).ToArray();
            }

            return words;
        }

        private Regex GetRxEndsWithVowel()
        {
            return new Regex($@"^\w+[{GetVowelRegexList()}]$", RegexOptions.IgnoreCase);
        }

        private string GetVowelRegexList()
        {
            return "áéíóúâêôõãaeiou";
        }

        public List<string[]> GetSyllables(params string[] letters)
        {
            var xml = GetXmlConfig();

            string[] allLetters = xml?.Element("syllable")?.Value?.Split(',')?.Select(l => l.ToLower())?.ToArray();
            if (allLetters == null)
                throw new Exception("sílabas não encontradas");
            if (letters?.Any() == true)
            {
                letters = allLetters.Where(l => letters.Contains(l))?.ToArray();
            }
            else
            {
                letters = allLetters;
            }

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

        /// <summary>
        /// Retorna um conjunto de lições. 
        /// </summary>
        /// <param name="letters">consoantes que serão usadas para gerar as sílabas e por sua vez as palavras</param>
        /// <param name="randomize">indica para embaralhar a sequencia, funciona apenas quando "letters" é nulo</param>
        /// <param name="maxLessons">indica o número máximo de lições. Funciona quando o parametro "letters" é nulo</param>
        /// <param name="maxWordsPerLesson">número máximo de lições que devem ser retornadas. Só funciona quando o parametro "letters" é nulo</param>
        /// <returns>conjunto de lições</returns>
        public List<SyllablesLesson> GetLessons(string[] letters = null, bool randomize = true, ushort maxLessons = 5, byte maxWordsPerLesson = 5)
        {
            //wm.GetLessons(consonants.Select(c=>(c == "q")?"qu":c).ToArray()); //hack: não se usa q sem u... meu querido
            var syllables = GetSyllables(letters ?? new string[0]).Where(i => GetRxEndsWithVowel().IsMatch(i.First())).ToArray();
            if (letters?.Any() == true)
                maxLessons = (ushort)letters.Count();

            Regex rxWord = new Regex(string.Join("|", letters ?? new string[0]), RegexOptions.IgnoreCase);
            var allWords = GetWords(Level.Hard, false, false).Where(w => letters == null || rxWord.IsMatch(w))?.ToArray();
            var hackMaxLesson = letters != null ? 0 : 5;
            if (letters == null && randomize)
            {
                syllables = this.randomize(syllables);
            }

            if (letters == null && maxLessons > 0)
            {
                syllables = syllables.Take(maxLessons + hackMaxLesson).ToArray();
            }

            List<SyllablesLesson> lessons = new List<SyllablesLesson>();

            foreach (var i in syllables)
            {
                SyllablesLesson sl = new SyllablesLesson();
                foreach (var j in i)
                {
                    //h hack

                    var words = allWords?.Where(w => RemoveAccents(w).StartsWith(j))?.ToArray();
                    if (words.Any() != true && !Regex.IsMatch(j, $"^h[{GetVowelRegexList()}]$", RegexOptions.IgnoreCase))
                    {
                        Regex rxSyllable = new Regex($@"[{GetVowelRegexList()}sn]{j}", RegexOptions.IgnoreCase);
                        words = allWords?.Where(w => rxSyllable.IsMatch( RemoveAccents(w)))?.ToArray();
                    }
                    bool hasWords = false;
                    if (maxWordsPerLesson > 0 && (hasWords = words?.Any() == true))
                        words = words?.Take(maxWordsPerLesson)?.ToArray();
                    //Corrigir match de "tra" e "ra"
                    Lesson l = new Lesson();
                    l.Syllable = j;
                    if (hasWords)
                        l.Words = words.ToArray();
                    ;
                    sl.Add(l);
                }
                if (sl.GetAllWords().Any())
                    lessons.Add(sl);
            }


            return lessons.Take(maxLessons).ToList();
        }

        private string RemoveAccents(string s)
        {
            s = Regex.Replace(s, "[áâã]", "a");
            s = Regex.Replace(s, "[éê]", "e");
            s = Regex.Replace(s, "[íï]", "i");
            s = Regex.Replace(s, "[óôõ]", "o");
            s = Regex.Replace(s, "[úü]", "u");
            return s;
        }

       /* private string GetVowelAccent(string syllable)
        {

            switch (syllable.ToLower())
            {
                case "a": return "aáãâ";
                case "e": return "eéê";
                case "i":return "ií";
                case "o": return "oóõô";
                case "u": return "uú";
                default: return syllable;
            }
        }*/

        public void SyllableSpeak(SyllableSpeakConfig config)
        {
            if (config?.Syllables == null)
                throw new ArgumentNullException();
            config?.OnBeforeSpeak.Invoke(config.Syllables?.Length ?? 0);
            List<string> syllables = new List<string>();
            string s2 = "";
            foreach (string s in config.Syllables)//tratamento para sílabas
            {
                if (Regex.IsMatch(s, @"[aeiou]$", RegexOptions.IgnoreCase))
                    s2 = s + "h";
                else
                    s2 = s;
                s2 = s2.Replace("que", "ke").Replace("qui", "ki");
                s2 = s2.ToLower().Replace("a", "á").Replace("e", "ê").Replace("o", "ó").Replace("i", "í").Replace("u", "ú");
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


        public void SaveCurrentSyllableState(List<string[]> data, int index)
        {
            var xmlCurrentState = Settings.xmlConfig.Element("current-state");
            if (xmlCurrentState == null)
            {
                xmlCurrentState = new XElement("current-state");
                xmlConfig.Add(xmlCurrentState);
            }
            var xIndex = new XAttribute("index", index);
            StringBuilder sb = new StringBuilder();
            foreach (var syllables in data)
            {
                sb.Append(string.Join(",", syllables)).Append("|");
            }
            sb.Length--;
            var xData = new XCData(sb.ToString());

            xmlCurrentState.Element("syllables")?.Remove();
            var xmlSyllables = new XElement("syllables", xIndex, xData);
            xmlCurrentState.Add(xmlSyllables);

            SaveXmlConfig();
        }

        public void SaveCurrentWordState(string[] data, int index, byte? level = 0)
        {
            var xmlCurrentState = Settings.xmlConfig.Element("current-state");
            if (xmlCurrentState == null)
            {
                xmlCurrentState = new XElement("current-state");
                xmlConfig.Add(xmlCurrentState);
            }
            var xIndex = new XAttribute("index", index);
            var xData = new XCData(string.Join(",", data));

            xmlCurrentState.Element("words")?.Remove();
            var xmlWords = new XElement("words", xIndex, new XAttribute("level", level), xData);
            xmlCurrentState.Add(xmlWords);
            SaveXmlConfig();
        }

        /*
             <current-lesson>
    <words index="0" level="0">
      
    </words>
    <syllables index="0">
      
    </syllables>
  </current-lesson>
             */
        public string[] GetCurrentWordState(out int index, out byte level)
        {
            index = -1;
            level = 0;
            var xmlCurrentLesson = Settings.xmlConfig.Element("current-state");
            XElement xmlWords;
            if (xmlCurrentLesson == null || (xmlWords = xmlCurrentLesson.Element("words")) == null)
                return null;
            index = int.Parse(xmlWords.Attribute("index").Value);
            level = byte.Parse(xmlWords.Attribute("level").Value);
            return xmlWords.Value.Split(',');
        }

        public List<string[]> GetCurrentSyllableState(out int index)
        {
            index = -1;
            var xmlCurrentLesson = Settings.xmlConfig.Element("current-state");
            XElement xmlSyllables;
            if (xmlCurrentLesson == null || (xmlSyllables = xmlCurrentLesson.Element("syllables")) == null)
                return null;
            index = int.Parse(xmlSyllables.Attribute("index").Value);
            var content = xmlSyllables.Value.Split('|');
            List<string[]> list = new List<string[]>(content.Length);
            foreach (var syllables in content)
                list.Add(syllables.Split(','));
            return list;
        }

    }
}
