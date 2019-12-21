using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CartilhaMagica.Entities
{
    public class SyllablesLesson : IEnumerable<Lesson>
    {

        private readonly List<Lesson> lessons;

        public SyllablesLesson()
        {
            lessons = new List<Lesson>();
        }

        public IEnumerator<Lesson> GetEnumerator()
        {
            return lessons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lessons.GetEnumerator();
        }

        public SyllablesLesson Add(Lesson l)
        {
            lessons.Add(l);
            return this;
        }

        public Lesson Remove(string syllable)
        {
            var l = lessons.FirstOrDefault(i => StringComparer.OrdinalIgnoreCase.Equals(i.Syllable, syllable));
            if (l != null)
                lessons.Remove(l);
            return l;
        }

        public string[] this[string syllable]
        {
            get
            {
                return lessons?.FirstOrDefault(i => StringComparer.OrdinalIgnoreCase.Equals(syllable, i.Syllable))?.Words;
            }
        }

        public string GetConsonant()
        {
            var syllable = GetSyllables().FirstOrDefault().ToLower();
            return syllable.StartsWith("a") ? syllable : syllable.Replace("a", "");
        }

        public string[] GetSyllables()
        {
            return lessons?.Select(i => i.Syllable)?.OrderBy(i => i)?.ToArray();
        }

        public string[] GetWords(string syllable)
        {
            return this[syllable];
        }

        public string[] GetAllWords()
        {
            List<string> words = new List<string>();
            foreach(var i in lessons)
            {
                if (i?.Words?.Any() == true)
                    words.AddRange(i.Words);
            }
            return words.ToArray();
        }

        public override string ToString()
        {
            return string.Join(",", GetSyllables() ?? new string[0]);
        }

        public string ToXml(int index = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<lessons index=\"{index}\">");
            foreach(var l in lessons)
            {
                sb.AppendLine(l.ToXml());
            }
            sb.AppendLine("</lessons>");
            return sb.ToString();
        }
    }
}
