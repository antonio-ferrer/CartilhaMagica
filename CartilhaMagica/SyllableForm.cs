using CartilhaMagica.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    public partial class SyllableForm : Form
    {

        private List<string[]> AllSyllables;
        private WordManager wm;
        private int currentIndex;
        private bool canCheck = false;

        public SyllableForm()
        {
            InitializeComponent();
            this.MouseClick += Form1_MouseClick;
            this.Load += SyllableForm_Load;
        }


        private void doCrossThread(Control ctrl, Action fx)
        {
            Task.Run(() => crossThread(ctrl, fx));
        }

        private void crossThread(Control ctrl, Action fx)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(fx));
            }
            else fx();
        }

        private void SyllableForm_Load(object sender, EventArgs e)
        {
            wm = new WordManager();
            AllSyllables = wm.GetSyllables();
            currentIndex = 0;
            var labels = getAllLabels();
            foreach(var label in labels)
            {
                configLabelClick(label);
            }
            Application.DoEvents();
            Thread.Sleep(100);
            doCrossThread(this, start);
            Application.DoEvents();
        }

        private void configLabelClick(Control label)
        {
            label.Cursor = Cursors.Hand;
            Action<int> empty = (i) => { canCheck = false; };
            label.Click += (o, s) => {
                if (!canCheck) return;
                Manager.SyllableSpeakConfig ssc = new SyllableSpeakConfig
                {
                    Syllables = new string[] { ((Label)label).Text },
                    OnBeforeSpeak = empty,
                    OnFinishSpeak = ()=> { changeFontColor(label, Color.Navy); canCheck = true; },
                    OnSpeakSyllable = (idx,str)=>changeFontColor(label, Color.Red),
                    SpeakHandler = speakHandler
                };
                Manager.WordManager wm = new WordManager();
                wm.SyllableSpeak(ssc);

            };
        }

        private void start()
        {
            lblWrite.Text = "";
            loadSyllable(AllSyllables[currentIndex]);
            pbxBack.Visible = currentIndex > 0;
            pbxNext.Visible = currentIndex + 1 < AllSyllables.Count;
        }

        private void loadSyllable(string[] syllables)
        {
            Manager.SyllableSpeakConfig ssc = new SyllableSpeakConfig
            {
                Syllables = syllables,
                OnBeforeSpeak = onBeforeSpeak,
                OnFinishSpeak = onFinishSpeak,
                OnSpeakSyllable = onSpeakSyllable,
                SpeakHandler = speakHandler
            };
            Manager.WordManager wm = new WordManager();
            wm.SyllableSpeak(ssc);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

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
                ctxMenu.Show(this, 5, 5);
                return true;
            }

            if (keyData.HasFlag(Keys.Shift) || keyData.HasFlag(Keys.Control))
                return false;

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.Delete || keyData == Keys.Back)
            {
                if (lblWrite.Text.Length > 0)
                {
                    lblWrite.Text = lblWrite.Text.Substring(0, lblWrite.Text.Length - 1);
                    return true;
                }
            }

            int kIdx = (int)keyData;

            if (kIdx >= 65 && kIdx <= 90)
            {
                lblWrite.Text += keyData.ToString().ToLower();
                return true;
            }

            switch (keyData)
            {
                case Keys.Space:
                    lblWrite.Text += " ";
                    return true;

                case Keys.Oem1:
                    lblWrite.Text += "ç";
                    return true;
            }


            bool r = base.ProcessCmdKey(ref msg, keyData);
            return r;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys.HasFlag(Keys.Control))
            {

                ctxMenu.Show(this, e.X, e.Y);
            }
        }

        private void mnuConfigVoice_Click(object sender, EventArgs e)
        {
            if (Manager.SpeechManager.HasVoice())
            {
                new VoiceSettingsForm().ShowDialog();
            }
            else
            {
                MessageBox.Show("Não foi encontrado o módulo de voz.\r\nVerifique as configurações no painel de controle!", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void lblWrite_SizeChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.OnWriteSetence(lblWrite.Text);
        }

        private void OnWriteSetence(string text)
        {
            try
            {
                this.pbxPencil.AdjustPencilPosition(lblWrite);

                if (!canCheck) return;
                text = text.ToLower().Trim();
                while (text.Contains("  "))
                    text = text.Replace("  ", " ");
                string syllables = String.Join(" ", AllSyllables[currentIndex]);
                if (syllables == text)
                {
                    SpeechManager.Speak("Correto!");
                    currentIndex++;
                    start();
                }
            }
            catch
            {
                return;
            }
        }

       

        private void onBeforeSpeak(int syllablesCount)
        {
            canCheck = false;
            lblWrite.Text = "";
            pbxMouth.Visible = pbxNext.Visible = pbxBack.Visible = false;
            var allControls = new List<Control>(pnlLetter.Controls.Cast<Control>());
            allControls.AddRange(pnlHandWrite.Controls.Cast<Control>());
            pbxPencil.Visible = false;
            foreach (var c in allControls)
                c.Visible = false;
        }

        private IEnumerable<Control> getAllLabels()
        {
            var allControls = new List<Control>(pnlLetter.Controls.Cast<Control>());
            allControls.AddRange(pnlHandWrite.Controls.Cast<Control>());
            return allControls;
        }

        private void onFinishSpeak()
        {
            canCheck = true;
            var allControls = getAllLabels();
            foreach (var c in allControls)
            {
                changeFontColor(c, Color.Navy);
            }
            pbxNext.Visible = hasNext(); 
            pbxBack.Visible = hasPrevious();
            pbxMouth.Visible = true;
            lblWrite.Text = "";
            pbxPencil.Visible = true;
        }

        private void onSpeakSyllable(int syllableIndex, string syllable)
        {

            var allControls = getAllLabels();

            var labels = allControls.Where(c => c is Label && c.Name.EndsWith(syllableIndex.ToString())).Select(l=>(Label)l);
            var previousLabels = allControls.Where(c => c is Label && c.Name.EndsWith((syllableIndex -1).ToString()))?.Select(l => (Label)l);
            
            if(previousLabels?.Any() == true)
            {
                foreach(var l in previousLabels)
                {
                    changeFontColor(l, Color.Navy);
                }
            }

            foreach (var l in labels)
            {
                l.Visible = true;
                if (l.Name.ToLower().Contains("upper"))
                    l.Text = syllable.ToUpper();
                else
                    l.Text = syllable.ToLower();
                changeFontColor(l, Color.Red);
                Application.DoEvents();
            }

            //lblWrite.Text += syllable + " ";
        }

        private void changeFontColor(Control ctrl, Color c)
        {
            if (Regex.IsMatch(ctrl.Font.Name, @"^times", RegexOptions.IgnoreCase)){
                ctrl.ForeColor = c;
            }
            else
            {
                if(c.Name == Color.Navy.Name)
                {
                    ctrl.ForeColor = Color.DimGray;
                }
                else
                {
                    ctrl.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void adjustPencilPosition()
        {
            this.pbxPencil.Left = lblWrite.Left + lblWrite.Width + 2;
            //if (lblWrite.Font.Size <= 40)
            this.pbxPencil.Top = lblWrite.Top - Convert.ToInt32(pbxPencil.Height * .75);
            //else
            //     this.pbxPencil.Top = lblWrite.Top;
        }



        private void speakHandler(string textToSpeak)
        {
            Manager.SpeechManager.Speak(textToSpeak);
        }

        private void pbxMouth_Click(object sender, EventArgs e)
        {
            string text = lblWrite.Text.Trim();
            start();
            lblWrite.Text = text + " ";
        }

        private void pbxNext_Click(object sender, EventArgs e)
        {
            if (hasNext())
            {
                currentIndex++;
                start();
            }
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            if(hasPrevious())
            {
                currentIndex--;
                start();
            }
        }

        private bool hasNext()
        {
            return currentIndex + 1 < AllSyllables.Count;
        }

        private bool hasPrevious() {
            return currentIndex - 1 >= 0;
        }

        private void mnuWords_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SyllableForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("d");
        }

        private void SyllableForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                if (ControlManager.CompareApproximateValue(lblWrite.Font.Size, 100)) return;
                lblWrite.Font = new Font(lblWrite.Font.FontFamily, 100, FontStyle.Regular);
            }
            else
            {
                if (ControlManager.CompareApproximateValue(lblWrite.Font.Size, 48)) return;
                lblWrite.Font = new Font(lblWrite.Font.FontFamily, 48, FontStyle.Regular);
            }
        }
    }


}
