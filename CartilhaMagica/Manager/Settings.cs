using CartilhaMagica.Properties;
using System.IO;
using System.Xml.Linq;

namespace CartilhaMagica.Manager
{
    public abstract class Settings
    {
        protected static XElement xmlConfig;
        static Settings()
        {
            xmlConfig = null;
            var settingsPath = GetTempPath() + "\\cartilha.settings.dat";
            if (!File.Exists(settingsPath))
            {
                var contentFile = Resources.settings;
                File.WriteAllBytes(settingsPath, contentFile);
            }
            var content = File.ReadAllText(settingsPath);
            xmlConfig = XElement.Parse(content);
        }


        public static void RestoreSettings()
        {
            var settingsPath = GetTempPath() + "\\cartilha.settings.dat";
            var contentFile = Resources.settings;
            File.WriteAllBytes(settingsPath, contentFile);
            var content = File.ReadAllText(settingsPath);
            xmlConfig = XElement.Parse(content);
        }

        public static void RemoveSettings()
        {
            var settingsPath = GetTempPath() + "\\cartilha.settings.dat";
            File.Delete(settingsPath);
        }


        public static string GetAppPath()
        {
            var appPath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return appPath.Directory.FullName;
        }

        public static string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public static void SaveXmlConfig()
        {
            var settingsPath = GetTempPath() + "\\cartilha.settings.dat";
            File.WriteAllText(settingsPath, xmlConfig.ToString());
        }

        public static XElement GetXmlConfig()
        {
            return xmlConfig;
        }

        public Settings() { }
    }
}
