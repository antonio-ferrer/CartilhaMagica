using CartilhaMagica.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    public partial class InformationForm : Form
    {

        private bool agree;

        public InformationForm()
        {
            InitializeComponent();
            agree = false;
            this.Load += (o, s) =>
            {
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = 0;
                checkBox1.Checked = !SetupManager.IsFirstUse();
                if (checkBox1.Checked)
                    checkBox1.Visible = false;
                button2.Visible = !SetupManager.HasFont();
                button1.Visible = SetupManager.HasFont();

            };
            this.FormClosing += InformationForm_FormClosing;
        }

        private void InformationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!agree)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool firstUser = SetupManager.IsFirstUse();
            Manager.SetupManager.AgreeTerms();
            if (firstUser)
            {
                MessageBox.Show("Na tela que irá abrir a seguir,\r\npressione a tecla [ F1 ] para opções", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!SetupManager.HasFont())
                {
                    MessageBox.Show("É necessário a instalação da fonte.\r\nCaso ja tenha instalado, abra o aplicativo novamente", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return;
                }
                else
                    new WordsForm().ShowDialog();
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            agree = button1.Enabled = checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Clipboard.SetText("cartilha.magica@gmx.com.br");

                Process.Start("mailto://cartilha.magica@gmx.com.br");
            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetupManager.InstallFont();
            if (!SetupManager.HasFont())
            {
                MessageBox.Show("O aplicativo será encerrado.\r\nInicie-o novamente para que a fonte seja carregada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
    }
}
