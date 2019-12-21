using CartilhaMagica.Manager;
using CartilhaMagica.Properties;
using System;
using System.Drawing;
using System.Threading;
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
        private static WordsForm Instance { get; set; }

        public WordsForm()
        {
            InitializeComponent();
            wm = new WordManager();
            this.MouseClick += Form_MouseClick;
            this.Load += WordsForm_Load;
            regularBackground = lblWrite.BackColor;
        }

        public static WordsForm GetForm()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new WordsForm();
            }
            return Instance;
        }

        private void WordsForm_Load(object sender, EventArgs e)
        {
            var data = wm.GetCurrentWordState(out int idx, out byte lvl);
            if (data != null && idx > 0 && idx < data.Length - 1 /*&& MessageBox.Show("Deseja continuar de onde parou?", "Atenção",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes*/)
            {
                loadLevel((Level)lvl, data, idx);
            }
            else
                loadLevel(Level.Easy);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool r = ControlManager.HandleKeyboard(ref msg, keyData, lblWrite.Text, txt => lblWrite.Text = txt, (x, y) => ctxMenu.Show(this, x, y), Close);
            return r || base.ProcessCmdKey(ref msg, keyData);
        }


        private void loadLevel(Level l, string[] data = null, int idx = 0)
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
                loadWords(l, data, idx);
                speak("Vamos escrever a palavra: " + words[idx]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu uma falha ao carregar o nível!\r\nVerifique se há palavras cadastradas o suficiente.\r\nPara cadastrar mais palavras acesse a opção [Configurar Palavras]\r\n" +
                    ex, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void speak(string text)
        {

            SpeechManager.SpeakAsync(text);
        }

        private void speakCurrentWord()
        {
            speak(words[currentWordIndex]);
        }

        private void loadWords(Level l, string[] data = null, int idx = 0)
        {
            currentWordIndex = idx;
            lblCountWord.Text = (idx + 1).ToString();
            words = data ?? wm.GetWords(l, randomize: true, exclusive: true);
            applyWord();
            lblWrite.Text = "";

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
                Application.DoEvents();
                Thread.Sleep(500);
            }
            return result;
        }

        private void congrats()
        {
            /*pbxPencil.BackColor = pnlWrite.BackColor = */
            lblWrite.BackColor = Color.GreenYellow;
        }

        private void regularWrite()
        {
            /*pbxPencil.BackColor = pnlWrite.BackColor = */
            lblWrite.BackColor = regularBackground;
        }

        private void next()
        {
            if (currentWordIndex < ((words?.Length ?? 0) - 1))
            {
                currentWordIndex++;
                applyWord();
                lblCountWord.Text = (currentWordIndex + 1).ToString();
                speakCurrentWord();
                wm.SaveCurrentWordState(words, currentWordIndex, (byte)currentLevel);
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
            //doCrossThread(this, () =>
            //{
            adjustPencilPosition();
            Application.DoEvents();
            if (checkWord())
            {
                congrats();
                next();
            }
            else regularWrite();
            //});
        }

        private void adjustPencilPosition()
        {

            this.pbxPencil.AdjustPencilPosition(lblWrite);
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
            wm.SaveCurrentWordState(words, currentWordIndex, (byte)Level.Easy);
        }

        private void mnuLevelAverage_Click(object sender, EventArgs e)
        {
            loadLevel(Level.Average);
            wm.SaveCurrentWordState(words, currentWordIndex, (byte)Level.Average);
        }

        private void mnuLevelHard_Click(object sender, EventArgs e)
        {
            loadLevel(Level.Hard);
            wm.SaveCurrentWordState(words, currentWordIndex, (byte)Level.Hard);
        }

        private void mnuSyllable_Click(object sender, EventArgs e)
        {
            var form = SyllableForm.GetForm();
            form.Left = this.Left;
            form.Top = this.Top;
            form.WindowState = this.WindowState;
            form.Show();
            this.Hide();
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

        private void pbxNext_Click(object sender, EventArgs e)
        {
            next();
        }
    }


}
