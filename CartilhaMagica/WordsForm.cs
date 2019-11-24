using CartilhaMagica.Manager;
using CartilhaMagica.Properties;
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
    public partial class WordsForm : Form
    {

        private int currentWordIndex;
        private string[] words;
        private Level currentLevel;
        private WordManager wm;
        private Color regularBackground;
        private event Action<string> WriteText;
        private bool canNext;


        public WordsForm()
        {
            InitializeComponent();
            //configPencilCursor();
            wm = new WordManager();
            this.MouseClick += Form_MouseClick;
            this.Load += WordsForm_Load;
            regularBackground = lblWrite.BackColor;
            this.WriteText += WordsForm_WriteText;
        }

        private void WordsForm_WriteText(string obj)
        {

        }

        private void WordsForm_Load(object sender, EventArgs e)
        {
            loadLevel(Level.Easy);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //handleKeyAnimation();

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

            if(keyData == Keys.F1)
            {
                ctxMenu.Show(this, 5, 5);
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData.HasFlag(Keys.Shift) || keyData.HasFlag(Keys.Control))
            {
                if (keyData.HasFlag(Keys.Escape))
                {
                    ctxMenu.Show(this, 5, 5);
                    return true;
                }
                return false;
            }

            if (keyData == Keys.Delete || keyData == Keys.Back)
            {
                if (lblWrite.Text.Length > 0)
                {
                    lblWrite.Text = lblWrite.Text.Substring(0, lblWrite.Text.Length - 1);
                    WriteText?.Invoke(lblWrite.Text);
                    return true;
                }
            }

            int kIdx = (int)keyData;

            if (kIdx >= 65 && kIdx <= 90)
            {
                lblWrite.Text += keyData.ToString().ToLower();
                WriteText?.Invoke(lblWrite.Text);
                return true;
            }

            switch (keyData)
            {
                case Keys.Space:
                    lblWrite.Text += " ";
                    WriteText?.Invoke(lblWrite.Text);
                    return true;

                case Keys.Oem1:
                    lblWrite.Text += "ç";
                    WriteText?.Invoke(lblWrite.Text);
                    return true;

                case Keys.OemMinus:
                case Keys.Subtract:
                    lblWrite.Text += "-";
                    WriteText?.Invoke(lblWrite.Text);
                    return true;
            }


            bool r = base.ProcessCmdKey(ref msg, keyData);
            return r;
        }


        private void loadLevel(Level l)
        {
            try
            {
                switch (l)
                {
                    case Level.Easy:
                        pbxMedal.Image = Resources.bronze_medal;
                        break;
                    case Level.Average:
                        pbxMedal.Image = Resources.silver_medal;
                        break;
                    case Level.Hard:
                        pbxMedal.Image = Resources.gold_medal;
                        break;
                    default:
                        pbxMedal.Image = Resources.mouth;
                        pbxMedal.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                }
                currentLevel = l;
                loadWords(l);
                speak("Vamos escrever a palavra: " + words[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu uma falha ao carregar o nível!\r\nVerifique se há palavras cadastradas o suficiente.\r\nPara cadastrar mais palavras acesse a opção [Configurar Palavras]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void waitSpeak()
        {
            canNext = false;
            Task.Run(() => {
                Thread.Sleep(1000);
                canNext = true;
            });
        }

        private void speak(string text)
        {
            
                SpeechManager.SpeakAsync(text);
        }

        private void speakCurrentWord()
        {
            speak(words[currentWordIndex]);
        }

        private void loadWords(Level l)
        {
            currentWordIndex = 0;
            lblCountWord.Text = "1";
            words = wm.GetWords(l, randomize: true, exclusive: true);
            applyWord();
            lblWrite.Text = "";
            waitSpeak();
        }

        private void applyWord()
        {
            string word = lblUpperLetter.Text = lblUpperHandwrite.Text = words[currentWordIndex].ToUpper();
            lblLowerLetter.Text = lblLowerHandwrite.Text = words[currentWordIndex].ToLower();
            lblWrite.Text = "";
        }

        private bool checkWord()
        {
            string s1 = WordManager.RemoveDiacritics(lblWrite.Text.Trim());
            string s2 = WordManager.RemoveDiacritics(lblUpperLetter.Text);
            bool result = StringComparer.OrdinalIgnoreCase.Equals(s1, s2);
            if (result)
            {
                lblWrite.Text = lblUpperLetter.Text.ToLower();
            }
            return result;
        }

        private void congrats()
        {
            /*pbxPencil.BackColor = pnlWrite.BackColor = */lblWrite.BackColor = Color.GreenYellow;
        }

        private void regularWrite()
        {
            /*pbxPencil.BackColor = pnlWrite.BackColor = */lblWrite.BackColor = regularBackground;
        }

        private void next()
        {
            if (!canNext) return;
            waitSpeak();

            if (currentWordIndex < ((words?.Length ?? 0) - 1))
            {
                currentWordIndex++;
                applyWord();
                lblCountWord.Text = (currentWordIndex + 1).ToString();
                speakCurrentWord();
            }
            else
            {
                SpeechManager.Speak("Parabéns!");
                switch (currentLevel)
                {
                    case Level.Easy:
                        loadLevel(Level.Average);
                        break;
                    case Level.Average:
                        loadLevel(Level.Hard);
                        break;

                }
            }
            lblWrite.Text = "";
        }



        private void Form_MouseClick(object sender, MouseEventArgs e)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblWrite_SizeChanged(object sender, EventArgs e)
        {

            doCrossThread(this, () =>
            {

                adjustPencilPosition();
                Application.DoEvents();

                if (checkWord())
                {
                    congrats();
                    Application.DoEvents();
                    Thread.Sleep(1000);
                    next();

                }
                else regularWrite();
            });
        }

        private void adjustPencilPosition()
        {
            /*this.pbxPencil.Left = lblWrite.Left + lblWrite.Width + 2;
            //if (lblWrite.Font.Size <= 40)
            this.pbxPencil.Top = lblWrite.Top - Convert.ToInt32(pbxPencil.Height * .75);*/
            //else
            //     this.pbxPencil.Top = lblWrite.Top;

            this.pbxPencil.AdjustPencilPosition(lblWrite);
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


        private void pbxPrevious_Click(object sender, EventArgs e)
        {
            if (currentWordIndex - 1 >= 0)
            {
                currentWordIndex -= 2;
                next();
            }
        }

        private void pbxMouth_Click(object sender, EventArgs e)
        {
            speakCurrentWord();
        }

        private void changeFont(Font baseFont)
        {
            Font f = new Font(baseFont.FontFamily, lblWrite.Font.Size, FontStyle.Regular);
            this.lblWrite.Font = f;
        }

        private void lblUpperLetter_Click(object sender, EventArgs e)
        {
            changeFont(lblUpperLetter.Font);
            speakCurrentWord();
        }

        private void lblUpperHandwrite_Click(object sender, EventArgs e)
        {
            changeFont(lblUpperHandwrite.Font);
            speakCurrentWord();
        }

        private void lblLowerLetter_Click(object sender, EventArgs e)
        {
            changeFont(lblLowerLetter.Font);
            speakCurrentWord();
        }

        private void lblLowerHandwrite_Click(object sender, EventArgs e)
        {
            changeFont(lblLowerHandwrite.Font);
            speakCurrentWord();
        }

        private void pbxMedal_Click(object sender, EventArgs e)
        {
            string text = "";
            switch (currentLevel)
            {
                case Level.Easy: text = "nível fácil"; break;
                case Level.Average: text = "nível médio"; break;
                case Level.Hard: text = "nível máximo"; break;
            }
            if (!string.IsNullOrEmpty(text))
                speak(text);
        }

        private void lblCountWord_Click(object sender, EventArgs e)
        {
            string text = "Você está na " + (currentWordIndex + 1) + "a palavra do total de " + words.Length + " palavras. Continue para avançar para o próximo nível!";
            speak(text);
        }

        private void pbxUpper_Click(object sender, EventArgs e)
        {
            speak("As palavras nessa linha estão escritas em letra Maiúscula");
        }

        private void pbxLower_Click(object sender, EventArgs e)
        {
            speak("As palavras nessa linha estão escritas em letra Minúscula");
        }

        private void mnuLevelEasy_Click(object sender, EventArgs e)
        {
            loadLevel(Level.Easy);
        }

        private void mnuLevelAverage_Click(object sender, EventArgs e)
        {
            loadLevel(Level.Average);
        }

        private void mnuLevelHard_Click(object sender, EventArgs e)
        {
            loadLevel(Level.Hard);
        }

        private void mnuSyllable_Click(object sender, EventArgs e)
        {
            new SyllableForm() { WindowState = this.WindowState }.ShowDialog();
            loadLevel(currentLevel);

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuConfigWords_Click(object sender, EventArgs e)
        {
            new DataWordsForm().ShowDialog();
            loadLevel(currentLevel);
        }

        private void WordsForm_SizeChanged(object sender, EventArgs e)
        {
            this.ToCenter(pnlUpperLetter, pnlUpperHandWrite);
            this.ToCenter(pnlLowerLetter, pnlLowerHandwrite);
            if (WindowState == FormWindowState.Maximized)
            {
                if (ControlManager.CompareApproximateValue(lblWrite.Font.Size, 80)) return;
                lblWrite.Font = new Font(lblWrite.Font.FontFamily, 80, FontStyle.Regular);
            }
            else
            {
                if (ControlManager.CompareApproximateValue(lblWrite.Font.Size, 36)) return;
                lblWrite.Font = new Font(lblWrite.Font.FontFamily, 36, FontStyle.Regular);
            }
        }

        private void mnuInformation_Click(object sender, EventArgs e)
        {
            new InformationForm().ShowDialog();
        }

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Desejar restaurar o aplicativo para as configurações originais?", "Atenção",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;
            string msg, title;
            MessageBoxIcon ico;
            try
            {
                Manager.Settings.RestoreSettings();
                msg = "Restauração efetuada!\r\nO aplpicativo deve ser iniciado novamente";
                title = "Sucesso";
                ico = MessageBoxIcon.Information;
                
            }
            catch
            {
                Manager.Settings.RemoveSettings();
                msg = "Ocorreu uma falha!\r\nO aplicativo deve ser iniciado novamente";
                title = "Erro";
                ico = MessageBoxIcon.Error;
            }
            MessageBox.Show(msg, title, MessageBoxButtons.OK, ico);
            Application.Exit();
        }
    }


}
