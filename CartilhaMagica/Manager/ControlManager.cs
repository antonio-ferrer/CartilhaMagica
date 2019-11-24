using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
