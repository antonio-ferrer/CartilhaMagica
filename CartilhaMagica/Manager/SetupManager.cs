using CartilhaMagica.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace CartilhaMagica.Manager
{

    public static class SetupManager
    {
       

        public static bool HasFont()
        {
            
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                FontFamily[] fontFamilies = fontsCollection.Families;
                
                foreach (FontFamily font in fontFamilies)
                {
                    if (Regex.IsMatch(font.Name, "Always In My Heart", RegexOptions.IgnoreCase))
                        return true;
                }
            }

            return false;
        }

        public static void InstallFont()
        {
            if (HasFont()) return;
            var fontName = "Always In My Heart";
            var temp = System.IO.Path.GetTempPath() + $"\\{fontName}.ttf";

           

            File.WriteAllBytes(temp, Resources.Always_In_My_Heart);

            

            Application.ApplicationExit += (o,s)=> {
                File.Delete(temp);
            };

            var p = Process.Start(temp);


            while (!p.HasExited)
            {
                Thread.Sleep(300);
            }

           
        }

        

        public static bool IsFirstUse()
        {
            var xmlSetup = Settings.GetXmlConfig().Element("setup");
            //first-use="true"
            return xmlSetup?.Attribute("first-use")?.Value == "true";
        }

        public static void AgreeTerms()
        {
            var xmlSetup = Settings.GetXmlConfig()?.Element("setup");

            if(xmlSetup != null)
            {
                var firstUse = xmlSetup?.Attribute("first-use");
                if (firstUse != null)
                    firstUse.Value = "false";
                Settings.SaveXmlConfig();
            }
        }


       
    }
}
