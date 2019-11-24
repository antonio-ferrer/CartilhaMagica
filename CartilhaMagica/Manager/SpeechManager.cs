using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartilhaMagica.Manager
{



    public class SpeechManager : Settings
    {

        private static System.Speech.Synthesis.SpeechSynthesizer speaker;
        private static VoiceInfo[] voices;

        public static CultureInfo Culture { get; private set; }
        public static int Rate { get => speaker.Rate; set => speaker.Rate = value; }

        public static bool Enabled { get; set; }

        static SpeechManager()
        {
            speaker = null;
            LoadSettings();
        }

        public static bool HasVoice()
        {
            return speaker != null;
        }

        public static void ApplySettings(string voice, int rate, bool enabled = true)
        {
            if (speaker == null) return;
            Enabled = enabled;

            speaker.SelectVoice(voice);
            Rate = rate;

            var xmlVoice = Settings.xmlConfig.Element("voice");
            xmlVoice.Attribute("rate").Value = rate.ToString();
            xmlVoice.Attribute("enabled").Value = enabled.ToString().ToLower();
            xmlVoice.Element("default").RemoveAll();
            xmlVoice.Element("default").Add(new XCData(voice));
            Settings.SaveXmlConfig();
        }


        private static void LoadSettings()
        {
            try
            {
                speaker?.Dispose();
                speaker = new System.Speech.Synthesis.SpeechSynthesizer();

                var xml = Settings.xmlConfig.Element("voice");
                CultureInfo cinfo = new CultureInfo(xml.Attribute("lang")?.Value ?? "pt-BR");
                Culture = cinfo;
                int rate = int.Parse(xml.Attribute("rate")?.Value ?? "0");
                Enabled = bool.Parse(xml.Attribute("enabled")?.Value ?? "true");
                string defaultVoice = xml?.Element("default")?.Value;
                var voice = default(VoiceInfo);
                var voices = GetVoices();
                if (!string.IsNullOrEmpty(defaultVoice))
                {
                    voice = voices.FirstOrDefault(v => v.Name == defaultVoice);
                }
                if (voice == null)
                {
                    voice = voices.FirstOrDefault();
                }
                speaker.SelectVoice(voice.Name);
                speaker.Rate = rate;
                speaker.Volume = 100;
            }
            catch
            {
                speaker = null;
            }
        }

        public static void SetVoice(string voiceName)
        {
            if (speaker == null) return;
            var voice = GetVoices().FirstOrDefault(v => v.Name.ToLower() == voiceName?.ToLower());
            if(voice != null)
            {
                speaker.SelectVoice(voice.Name);
                var xml = Settings.xmlConfig;
                var xmlVoice = xml.Element("voice").Element("default");
                xmlVoice.RemoveAll();
                xmlVoice.Add(new XCData(voice.Name));
                Settings.SaveXmlConfig();
            }
        }

        public static IEnumerable<VoiceInfo> GetVoices()
        {
            if (speaker == null) return null;

            voices = voices ?? speaker.GetInstalledVoices().Where(v => v.VoiceInfo.Culture.Name == Culture.Name)?.Select(v=>v.VoiceInfo)?.ToArray();
            return voices;
        }

        public static VoiceInfo GetVoice()
        {
            if (speaker == null) return null;

            return speaker.Voice;
        }

        public static async void SpeakAsync(string text)
        {
            if (speaker == null || !Enabled) return;

            await Task.Run(()=> speaker.Speak(text));
            
        }

        public static void Speak(string text)
        {
            if (speaker == null || !Enabled) return;

            speaker.Speak(text);
        }

    }
}
