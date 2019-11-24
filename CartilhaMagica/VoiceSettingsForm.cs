using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartilhaMagica
{
    public partial class VoiceSettingsForm : Form
    {
        public VoiceSettingsForm()
        {
            InitializeComponent();
            this.Load += VoiceSettingsForm_Load;
        }

        private void VoiceSettingsForm_Load(object sender, EventArgs e)
        {
            loadVoices();
            chkVoice.Checked = Manager.SpeechManager.Enabled;
        }

        private void loadVoices()
        {
            var voices = Manager.SpeechManager.GetVoices();
            cboVoice.DataSource = voices;
            var voice = Manager.SpeechManager.GetVoice();
            cboVoice.SelectedIndex = -1;
            cboVoice.DisplayMember = "Name";
            cboVoice.ValueMember = "Id";
            cboVoice.SelectedItem = voice;

            trbSpeed.Value = Manager.SpeechManager.Rate;
                 
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Manager.SpeechManager.Rate = trbSpeed.Value;
            Manager.SpeechManager.Speak(tbxSampleText.Text);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Manager.SpeechManager.ApplySettings(((VoiceInfo)cboVoice.SelectedItem).Name, trbSpeed.Value, chkVoice.Checked);
            this.Close();
        }
    }
}
