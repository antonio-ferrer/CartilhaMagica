namespace CartilhaMagica
{
    partial class WordsForm
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
            this.lblCountWord = new System.Windows.Forms.Label();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuConfigVoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfigWords = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelHard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSyllable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlUpperLetter = new System.Windows.Forms.Panel();
            this.lblUpperLetter = new System.Windows.Forms.Label();
            this.pbxUpperKeyboard = new System.Windows.Forms.PictureBox();
            this.pbxUpper = new System.Windows.Forms.PictureBox();
            this.lblUpperHandwrite = new System.Windows.Forms.Label();
            this.pbxUpperHandWrite = new System.Windows.Forms.PictureBox();
            this.pnlLowerLetter = new System.Windows.Forms.Panel();
            this.pbxLower = new System.Windows.Forms.PictureBox();
            this.lblLowerLetter = new System.Windows.Forms.Label();
            this.lblLowerHandwrite = new System.Windows.Forms.Label();
            this.lblWrite = new System.Windows.Forms.Label();
            this.pbxPencil = new System.Windows.Forms.PictureBox();
            this.pbxMedal = new System.Windows.Forms.PictureBox();
            this.pbxPrevious = new System.Windows.Forms.PictureBox();
            this.pbxMouth = new System.Windows.Forms.PictureBox();
            this.pnlUpperHandWrite = new System.Windows.Forms.Panel();
            this.pnlLowerHandwrite = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbxNext = new System.Windows.Forms.PictureBox();
            this.ctxMenu.SuspendLayout();
            this.pnlUpperLetter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpperKeyboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpperHandWrite)).BeginInit();
            this.pnlLowerLetter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPencil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMedal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMouth)).BeginInit();
            this.pnlUpperHandWrite.SuspendLayout();
            this.pnlLowerHandwrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCountWord
            // 
            this.lblCountWord.AutoSize = true;
            this.lblCountWord.BackColor = System.Drawing.Color.Transparent;
            this.lblCountWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCountWord.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountWord.Location = new System.Drawing.Point(95, 64);
            this.lblCountWord.Name = "lblCountWord";
            this.lblCountWord.Size = new System.Drawing.Size(22, 23);
            this.lblCountWord.TabIndex = 11;
            this.lblCountWord.Text = "1";
            this.lblCountWord.Click += new System.EventHandler(this.lblCountWord_Click);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConfigVoice,
            this.mnuConfigWords,
            this.mnuRestore,
            this.toolStripMenuItem1,
            this.mnuLevel,
            this.toolStripMenuItem2,
            this.mnuSyllable,
            this.toolStripMenuItem3,
            this.mnuInformation,
            this.mnuExit});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(178, 176);
            // 
            // mnuConfigVoice
            // 
            this.mnuConfigVoice.Name = "mnuConfigVoice";
            this.mnuConfigVoice.Size = new System.Drawing.Size(177, 22);
            this.mnuConfigVoice.Text = "Configurar voz";
            this.mnuConfigVoice.ToolTipText = "Abre o formulário para configuração da voz";
            this.mnuConfigVoice.Click += new System.EventHandler(this.mnuConfigVoice_Click);
            // 
            // mnuConfigWords
            // 
            this.mnuConfigWords.Name = "mnuConfigWords";
            this.mnuConfigWords.Size = new System.Drawing.Size(177, 22);
            this.mnuConfigWords.Text = "Configurar palavras";
            this.mnuConfigWords.ToolTipText = "Permite configurar, criar e remover palavras para o dicionário";
            this.mnuConfigWords.Click += new System.EventHandler(this.mnuConfigWords_Click);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(177, 22);
            this.mnuRestore.Text = "Restaurar";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuLevel
            // 
            this.mnuLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLevelEasy,
            this.mnuLevelAverage,
            this.mnuLevelHard});
            this.mnuLevel.Name = "mnuLevel";
            this.mnuLevel.Size = new System.Drawing.Size(177, 22);
            this.mnuLevel.Text = "Nível";
            // 
            // mnuLevelEasy
            // 
            this.mnuLevelEasy.Name = "mnuLevelEasy";
            this.mnuLevelEasy.Size = new System.Drawing.Size(108, 22);
            this.mnuLevelEasy.Text = "Fácil";
            this.mnuLevelEasy.Click += new System.EventHandler(this.mnuLevelEasy_Click);
            // 
            // mnuLevelAverage
            // 
            this.mnuLevelAverage.Name = "mnuLevelAverage";
            this.mnuLevelAverage.Size = new System.Drawing.Size(108, 22);
            this.mnuLevelAverage.Text = "Médio";
            this.mnuLevelAverage.Click += new System.EventHandler(this.mnuLevelAverage_Click);
            // 
            // mnuLevelHard
            // 
            this.mnuLevelHard.Name = "mnuLevelHard";
            this.mnuLevelHard.Size = new System.Drawing.Size(108, 22);
            this.mnuLevelHard.Text = "Difícil";
            this.mnuLevelHard.Click += new System.EventHandler(this.mnuLevelHard_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuSyllable
            // 
            this.mnuSyllable.Name = "mnuSyllable";
            this.mnuSyllable.Size = new System.Drawing.Size(177, 22);
            this.mnuSyllable.Text = "Modo sílabas";
            this.mnuSyllable.ToolTipText = "Carrega o modo de sílabas";
            this.mnuSyllable.Click += new System.EventHandler(this.mnuSyllable_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInformation
            // 
            this.mnuInformation.Name = "mnuInformation";
            this.mnuInformation.Size = new System.Drawing.Size(177, 22);
            this.mnuInformation.Text = "Informações";
            this.mnuInformation.ToolTipText = "Informações sobre mim";
            this.mnuInformation.Click += new System.EventHandler(this.mnuInformation_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(177, 22);
            this.mnuExit.Text = "Sair";
            this.mnuExit.ToolTipText = "Sair do aplicativo";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // pnlUpperLetter
            // 
            this.pnlUpperLetter.BackColor = System.Drawing.Color.Transparent;
            this.pnlUpperLetter.Controls.Add(this.lblUpperLetter);
            this.pnlUpperLetter.Controls.Add(this.pbxUpperKeyboard);
            this.pnlUpperLetter.Controls.Add(this.pbxUpper);
            this.pnlUpperLetter.Location = new System.Drawing.Point(2, 88);
            this.pnlUpperLetter.Name = "pnlUpperLetter";
            this.pnlUpperLetter.Size = new System.Drawing.Size(516, 127);
            this.pnlUpperLetter.TabIndex = 20;
            // 
            // lblUpperLetter
            // 
            this.lblUpperLetter.AutoSize = true;
            this.lblUpperLetter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpperLetter.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperLetter.Location = new System.Drawing.Point(84, 53);
            this.lblUpperLetter.Name = "lblUpperLetter";
            this.lblUpperLetter.Size = new System.Drawing.Size(191, 55);
            this.lblUpperLetter.TabIndex = 16;
            this.lblUpperLetter.Text = "TEXTO";
            this.toolTip1.SetToolTip(this.lblUpperLetter, "palavra atual em maiúscula e forma");
            this.lblUpperLetter.Click += new System.EventHandler(this.lblUpperLetter_Click);
            // 
            // pbxUpperKeyboard
            // 
            this.pbxUpperKeyboard.Image = global::CartilhaMagica.Properties.Resources.keyboard;
            this.pbxUpperKeyboard.Location = new System.Drawing.Point(87, 3);
            this.pbxUpperKeyboard.Name = "pbxUpperKeyboard";
            this.pbxUpperKeyboard.Size = new System.Drawing.Size(44, 40);
            this.pbxUpperKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxUpperKeyboard.TabIndex = 14;
            this.pbxUpperKeyboard.TabStop = false;
            // 
            // pbxUpper
            // 
            this.pbxUpper.BackColor = System.Drawing.Color.Khaki;
            this.pbxUpper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxUpper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxUpper.Image = global::CartilhaMagica.Properties.Resources.maiuscula;
            this.pbxUpper.Location = new System.Drawing.Point(20, 57);
            this.pbxUpper.Name = "pbxUpper";
            this.pbxUpper.Size = new System.Drawing.Size(44, 40);
            this.pbxUpper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxUpper.TabIndex = 12;
            this.pbxUpper.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxUpper, "Indicador de maiúsculo");
            this.pbxUpper.Click += new System.EventHandler(this.pbxUpper_Click);
            // 
            // lblUpperHandwrite
            // 
            this.lblUpperHandwrite.AutoSize = true;
            this.lblUpperHandwrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpperHandwrite.Font = new System.Drawing.Font("Always In My Heart", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperHandwrite.ForeColor = System.Drawing.Color.DimGray;
            this.lblUpperHandwrite.Location = new System.Drawing.Point(3, 44);
            this.lblUpperHandwrite.Name = "lblUpperHandwrite";
            this.lblUpperHandwrite.Size = new System.Drawing.Size(200, 75);
            this.lblUpperHandwrite.TabIndex = 17;
            this.lblUpperHandwrite.Text = "TEXTO";
            this.toolTip1.SetToolTip(this.lblUpperHandwrite, "palavra atual em maiúscula e \"letra de mão\"");
            this.lblUpperHandwrite.Click += new System.EventHandler(this.lblUpperHandwrite_Click);
            // 
            // pbxUpperHandWrite
            // 
            this.pbxUpperHandWrite.Image = global::CartilhaMagica.Properties.Resources.hand;
            this.pbxUpperHandWrite.Location = new System.Drawing.Point(31, 3);
            this.pbxUpperHandWrite.Name = "pbxUpperHandWrite";
            this.pbxUpperHandWrite.Size = new System.Drawing.Size(44, 40);
            this.pbxUpperHandWrite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxUpperHandWrite.TabIndex = 15;
            this.pbxUpperHandWrite.TabStop = false;
            // 
            // pnlLowerLetter
            // 
            this.pnlLowerLetter.BackColor = System.Drawing.Color.Transparent;
            this.pnlLowerLetter.Controls.Add(this.pbxLower);
            this.pnlLowerLetter.Controls.Add(this.lblLowerLetter);
            this.pnlLowerLetter.Location = new System.Drawing.Point(2, 288);
            this.pnlLowerLetter.Name = "pnlLowerLetter";
            this.pnlLowerLetter.Size = new System.Drawing.Size(516, 127);
            this.pnlLowerLetter.TabIndex = 22;
            // 
            // pbxLower
            // 
            this.pbxLower.BackColor = System.Drawing.Color.Khaki;
            this.pbxLower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxLower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxLower.Image = global::CartilhaMagica.Properties.Resources.minuscula;
            this.pbxLower.Location = new System.Drawing.Point(19, 56);
            this.pbxLower.Name = "pbxLower";
            this.pbxLower.Size = new System.Drawing.Size(44, 40);
            this.pbxLower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLower.TabIndex = 21;
            this.pbxLower.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxLower, "Indicador de minúsculo");
            this.pbxLower.Click += new System.EventHandler(this.pbxLower_Click);
            // 
            // lblLowerLetter
            // 
            this.lblLowerLetter.AutoSize = true;
            this.lblLowerLetter.BackColor = System.Drawing.Color.Transparent;
            this.lblLowerLetter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLowerLetter.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerLetter.Location = new System.Drawing.Point(87, 51);
            this.lblLowerLetter.Name = "lblLowerLetter";
            this.lblLowerLetter.Size = new System.Drawing.Size(125, 55);
            this.lblLowerLetter.TabIndex = 16;
            this.lblLowerLetter.Text = "texto";
            this.toolTip1.SetToolTip(this.lblLowerLetter, "palavra atual em letra de forma");
            this.lblLowerLetter.Click += new System.EventHandler(this.lblLowerLetter_Click);
            // 
            // lblLowerHandwrite
            // 
            this.lblLowerHandwrite.AutoSize = true;
            this.lblLowerHandwrite.BackColor = System.Drawing.Color.Transparent;
            this.lblLowerHandwrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLowerHandwrite.Font = new System.Drawing.Font("Always In My Heart", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerHandwrite.ForeColor = System.Drawing.Color.DimGray;
            this.lblLowerHandwrite.Location = new System.Drawing.Point(3, 43);
            this.lblLowerHandwrite.Name = "lblLowerHandwrite";
            this.lblLowerHandwrite.Size = new System.Drawing.Size(124, 75);
            this.lblLowerHandwrite.TabIndex = 17;
            this.lblLowerHandwrite.Text = "texto";
            this.toolTip1.SetToolTip(this.lblLowerHandwrite, "palavra atual em \"letra de mão\"");
            this.lblLowerHandwrite.Click += new System.EventHandler(this.lblLowerHandwrite_Click);
            // 
            // lblWrite
            // 
            this.lblWrite.AutoSize = true;
            this.lblWrite.BackColor = System.Drawing.Color.Transparent;
            this.lblWrite.Font = new System.Drawing.Font("Always In My Heart", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrite.ForeColor = System.Drawing.Color.DimGray;
            this.lblWrite.Location = new System.Drawing.Point(89, 592);
            this.lblWrite.Name = "lblWrite";
            this.lblWrite.Size = new System.Drawing.Size(93, 56);
            this.lblWrite.TabIndex = 24;
            this.lblWrite.Text = "texto";
            this.lblWrite.SizeChanged += new System.EventHandler(this.lblWrite_SizeChanged);
            // 
            // pbxPencil
            // 
            this.pbxPencil.BackColor = System.Drawing.Color.Transparent;
            this.pbxPencil.Image = global::CartilhaMagica.Properties.Resources._0_4688_pencil_clipart;
            this.pbxPencil.Location = new System.Drawing.Point(188, 453);
            this.pbxPencil.Name = "pbxPencil";
            this.pbxPencil.Size = new System.Drawing.Size(183, 180);
            this.pbxPencil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPencil.TabIndex = 23;
            this.pbxPencil.TabStop = false;
            // 
            // pbxMedal
            // 
            this.pbxMedal.BackColor = System.Drawing.Color.White;
            this.pbxMedal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMedal.Image = global::CartilhaMagica.Properties.Resources.bronze_medal;
            this.pbxMedal.Location = new System.Drawing.Point(12, 33);
            this.pbxMedal.Name = "pbxMedal";
            this.pbxMedal.Size = new System.Drawing.Size(62, 49);
            this.pbxMedal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMedal.TabIndex = 30;
            this.pbxMedal.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxMedal, "Indica o nível atual");
            this.pbxMedal.Click += new System.EventHandler(this.pbxMedal_Click);
            // 
            // pbxPrevious
            // 
            this.pbxPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxPrevious.BackColor = System.Drawing.Color.Transparent;
            this.pbxPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxPrevious.Image = global::CartilhaMagica.Properties.Resources.left_arrow;
            this.pbxPrevious.Location = new System.Drawing.Point(771, 615);
            this.pbxPrevious.Name = "pbxPrevious";
            this.pbxPrevious.Size = new System.Drawing.Size(49, 41);
            this.pbxPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPrevious.TabIndex = 27;
            this.pbxPrevious.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxPrevious, "Voltar para a palavra anterior");
            this.pbxPrevious.Click += new System.EventHandler(this.pbxPrevious_Click);
            // 
            // pbxMouth
            // 
            this.pbxMouth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxMouth.BackColor = System.Drawing.Color.Transparent;
            this.pbxMouth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMouth.Image = global::CartilhaMagica.Properties.Resources.clipartwiki_com_robot_clip_art_128797;
            this.pbxMouth.Location = new System.Drawing.Point(885, 480);
            this.pbxMouth.Name = "pbxMouth";
            this.pbxMouth.Size = new System.Drawing.Size(200, 200);
            this.pbxMouth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMouth.TabIndex = 25;
            this.pbxMouth.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxMouth, "Esse robo é uma fofura. Clique nele e veja o que acontece");
            this.pbxMouth.Click += new System.EventHandler(this.pbxMouth_Click);
            // 
            // pnlUpperHandWrite
            // 
            this.pnlUpperHandWrite.BackColor = System.Drawing.Color.Transparent;
            this.pnlUpperHandWrite.Controls.Add(this.lblUpperHandwrite);
            this.pnlUpperHandWrite.Controls.Add(this.pbxUpperHandWrite);
            this.pnlUpperHandWrite.Location = new System.Drawing.Point(536, 88);
            this.pnlUpperHandWrite.Name = "pnlUpperHandWrite";
            this.pnlUpperHandWrite.Size = new System.Drawing.Size(516, 127);
            this.pnlUpperHandWrite.TabIndex = 31;
            // 
            // pnlLowerHandwrite
            // 
            this.pnlLowerHandwrite.BackColor = System.Drawing.Color.Transparent;
            this.pnlLowerHandwrite.Controls.Add(this.lblLowerHandwrite);
            this.pnlLowerHandwrite.Location = new System.Drawing.Point(536, 288);
            this.pnlLowerHandwrite.Name = "pnlLowerHandwrite";
            this.pnlLowerHandwrite.Size = new System.Drawing.Size(516, 127);
            this.pnlLowerHandwrite.TabIndex = 32;
            // 
            // pbxNext
            // 
            this.pbxNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxNext.BackColor = System.Drawing.Color.Transparent;
            this.pbxNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxNext.Image = global::CartilhaMagica.Properties.Resources.right_arrow;
            this.pbxNext.Location = new System.Drawing.Point(826, 615);
            this.pbxNext.Name = "pbxNext";
            this.pbxNext.Size = new System.Drawing.Size(49, 41);
            this.pbxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxNext.TabIndex = 33;
            this.pbxNext.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxNext, "Voltar para a palavra anterior");
            this.pbxNext.Click += new System.EventHandler(this.pbxNext_Click);
            // 
            // WordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CartilhaMagica.Properties.Resources.cadernao3;
            this.ClientSize = new System.Drawing.Size(1057, 681);
            this.Controls.Add(this.pbxNext);
            this.Controls.Add(this.pbxPencil);
            this.Controls.Add(this.pbxMouth);
            this.Controls.Add(this.lblWrite);
            this.Controls.Add(this.pnlLowerHandwrite);
            this.Controls.Add(this.pnlUpperHandWrite);
            this.Controls.Add(this.pbxMedal);
            this.Controls.Add(this.pbxPrevious);
            this.Controls.Add(this.pnlLowerLetter);
            this.Controls.Add(this.pnlUpperLetter);
            this.Controls.Add(this.lblCountWord);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1073, 720);
            this.Name = "WordsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartilha mágica     *     pressione F1 para opções ";
            this.SizeChanged += new System.EventHandler(this.WordsForm_SizeChanged);
            this.ctxMenu.ResumeLayout(false);
            this.pnlUpperLetter.ResumeLayout(false);
            this.pnlUpperLetter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpperKeyboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpperHandWrite)).EndInit();
            this.pnlLowerLetter.ResumeLayout(false);
            this.pnlLowerLetter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPencil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMedal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMouth)).EndInit();
            this.pnlUpperHandWrite.ResumeLayout(false);
            this.pnlUpperHandWrite.PerformLayout();
            this.pnlLowerHandwrite.ResumeLayout(false);
            this.pnlLowerHandwrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCountWord;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigVoice;
        private System.Windows.Forms.ToolStripMenuItem mnuSyllable;
        private System.Windows.Forms.PictureBox pbxUpper;
        private System.Windows.Forms.PictureBox pbxUpperKeyboard;
        private System.Windows.Forms.PictureBox pbxUpperHandWrite;
        private System.Windows.Forms.Panel pnlUpperLetter;
        private System.Windows.Forms.Label lblUpperHandwrite;
        private System.Windows.Forms.Label lblUpperLetter;
        private System.Windows.Forms.PictureBox pbxLower;
        private System.Windows.Forms.Panel pnlLowerLetter;
        private System.Windows.Forms.Label lblLowerHandwrite;
        private System.Windows.Forms.Label lblLowerLetter;
        private System.Windows.Forms.PictureBox pbxPencil;
        private System.Windows.Forms.Label lblWrite;
        private System.Windows.Forms.PictureBox pbxMouth;
        private System.Windows.Forms.PictureBox pbxPrevious;
        private System.Windows.Forms.ToolStripMenuItem mnuLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelEasy;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelAverage;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelHard;
        private System.Windows.Forms.PictureBox pbxMedal;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigWords;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Panel pnlUpperHandWrite;
        private System.Windows.Forms.Panel pnlLowerHandwrite;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mnuInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.PictureBox pbxNext;
    }
}

