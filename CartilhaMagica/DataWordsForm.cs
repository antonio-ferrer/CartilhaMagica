using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    public partial class DataWordsForm : Form
    {

        private Manager.WordManager wm;
        public DataWordsForm()
        {
            InitializeComponent();
            wm = new Manager.WordManager();
            this.Load += DataWordsForm_Load;
        }

        private void DataWordsForm_Load(object sender, EventArgs e)
        {
            var words = wm.GetWords(Manager.Level.Hard, false).OrderBy(w => w).ToArray();
            lsbWords.Items.Clear();
            foreach (string w in words)
                lsbWords.Items.Add(w);

        }

        private void lsbWords_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                
                var selection = lsbWords.SelectedItems;
                if (selection == null || selection.Count == 0)
                    return;
                var data = selection.Cast<string>().ToArray();
                lsbWords.ClearSelected();
                foreach (string s in data)
                    lsbWords.Items.Remove(s);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            string[] words = lsbWords.Items.Cast<string>().ToArray();
            string word = textBox1.Text.ToLower();
            if (!words.Contains(word))
            {
                lsbWords.Items.Add(word);
                textBox1.Text = "";
                lsbWords.ClearSelected();
            }
            else
            {
                lsbWords.ClearSelected();
                lsbWords.SelectedItem = word;
            }
            lblCount.Text = "";
        }

        private void DataWordsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var original = wm.GetWords(Manager.Level.Hard, false).ToArray();
            var current = lsbWords.Items.Cast<string>().OrderBy(w => w).ToArray();
            if (current.Length == 0)
                return;
            var change = original.Count() != current.Count() || current.Count(c=>!original.Contains(c)) > 0 || original.Count(o=>!current.Contains(o)) > 0;
            if (change && MessageBox.Show("Deseja salvar as alterações?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                wm.SaveWords(current);
            }
        }

        private void lklEasy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lsbWords.ClearSelected();
            var words = wm.GetWords(Manager.Level.Easy);
            foreach (var w in words)
                lsbWords.SelectedItems.Add(w);
            lblCount.Text = lsbWords.SelectedItems.Count.ToString();
        }

        private void lklAverage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lsbWords.ClearSelected();
            var denyWords = wm.GetWords(Manager.Level.Easy);
            var words = wm.GetWords(Manager.Level.Average);
            words = words.Where(w => !denyWords.Contains(w)).ToArray();
            foreach (var w in words)
                lsbWords.SelectedItems.Add(w);
            lblCount.Text = lsbWords.SelectedItems.Count.ToString();

        }

        private void lklHard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lsbWords.ClearSelected();
            var denyWords = wm.GetWords(Manager.Level.Average);
            var words = wm.GetWords(Manager.Level.Hard);
            words = words.Where(w => !denyWords.Contains(w)).ToArray();
            foreach (var w in words)
                lsbWords.SelectedItems.Add(w);
            lblCount.Text = lsbWords.SelectedItems.Count.ToString();

        }
    }
}
