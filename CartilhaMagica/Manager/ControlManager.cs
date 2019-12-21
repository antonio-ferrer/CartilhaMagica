using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica.Manager
{



    public static class ControlManager
    {

        public static void ToCenter(this Form f, Control ctrlLeft, Control ctrlRight, int leftMargin = 2, int rightMargin = 2)
        {
            int totalSize = f.Width;
            int panelSize = totalSize / 2;

            ctrlLeft.Left = leftMargin;
            ctrlLeft.Width = panelSize - leftMargin;

            ctrlRight.Left = leftMargin + ctrlLeft.Width;
            ctrlRight.Width = panelSize - rightMargin;
        }   
        

        public static void AdjustPencilPosition(this Control ctrlPencil, Label lblWrite)
        {
            ctrlPencil.Left = lblWrite.Left + lblWrite.Width + 2;
            ctrlPencil.Top = lblWrite.Top - Convert.ToInt32(ctrlPencil.Height * .75);
        }

        public static bool CompareApproximateValue(float refValue, float value,  float percent = 5)
        {
            var min = refValue * 1 - (percent / 100);
            var max = refValue * 1 + (percent / 100);
            return value >= min && value <= max;
        }


        public static bool HandleKeyboard(ref Message msg, Keys keyData, string text, Action<string> doWrite, Action<int, int> showMenu, Action close)
        {
            /*Toda essa proteção com que é digitado é porque vendo minha filha usando uma textbox simples, ela "sapateava" em todas as teclas, apertando teclas que não devia. 
            Aproveitando a deixa eu pus um "lápis" com cursor em nossa pseudo textbox*/
            void doWriteText(string txt)
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    Regex rx = new Regex(txt.Last().ToString() + "{3,}$", RegexOptions.IgnoreCase);
                    if (!rx.IsMatch(text))
                        doWrite(txt);
                }
                else
                    doWrite("");
            }

            switch (keyData)
            {
                case Keys.Enter:
                case Keys.CapsLock:
                case Keys.Shift:
                case Keys.ShiftKey:
                case Keys.ControlKey:
                case Keys.Control:
                case Keys.Alt:
                    return false;
            }

            if (keyData == Keys.F1)
            {
                showMenu.Invoke(5, 5);
                return true;
            }

            if (keyData == Keys.Escape)
            {
                close?.Invoke();
                return true;
            }

            if (keyData.HasFlag(Keys.Shift) || keyData.HasFlag(Keys.Control))
            {
                if (keyData.HasFlag(Keys.Escape))
                {
                    showMenu?.Invoke(5, 5);
                    return true;
                }
                return false;
            }

            if (keyData == Keys.Delete || keyData == Keys.Back)
            {
                if (text.Length > 0)
                {
                    text = text.Substring(0, text.Length - 1);
                    doWriteText(text);
                    return true;
                }
            }

            int kIdx = (int)keyData;

            if (kIdx >= 65 && kIdx <= 90)
            {
                text += keyData.ToString().ToLower();
                doWriteText(text);
                return true;
            }

            switch (keyData)
            {
                case Keys.Space:
                    text += " ";
                    doWriteText(text);
                    return true;

                case Keys.Oem1:
                    text += "ç";
                    doWriteText(text);
                    return true;

                case Keys.OemMinus:
                case Keys.Subtract:
                    text += "-";
                    doWriteText(text);
                    return true;
            }

            return false;
        }



    }
}
