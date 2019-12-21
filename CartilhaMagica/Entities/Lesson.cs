using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartilhaMagica.Entities
{
    public class Lesson
    {
        public string Syllable { get; set; }

        public string[] Words { get; set; }


        public override string ToString()
        {
            return $"[{Syllable}]";
        }

        public Lesson() { }

        public Lesson(string syllable, string[] words)
        {
            this.Syllable = syllable;
            this.Words = words;
        }

        public string ToXml()
        {
            return new XElement("lesson", new XAttribute("syllable", Syllable), new XElement("words", new XCData(string.Join(",", Words)))).ToString();
        }
    }
}
