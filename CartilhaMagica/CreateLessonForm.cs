using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartilhaMagica.Entities;

namespace CartilhaMagica
{
    public partial class CreateLessonForm : Form
    {
        public List<SyllablesLesson> CurrentLesson { get; private set; }
        public int CurrentLessonIndex { get; private set; }

        public CreateLessonForm()
        {
            InitializeComponent();
        }

        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRandom.Checked)
                tbxConsonants.Text = "";
            mtbLessonCount.Enabled = chkRandom.Checked;


        }

        private void tbxConsonants_TextChanged(object sender, EventArgs e)
        {
            chkRandom.CheckedChanged -= chkRandom_CheckedChanged;
            tbxConsonants.TextChanged -= tbxConsonants_TextChanged;
            Regex rx = new Regex(@"^([a-zç],?\s?)*$");
            bool empty = string.IsNullOrWhiteSpace(tbxConsonants.Text);
            if (!empty && !rx.IsMatch(tbxConsonants.Text))
            {
                tbxConsonants.Text = tbxConsonants.Tag?.ToString() ?? "";
                tbxConsonants.SelectionStart = tbxConsonants.Text.Length;
                tbxConsonants.SelectionLength = 0;
            }

            tbxConsonants.Tag = tbxConsonants.Text;
            mtbLessonCount.Enabled =
            chkRandom.Checked = string.IsNullOrWhiteSpace(tbxConsonants.Text);
            chkRandom.CheckedChanged += chkRandom_CheckedChanged;
            tbxConsonants.TextChanged += tbxConsonants_TextChanged;
        }

        private void tbxConsonants_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.E:
                case Keys.I:
                case Keys.O:
                case Keys.U:
                    e.SuppressKeyPress = true;
                    break;

            }
        }

        private void btnViewExample_Click(object sender, EventArgs e)
        {
            loadExample();
        }


        private string[] getConsonants()
        {
            var data = tbxConsonants.Text.Replace(" ", "").Split(',');
            List<string> result = new List<string>();
            Regex rxValidate = new Regex(@"^[a-zç]{1,2}$", RegexOptions.IgnoreCase);
            foreach (string content in data)
            {
                if (rxValidate.IsMatch(content))
                {
                    char[] chars = content.ToCharArray();
                    if (chars.Length == 1 || chars[0] != chars[1])
                        result.Add(content);
                }
            }
            return result.Distinct().ToArray();
        }

        private void loadExample()
        {
            btnNext.Enabled = btnPrevious.Enabled = false;
            //TODO: tratar H, NH, testar todas as sílabas [a-z]+ combinaçoes
            Manager.WordManager wm = new Manager.WordManager();
            int i;
            cleanLesson();
            byte wordsCount = (byte)((i = int.Parse("0" + mtbWordCount.Text.Trim())) == 0 ? 5 : i);
            if (chkRandom.Checked)
            {
                int lessonCount = (lessonCount = int.Parse("0" + mtbLessonCount.Text.Trim())) == 0 ? 5 : lessonCount;

                this.CurrentLesson = wm.GetLessons(maxLessons: (ushort)lessonCount, maxWordsPerLesson: wordsCount);
            }
            else
            {
                var consonants = getConsonants();
                if (!consonants.Any())
                {
                    MessageBox.Show("Não foram encontradas consoantes!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.tbxConsonants.Text = string.Join(", ", consonants.OrderBy(c => c).ToArray());
                this.CurrentLesson = wm.GetLessons(consonants.Select(c => (c == "q") ? "qu" : c).ToArray(), maxWordsPerLesson: wordsCount); //hack: não se usa q sem u... meu querido
            }
            this.CurrentLesson = this.CurrentLesson.OrderBy(l => l.GetConsonant()).ToList();
            if (CurrentLesson == null || CurrentLesson.Count == 0) return;
            loadLesson(CurrentLesson.First());
            btnNext.Enabled = CurrentLesson.Count > 1;
            btnPrevious.Enabled = false;
        }

        private void loadLesson(SyllablesLesson lesson)
        {
            var syllables = lesson.GetSyllables();
            int i = 0;
            var labels = GetLinkLabels();
            lsbWords.Items.Clear();
            foreach (var lkl in labels)
                lkl.Text = "";

            foreach (var syllable in syllables)
            {
                var lkl = labels[i];
                lkl.Visible = true;
                lkl.Text = syllable;
                var words = lesson.GetWords(syllable);
                if (words?.Any() == true)
                    lsbWords.Items.AddRange(words);
                i++;

            }

        }

        private LinkLabel[] GetLinkLabels()
        {
            return grpExample.Controls.Cast<Control>().Where(c => c is LinkLabel).OrderBy(lkl => lkl.Name).Cast<LinkLabel>().ToArray();
        }

        private void cleanLesson()
        {
            CurrentLessonIndex = 0;
            CurrentLesson = null;
            var links = grpExample.Controls.Cast<Control>().Where(c => c is LinkLabel);
            foreach (var link in links)
                link.Visible = false;
            lsbWords.Items.Clear();
        }

        private void btnCreateWord_Click(object sender, EventArgs e)
        {
            DataWordsForm dwf = new DataWordsForm();
            dwf.ShowDialog(this);
            if (CurrentLesson != null)
                loadExample();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentLessonIndex > 0)
            {
                CurrentLessonIndex--;
                loadLesson(CurrentLesson[CurrentLessonIndex]);
            }
            btnNext.Enabled = CurrentLessonIndex + 1 < CurrentLesson.Count;
            btnPrevious.Enabled = CurrentLessonIndex > 0;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentLessonIndex < CurrentLesson.Count - 1)
            {
                CurrentLessonIndex++;
                loadLesson(CurrentLesson[CurrentLessonIndex]);
            }

            btnNext.Enabled = CurrentLessonIndex + 1 < CurrentLesson.Count;
            btnPrevious.Enabled = CurrentLessonIndex > 0;
        }
        //GetLessons(string[] letters = null, bool randomize = true, ushort maxLessons = 5, byte maxWordsPerLesson = 5)
    }
}
