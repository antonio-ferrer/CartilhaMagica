namespace CartilhaMagica
{
    partial class VoiceSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxSampleText = new System.Windows.Forms.TextBox();
            this.cboVoice = new System.Windows.Forms.ComboBox();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.lblSampleText = new System.Windows.Forms.Label();
            this.lblVoice = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkVoice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxSampleText
            // 
            this.tbxSampleText.Location = new System.Drawing.Point(119, 22);
            this.tbxSampleText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxSampleText.Name = "tbxSampleText";
            this.tbxSampleText.Size = new System.Drawing.Size(314, 25);
            this.tbxSampleText.TabIndex = 0;
            this.tbxSampleText.Text = "Isso é um texto";
            // 
            // cboVoice
            // 
            this.cboVoice.FormattingEnabled = true;
            this.cboVoice.Location = new System.Drawing.Point(119, 78);
            this.cboVoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVoice.Name = "cboVoice";
            this.cboVoice.Size = new System.Drawing.Size(314, 25);
            this.cboVoice.TabIndex = 1;
            // 
            // trbSpeed
            // 
            this.trbSpeed.Location = new System.Drawing.Point(118, 137);
            this.trbSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trbSpeed.Minimum = -10;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(315, 45);
            this.trbSpeed.TabIndex = 2;
            // 
            // lblSampleText
            // 
            this.lblSampleText.AutoSize = true;
            this.lblSampleText.Location = new System.Drawing.Point(12, 25);
            this.lblSampleText.Name = "lblSampleText";
            this.lblSampleText.Size = new System.Drawing.Size(93, 17);
            this.lblSampleText.TabIndex = 3;
            this.lblSampleText.Text = "Texto exemplo";
            // 
            // lblVoice
            // 
            this.lblVoice.AutoSize = true;
            this.lblVoice.Location = new System.Drawing.Point(12, 81);
            this.lblVoice.Name = "lblVoice";
            this.lblVoice.Size = new System.Drawing.Size(29, 17);
            this.lblVoice.TabIndex = 4;
            this.lblVoice.Text = "Voz";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(12, 137);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(72, 17);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "Velocidade";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(498, 25);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(82, 34);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Testar";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(498, 137);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(82, 34);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Aplicar";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkVoice
            // 
            this.chkVoice.AutoSize = true;
            this.chkVoice.Location = new System.Drawing.Point(18, 197);
            this.chkVoice.Name = "chkVoice";
            this.chkVoice.Size = new System.Drawing.Size(109, 21);
            this.chkVoice.TabIndex = 8;
            this.chkVoice.Text = "Voz habilitada";
            this.chkVoice.UseVisualStyleBackColor = true;
            // 
            // VoiceSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 246);
            this.Controls.Add(this.chkVoice);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblVoice);
            this.Controls.Add(this.lblSampleText);
            this.Controls.Add(this.trbSpeed);
            this.Controls.Add(this.cboVoice);
            this.Controls.Add(this.tbxSampleText);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoiceSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações de voz";
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSampleText;
        private System.Windows.Forms.ComboBox cboVoice;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label lblSampleText;
        private System.Windows.Forms.Label lblVoice;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkVoice;
    }
}