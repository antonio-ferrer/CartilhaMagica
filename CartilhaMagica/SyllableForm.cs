using CartilhaMagica.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    public partial class SyllableForm : Form
    {

        private List<string[]> AllSyllables;
        private readonly WordManager wm;
        private int currentIndex;
        private bool canCheck = false;
        private static SyllableForm Instance { get;  set; }

        public SyllableForm()
        {
            InitializeComponent();
            this.MouseClick += Form1_MouseClick;
            this.Load += SyllableForm_Load;
            wm = new WordManager();
        }

        public static SyllableForm GetForm()
        {
            if(Instance == null || Instance.IsDisposed)
            {
                Instance = new SyllableForm();
            }
            return Instance;
        }

        private void SyllableForm_Load(object sender, EventArgs e)
        {
            var lastState = wm.GetCurrentSyllableState(out int idx);

            if (lastState != null && idx > 0 && idx < lastState.Count -1 /*&& 
                MessageBox.Show("Deseja continuar de onde parou?", "Atenção", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes*/)
            {
                AllSyllables = lastState;
                currentIndex = idx;
            }
            else
            {
                AllSyllables = wm.GetSyllables();
                currentIndex = 0;
            }
            
            
            var labels = getAllLabels();
            foreach(var label in labels)
            {
                configLabelClick(label);
            }
            Application.DoEvents();

            if (!SpeechManager.Enabled)
                start();
            else
                 Task.Run(()=>this.Invoke(new Action( start)));
                
            
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
            wm.SaveCurrentSyllableState(AllSyllables, currentIndex);
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
            bool r = ControlManager.HandleKeyboard(ref msg, keyData, lblWrite.Text, txt => lblWrite.Text = txt, (x, y) => ctxMenu.Show(this, x, y), BackToPreviousForm);
            return r || base.ProcessCmdKey(ref msg, keyData);
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
                    if(currentIndex > AllSyllables.Count - 1)
                    {
                        currentIndex = 0;
                    }
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
            BackToPreviousForm();
        }

        private void BackToPreviousForm()
        {
            var form = WordsForm.GetForm();
            form.Left = this.Left;
            form.Top = this.Top;
            form.WindowState = this.WindowState;
            form.Show();
            this.Hide();
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

        private void mnuRestart_Click(object sender, EventArgs e)
        {
            AllSyllables = wm.GetSyllables();
            currentIndex = 0;
            start();
        }

        private void SyllableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }


}
