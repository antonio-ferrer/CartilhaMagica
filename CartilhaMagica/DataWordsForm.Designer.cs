namespace CartilhaMagica
{
    partial class DataWordsForm
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
            this.components = new System.ComponentModel.Container();
            this.lsbWords = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lklEasy = new System.Windows.Forms.LinkLabel();
            this.lklAverage = new System.Windows.Forms.LinkLabel();
            this.lklHard = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lsbWords
            // 
            this.lsbWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbWords.FormattingEnabled = true;
            this.lsbWords.ItemHeight = 16;
            this.lsbWords.Location = new System.Drawing.Point(12, 43);
            this.lsbWords.MultiColumn = true;
            this.lsbWords.Name = "lsbWords";
            this.lsbWords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbWords.Size = new System.Drawing.Size(776, 388);
            this.lsbWords.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lsbWords, "Após selecionar as palavras, pressione DEL para excluir");
            this.lsbWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbWords_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 22);
            this.textBox1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox1, "Pressione enter para cadastrar");
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(372, 17);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0";
            // 
            // lklEasy
            // 
            this.lklEasy.AutoSize = true;
            this.lklEasy.Location = new System.Drawing.Point(415, 17);
            this.lklEasy.Name = "lklEasy";
            this.lklEasy.Size = new System.Drawing.Size(26, 13);
            this.lklEasy.TabIndex = 3;
            this.lklEasy.TabStop = true;
            this.lklEasy.Text = "fácil";
            this.lklEasy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklEasy_LinkClicked);
            // 
            // lklAverage
            // 
            this.lklAverage.AutoSize = true;
            this.lklAverage.Location = new System.Drawing.Point(459, 17);
            this.lklAverage.Name = "lklAverage";
            this.lklAverage.Size = new System.Drawing.Size(35, 13);
            this.lklAverage.TabIndex = 4;
            this.lklAverage.TabStop = true;
            this.lklAverage.Text = "médio";
            this.lklAverage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklAverage_LinkClicked);
            // 
            // lklHard
            // 
            this.lklHard.AutoSize = true;
            this.lklHard.Location = new System.Drawing.Point(509, 17);
            this.lklHard.Name = "lklHard";
            this.lklHard.Size = new System.Drawing.Size(32, 13);
            this.lklHard.TabIndex = 5;
            this.lklHard.TabStop = true;
            this.lklHard.Text = "difícil";
            this.lklHard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklHard_LinkClicked);
            // 
            // DataWordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lklHard);
            this.Controls.Add(this.lklAverage);
            this.Controls.Add(this.lklEasy);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lsbWords);
            this.MinimizeBox = false;
            this.Name = "DataWordsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de palavras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataWordsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbWords;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.LinkLabel lklEasy;
        private System.Windows.Forms.LinkLabel lklAverage;
        private System.Windows.Forms.LinkLabel lklHard;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}