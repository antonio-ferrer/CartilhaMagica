using CartilhaMagica.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SetupManager.Initialize();
            var checkInformation = SetupManager.IsFirstUse();

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form f = null;
            if (checkInformation)
            {
                f = new InformationForm();
            }
            else
            {
                f =  WordsForm.GetForm();
            }

            Application.Run(f);//new CreateLessonForm());
        }
    }
}
