namespace CartilhaMagica
{
    partial class CreateLessonForm
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
            this.lblConsonants = new System.Windows.Forms.Label();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.lblLessonCountLabel = new System.Windows.Forms.Label();
            this.lblWordCountLabel = new System.Windows.Forms.Label();
            this.tbxConsonants = new System.Windows.Forms.TextBox();
            this.mtbLessonCount = new System.Windows.Forms.MaskedTextBox();
            this.mtbWordCount = new System.Windows.Forms.MaskedTextBox();
            this.grpExample = new System.Windows.Forms.GroupBox();
            this.lkl5 = new System.Windows.Forms.LinkLabel();
            this.lkl4 = new System.Windows.Forms.LinkLabel();
            this.lkl3 = new System.Windows.Forms.LinkLabel();
            this.lkl2 = new System.Windows.Forms.LinkLabel();
            this.lkl1 = new System.Windows.Forms.LinkLabel();
            this.btnCreateWord = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lsbWords = new System.Windows.Forms.ListBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnViewExample = new System.Windows.Forms.Button();
            this.btnCreateLesson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpExample.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConsonants
            // 
            this.lblConsonants.AutoSize = true;
            this.lblConsonants.Location = new System.Drawing.Point(27, 36);
            this.lblConsonants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConsonants.Name = "lblConsonants";
            this.lblConsonants.Size = new System.Drawing.Size(93, 18);
            this.lblConsonants.TabIndex = 0;
            this.lblConsonants.Text = "Consoantes:";
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Checked = true;
            this.chkRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandom.Location = new System.Drawing.Point(374, 80);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(176, 22);
            this.chkRandom.TabIndex = 1;
            this.chkRandom.Text = "Consoantes aleatórias";
            this.chkRandom.UseVisualStyleBackColor = true;
            this.chkRandom.CheckedChanged += new System.EventHandler(this.chkRandom_CheckedChanged);
            // 
            // lblLessonCountLabel
            // 
            this.lblLessonCountLabel.AutoSize = true;
            this.lblLessonCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLessonCountLabel.Location = new System.Drawing.Point(27, 80);
            this.lblLessonCountLabel.Name = "lblLessonCountLabel";
            this.lblLessonCountLabel.Size = new System.Drawing.Size(219, 20);
            this.lblLessonCountLabel.TabIndex = 2;
            this.lblLessonCountLabel.Text = "N.o max de lições/consoantes";
            // 
            // lblWordCountLabel
            // 
            this.lblWordCountLabel.AutoSize = true;
            this.lblWordCountLabel.Location = new System.Drawing.Point(27, 118);
            this.lblWordCountLabel.Name = "lblWordCountLabel";
            this.lblWordCountLabel.Size = new System.Drawing.Size(211, 18);
            this.lblWordCountLabel.TabIndex = 3;
            this.lblWordCountLabel.Text = "N.o max de palavras por sílaba";
            // 
            // tbxConsonants
            // 
            this.tbxConsonants.Location = new System.Drawing.Point(173, 36);
            this.tbxConsonants.Name = "tbxConsonants";
            this.tbxConsonants.Size = new System.Drawing.Size(273, 24);
            this.tbxConsonants.TabIndex = 4;
            this.tbxConsonants.TextChanged += new System.EventHandler(this.tbxConsonants_TextChanged);
            this.tbxConsonants.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxConsonants_KeyDown);
            // 
            // mtbLessonCount
            // 
            this.mtbLessonCount.Location = new System.Drawing.Point(252, 78);
            this.mtbLessonCount.Mask = "00";
            this.mtbLessonCount.Name = "mtbLessonCount";
            this.mtbLessonCount.Size = new System.Drawing.Size(100, 24);
            this.mtbLessonCount.TabIndex = 5;
            this.mtbLessonCount.Text = "5";
            this.mtbLessonCount.ValidatingType = typeof(int);
            // 
            // mtbWordCount
            // 
            this.mtbWordCount.Location = new System.Drawing.Point(252, 115);
            this.mtbWordCount.Mask = "00";
            this.mtbWordCount.Name = "mtbWordCount";
            this.mtbWordCount.Size = new System.Drawing.Size(100, 24);
            this.mtbWordCount.TabIndex = 6;
            this.mtbWordCount.Text = "5";
            this.mtbWordCount.ValidatingType = typeof(int);
            // 
            // grpExample
            // 
            this.grpExample.Controls.Add(this.lkl5);
            this.grpExample.Controls.Add(this.lkl4);
            this.grpExample.Controls.Add(this.lkl3);
            this.grpExample.Controls.Add(this.lkl2);
            this.grpExample.Controls.Add(this.lkl1);
            this.grpExample.Controls.Add(this.btnCreateWord);
            this.grpExample.Controls.Add(this.lbl2);
            this.grpExample.Controls.Add(this.lsbWords);
            this.grpExample.Controls.Add(this.lbl1);
            this.grpExample.Controls.Add(this.btnNext);
            this.grpExample.Controls.Add(this.btnPrevious);
            this.grpExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExample.Location = new System.Drawing.Point(12, 165);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(538, 316);
            this.grpExample.TabIndex = 7;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "Exemplo";
            // 
            // lkl5
            // 
            this.lkl5.AutoSize = true;
            this.lkl5.Location = new System.Drawing.Point(262, 44);
            this.lkl5.Name = "lkl5";
            this.lkl5.Size = new System.Drawing.Size(22, 15);
            this.lkl5.TabIndex = 11;
            this.lkl5.TabStop = true;
            this.lkl5.Text = "BA";
            this.lkl5.Visible = false;
            // 
            // lkl4
            // 
            this.lkl4.AutoSize = true;
            this.lkl4.Location = new System.Drawing.Point(215, 44);
            this.lkl4.Name = "lkl4";
            this.lkl4.Size = new System.Drawing.Size(22, 15);
            this.lkl4.TabIndex = 10;
            this.lkl4.TabStop = true;
            this.lkl4.Text = "BA";
            this.lkl4.Visible = false;
            // 
            // lkl3
            // 
            this.lkl3.AutoSize = true;
            this.lkl3.Location = new System.Drawing.Point(168, 44);
            this.lkl3.Name = "lkl3";
            this.lkl3.Size = new System.Drawing.Size(22, 15);
            this.lkl3.TabIndex = 9;
            this.lkl3.TabStop = true;
            this.lkl3.Text = "BA";
            this.lkl3.Visible = false;
            // 
            // lkl2
            // 
            this.lkl2.AutoSize = true;
            this.lkl2.Location = new System.Drawing.Point(121, 44);
            this.lkl2.Name = "lkl2";
            this.lkl2.Size = new System.Drawing.Size(22, 15);
            this.lkl2.TabIndex = 8;
            this.lkl2.TabStop = true;
            this.lkl2.Text = "BA";
            this.lkl2.Visible = false;
            // 
            // lkl1
            // 
            this.lkl1.AutoSize = true;
            this.lkl1.Location = new System.Drawing.Point(74, 44);
            this.lkl1.Name = "lkl1";
            this.lkl1.Size = new System.Drawing.Size(22, 15);
            this.lkl1.TabIndex = 7;
            this.lkl1.TabStop = true;
            this.lkl1.Text = "BA";
            this.lkl1.Visible = false;
            // 
            // btnCreateWord
            // 
            this.btnCreateWord.Location = new System.Drawing.Point(6, 286);
            this.btnCreateWord.Name = "btnCreateWord";
            this.btnCreateWord.Size = new System.Drawing.Size(134, 23);
            this.btnCreateWord.TabIndex = 6;
            this.btnCreateWord.Text = "Cadastrar palavras";
            this.btnCreateWord.UseVisualStyleBackColor = true;
            this.btnCreateWord.Click += new System.EventHandler(this.btnCreateWord_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(6, 84);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(57, 15);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Palavras:";
            // 
            // lsbWords
            // 
            this.lsbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbWords.FormattingEnabled = true;
            this.lsbWords.Location = new System.Drawing.Point(6, 102);
            this.lsbWords.MultiColumn = true;
            this.lsbWords.Name = "lsbWords";
            this.lsbWords.Size = new System.Drawing.Size(526, 173);
            this.lsbWords.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(6, 44);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(51, 15);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Sílabas:";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(457, 287);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "próximo >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(376, 287);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<< anterior";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnViewExample
            // 
            this.btnViewExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewExample.Location = new System.Drawing.Point(349, 145);
            this.btnViewExample.Name = "btnViewExample";
            this.btnViewExample.Size = new System.Drawing.Size(97, 23);
            this.btnViewExample.TabIndex = 8;
            this.btnViewExample.Text = "Carregar exemplo";
            this.btnViewExample.UseVisualStyleBackColor = true;
            this.btnViewExample.Click += new System.EventHandler(this.btnViewExample_Click);
            // 
            // btnCreateLesson
            // 
            this.btnCreateLesson.Enabled = false;
            this.btnCreateLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateLesson.Location = new System.Drawing.Point(453, 145);
            this.btnCreateLesson.Name = "btnCreateLesson";
            this.btnCreateLesson.Size = new System.Drawing.Size(97, 23);
            this.btnCreateLesson.TabIndex = 9;
            this.btnCreateLesson.Text = "Criar lição";
            this.btnCreateLesson.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ex: b,d,lh,tr";
            // 
            // CreateLessonForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(562, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateLesson);
            this.Controls.Add(this.btnViewExample);
            this.Controls.Add(this.grpExample);
            this.Controls.Add(this.mtbWordCount);
            this.Controls.Add(this.mtbLessonCount);
            this.Controls.Add(this.tbxConsonants);
            this.Controls.Add(this.lblWordCountLabel);
            this.Controls.Add(this.lblLessonCountLabel);
            this.Controls.Add(this.chkRandom);
            this.Controls.Add(this.lblConsonants);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(578, 530);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(578, 530);
            this.Name = "CreateLessonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criar lição";
            this.grpExample.ResumeLayout(false);
            this.grpExample.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConsonants;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.Label lblLessonCountLabel;
        private System.Windows.Forms.Label lblWordCountLabel;
        private System.Windows.Forms.TextBox tbxConsonants;
        private System.Windows.Forms.MaskedTextBox mtbLessonCount;
        private System.Windows.Forms.MaskedTextBox mtbWordCount;
        private System.Windows.Forms.GroupBox grpExample;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.ListBox lsbWords;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnViewExample;
        private System.Windows.Forms.Button btnCreateLesson;
        private System.Windows.Forms.LinkLabel lkl5;
        private System.Windows.Forms.LinkLabel lkl4;
        private System.Windows.Forms.LinkLabel lkl3;
        private System.Windows.Forms.LinkLabel lkl2;
        private System.Windows.Forms.LinkLabel lkl1;
        private System.Windows.Forms.Button btnCreateWord;
        private System.Windows.Forms.Label label1;
    }
}