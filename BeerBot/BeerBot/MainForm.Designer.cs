namespace BeerBot
{
    partial class MainForm
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
            this.userPanel = new System.Windows.Forms.Panel();
            this.logOffButton = new System.Windows.Forms.Button();
            this.userLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.beerAdviceButton = new System.Windows.Forms.Button();
            this.beerNameLabel = new System.Windows.Forms.Label();
            this.adviceConditionPanel = new System.Windows.Forms.Panel();
            this.adviceConditionTitleLabel = new System.Windows.Forms.Label();
            this.advicePanel = new System.Windows.Forms.Panel();
            this.answerLoadButton = new System.Windows.Forms.Button();
            this.arrowPictureBox = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.beerPictureBox = new System.Windows.Forms.PictureBox();
            this.conditionsPictureBox = new System.Windows.Forms.PictureBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.styleLabel = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userLogoPictureBox)).BeginInit();
            this.adviceConditionPanel.SuspendLayout();
            this.advicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.Color.SlateGray;
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userPanel.Controls.Add(this.logOffButton);
            this.userPanel.Controls.Add(this.userLogoPictureBox);
            this.userPanel.Controls.Add(this.userNameLabel);
            this.userPanel.Controls.Add(this.quitButton);
            this.userPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPanel.ForeColor = System.Drawing.Color.White;
            this.userPanel.Location = new System.Drawing.Point(14, 15);
            this.userPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(858, 54);
            this.userPanel.TabIndex = 0;
            // 
            // logOffButton
            // 
            this.logOffButton.BackColor = System.Drawing.Color.SteelBlue;
            this.logOffButton.Location = new System.Drawing.Point(719, -2);
            this.logOffButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logOffButton.Name = "logOffButton";
            this.logOffButton.Size = new System.Drawing.Size(132, 28);
            this.logOffButton.TabIndex = 2;
            this.logOffButton.Text = "Se déconnecter";
            this.logOffButton.UseVisualStyleBackColor = false;
            this.logOffButton.Click += new System.EventHandler(this.logOffButton_Click);
            // 
            // userLogoPictureBox
            // 
            this.userLogoPictureBox.Location = new System.Drawing.Point(-3, -2);
            this.userLogoPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userLogoPictureBox.Name = "userLogoPictureBox";
            this.userLogoPictureBox.Size = new System.Drawing.Size(54, 54);
            this.userLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userLogoPictureBox.TabIndex = 0;
            this.userLogoPictureBox.TabStop = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(57, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(128, 50);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "X";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userNameLabel.Visible = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.quitButton.Location = new System.Drawing.Point(719, 23);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(132, 28);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quitter";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // beerAdviceButton
            // 
            this.beerAdviceButton.BackColor = System.Drawing.Color.SteelBlue;
            this.beerAdviceButton.Location = new System.Drawing.Point(267, 233);
            this.beerAdviceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beerAdviceButton.Name = "beerAdviceButton";
            this.beerAdviceButton.Size = new System.Drawing.Size(88, 33);
            this.beerAdviceButton.TabIndex = 1;
            this.beerAdviceButton.Text = "Conseiller";
            this.beerAdviceButton.UseVisualStyleBackColor = false;
            this.beerAdviceButton.Click += new System.EventHandler(this.beerAdviceButton_Click);
            // 
            // beerNameLabel
            // 
            this.beerNameLabel.AutoSize = true;
            this.beerNameLabel.Location = new System.Drawing.Point(3, 9);
            this.beerNameLabel.Name = "beerNameLabel";
            this.beerNameLabel.Size = new System.Drawing.Size(98, 16);
            this.beerNameLabel.TabIndex = 2;
            this.beerNameLabel.Text = "beerNameLabel";
            this.beerNameLabel.Visible = false;
            // 
            // adviceConditionPanel
            // 
            this.adviceConditionPanel.BackColor = System.Drawing.Color.SlateGray;
            this.adviceConditionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adviceConditionPanel.Controls.Add(this.styleComboBox);
            this.adviceConditionPanel.Controls.Add(this.styleLabel);
            this.adviceConditionPanel.Controls.Add(this.categoryComboBox);
            this.adviceConditionPanel.Controls.Add(this.categoryLabel);
            this.adviceConditionPanel.Controls.Add(this.conditionsPictureBox);
            this.adviceConditionPanel.Controls.Add(this.adviceConditionTitleLabel);
            this.adviceConditionPanel.Controls.Add(this.beerAdviceButton);
            this.adviceConditionPanel.Location = new System.Drawing.Point(13, 77);
            this.adviceConditionPanel.Name = "adviceConditionPanel";
            this.adviceConditionPanel.Size = new System.Drawing.Size(360, 272);
            this.adviceConditionPanel.TabIndex = 3;
            // 
            // adviceConditionTitleLabel
            // 
            this.adviceConditionTitleLabel.AutoSize = true;
            this.adviceConditionTitleLabel.Location = new System.Drawing.Point(1, 10);
            this.adviceConditionTitleLabel.Name = "adviceConditionTitleLabel";
            this.adviceConditionTitleLabel.Size = new System.Drawing.Size(221, 16);
            this.adviceConditionTitleLabel.TabIndex = 2;
            this.adviceConditionTitleLabel.Text = "De quoi avez vous envie aujourd\'hui ?";
            // 
            // advicePanel
            // 
            this.advicePanel.BackColor = System.Drawing.Color.SlateGray;
            this.advicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.advicePanel.Controls.Add(this.beerPictureBox);
            this.advicePanel.Controls.Add(this.beerNameLabel);
            this.advicePanel.Location = new System.Drawing.Point(512, 78);
            this.advicePanel.Name = "advicePanel";
            this.advicePanel.Size = new System.Drawing.Size(360, 272);
            this.advicePanel.TabIndex = 4;
            // 
            // answerLoadButton
            // 
            this.answerLoadButton.BackColor = System.Drawing.Color.SteelBlue;
            this.answerLoadButton.Location = new System.Drawing.Point(379, 311);
            this.answerLoadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.answerLoadButton.Name = "answerLoadButton";
            this.answerLoadButton.Size = new System.Drawing.Size(127, 33);
            this.answerLoadButton.TabIndex = 3;
            this.answerLoadButton.Text = "Charger la réponse";
            this.answerLoadButton.UseVisualStyleBackColor = false;
            this.answerLoadButton.Click += new System.EventHandler(this.answerLoadButton_Click);
            // 
            // arrowPictureBox
            // 
            this.arrowPictureBox.Location = new System.Drawing.Point(379, 78);
            this.arrowPictureBox.Name = "arrowPictureBox";
            this.arrowPictureBox.Size = new System.Drawing.Size(127, 127);
            this.arrowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrowPictureBox.TabIndex = 6;
            this.arrowPictureBox.TabStop = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(379, 212);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(127, 95);
            this.loadingLabel.TabIndex = 7;
            this.loadingLabel.Text = "loadingLabel";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // beerPictureBox
            // 
            this.beerPictureBox.Location = new System.Drawing.Point(227, 3);
            this.beerPictureBox.Name = "beerPictureBox";
            this.beerPictureBox.Size = new System.Drawing.Size(127, 127);
            this.beerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.beerPictureBox.TabIndex = 8;
            this.beerPictureBox.TabStop = false;
            // 
            // conditionsPictureBox
            // 
            this.conditionsPictureBox.Location = new System.Drawing.Point(4, 140);
            this.conditionsPictureBox.Name = "conditionsPictureBox";
            this.conditionsPictureBox.Size = new System.Drawing.Size(127, 127);
            this.conditionsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.conditionsPictureBox.TabIndex = 9;
            this.conditionsPictureBox.TabStop = false;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(3, 36);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(71, 16);
            this.categoryLabel.TabIndex = 10;
            this.categoryLabel.Text = "Catégorie :";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(15, 56);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 24);
            this.categoryComboBox.TabIndex = 11;
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(201, 56);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(121, 24);
            this.styleComboBox.TabIndex = 13;
            // 
            // styleLabel
            // 
            this.styleLabel.AutoSize = true;
            this.styleLabel.Location = new System.Drawing.Point(189, 36);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(46, 16);
            this.styleLabel.TabIndex = 12;
            this.styleLabel.Text = "Style :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(884, 362);
            this.Controls.Add(this.answerLoadButton);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.arrowPictureBox);
            this.Controls.Add(this.advicePanel);
            this.Controls.Add(this.adviceConditionPanel);
            this.Controls.Add(this.userPanel);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.userPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userLogoPictureBox)).EndInit();
            this.adviceConditionPanel.ResumeLayout(false);
            this.adviceConditionPanel.PerformLayout();
            this.advicePanel.ResumeLayout(false);
            this.advicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.PictureBox userLogoPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button logOffButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button beerAdviceButton;
        private System.Windows.Forms.Label beerNameLabel;
        private System.Windows.Forms.Panel adviceConditionPanel;
        private System.Windows.Forms.Panel advicePanel;
        private System.Windows.Forms.Label adviceConditionTitleLabel;
        private System.Windows.Forms.PictureBox arrowPictureBox;
        private System.Windows.Forms.Button answerLoadButton;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.PictureBox beerPictureBox;
        private System.Windows.Forms.PictureBox conditionsPictureBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
    }
}