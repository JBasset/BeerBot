namespace AleVisor
{
    partial class SearchForm
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
            this.advicePanel = new System.Windows.Forms.Panel();
            this.helpConditionButton = new System.Windows.Forms.Button();
            this.ratingButton = new System.Windows.Forms.Button();
            this.userRatingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.onFiveLabel = new System.Windows.Forms.Label();
            this.userRatingLabel = new System.Windows.Forms.Label();
            this.ratingTitleLabel = new System.Windows.Forms.Label();
            this.anotherLabel = new System.Windows.Forms.Label();
            this.nextBeerButton = new System.Windows.Forms.Button();
            this.previousBeerButton = new System.Windows.Forms.Button();
            this.beerDescriptionPanel = new System.Windows.Forms.Panel();
            this.beerDescriptionLabel = new System.Windows.Forms.Label();
            this.resultSrmValueLabel = new System.Windows.Forms.Label();
            this.resultIbuValueLabel = new System.Windows.Forms.Label();
            this.resultAbvValueLabel = new System.Windows.Forms.Label();
            this.resultSrmLabel = new System.Windows.Forms.Label();
            this.resultIbuLabel = new System.Windows.Forms.Label();
            this.resultAbvLabel = new System.Windows.Forms.Label();
            this.resutlTitleLabel = new System.Windows.Forms.Label();
            this.beerPictureBox = new System.Windows.Forms.PictureBox();
            this.beerNameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quitButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.nameSearchTextBox = new System.Windows.Forms.TextBox();
            this.modificationButton = new System.Windows.Forms.Button();
            this.newBeerButton = new System.Windows.Forms.Button();
            this.sepLabel = new System.Windows.Forms.Label();
            this.categoryTitleLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.styleLabel = new System.Windows.Forms.Label();
            this.advicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userRatingNumericUpDown)).BeginInit();
            this.beerDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beerPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advicePanel
            // 
            this.advicePanel.BackColor = System.Drawing.Color.SlateGray;
            this.advicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.advicePanel.Controls.Add(this.styleLabel);
            this.advicePanel.Controls.Add(this.categoryLabel);
            this.advicePanel.Controls.Add(this.sepLabel);
            this.advicePanel.Controls.Add(this.categoryTitleLabel);
            this.advicePanel.Controls.Add(this.helpConditionButton);
            this.advicePanel.Controls.Add(this.ratingButton);
            this.advicePanel.Controls.Add(this.userRatingNumericUpDown);
            this.advicePanel.Controls.Add(this.onFiveLabel);
            this.advicePanel.Controls.Add(this.userRatingLabel);
            this.advicePanel.Controls.Add(this.ratingTitleLabel);
            this.advicePanel.Controls.Add(this.anotherLabel);
            this.advicePanel.Controls.Add(this.nextBeerButton);
            this.advicePanel.Controls.Add(this.previousBeerButton);
            this.advicePanel.Controls.Add(this.beerDescriptionPanel);
            this.advicePanel.Controls.Add(this.resultSrmValueLabel);
            this.advicePanel.Controls.Add(this.resultIbuValueLabel);
            this.advicePanel.Controls.Add(this.resultAbvValueLabel);
            this.advicePanel.Controls.Add(this.resultSrmLabel);
            this.advicePanel.Controls.Add(this.resultIbuLabel);
            this.advicePanel.Controls.Add(this.resultAbvLabel);
            this.advicePanel.Controls.Add(this.resutlTitleLabel);
            this.advicePanel.Controls.Add(this.beerPictureBox);
            this.advicePanel.Controls.Add(this.beerNameLabel);
            this.advicePanel.Location = new System.Drawing.Point(12, 51);
            this.advicePanel.Name = "advicePanel";
            this.advicePanel.Size = new System.Drawing.Size(360, 337);
            this.advicePanel.TabIndex = 5;
            // 
            // helpConditionButton
            // 
            this.helpConditionButton.BackColor = System.Drawing.Color.SteelBlue;
            this.helpConditionButton.Location = new System.Drawing.Point(4, 298);
            this.helpConditionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.helpConditionButton.Name = "helpConditionButton";
            this.helpConditionButton.Size = new System.Drawing.Size(33, 33);
            this.helpConditionButton.TabIndex = 37;
            this.helpConditionButton.Text = "?";
            this.helpConditionButton.UseVisualStyleBackColor = false;
            this.helpConditionButton.Click += new System.EventHandler(this.helpConditionButton_Click);
            // 
            // ratingButton
            // 
            this.ratingButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ratingButton.Location = new System.Drawing.Point(227, 257);
            this.ratingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ratingButton.Name = "ratingButton";
            this.ratingButton.Size = new System.Drawing.Size(108, 33);
            this.ratingButton.TabIndex = 25;
            this.ratingButton.Text = "Rate it !";
            this.ratingButton.UseVisualStyleBackColor = false;
            this.ratingButton.Visible = false;
            this.ratingButton.Click += new System.EventHandler(this.ratingButton_Click);
            // 
            // userRatingNumericUpDown
            // 
            this.userRatingNumericUpDown.DecimalPlaces = 2;
            this.userRatingNumericUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.userRatingNumericUpDown.Location = new System.Drawing.Point(230, 228);
            this.userRatingNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.userRatingNumericUpDown.Name = "userRatingNumericUpDown";
            this.userRatingNumericUpDown.Size = new System.Drawing.Size(48, 22);
            this.userRatingNumericUpDown.TabIndex = 24;
            this.userRatingNumericUpDown.Visible = false;
            // 
            // onFiveLabel
            // 
            this.onFiveLabel.AutoSize = true;
            this.onFiveLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onFiveLabel.Location = new System.Drawing.Point(284, 230);
            this.onFiveLabel.Name = "onFiveLabel";
            this.onFiveLabel.Size = new System.Drawing.Size(23, 16);
            this.onFiveLabel.TabIndex = 23;
            this.onFiveLabel.Text = "/ 5";
            // 
            // userRatingLabel
            // 
            this.userRatingLabel.AutoSize = true;
            this.userRatingLabel.Location = new System.Drawing.Point(252, 228);
            this.userRatingLabel.Name = "userRatingLabel";
            this.userRatingLabel.Size = new System.Drawing.Size(15, 16);
            this.userRatingLabel.TabIndex = 22;
            this.userRatingLabel.Text = "X";
            this.userRatingLabel.Visible = false;
            // 
            // ratingTitleLabel
            // 
            this.ratingTitleLabel.AutoSize = true;
            this.ratingTitleLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingTitleLabel.Location = new System.Drawing.Point(227, 209);
            this.ratingTitleLabel.Name = "ratingTitleLabel";
            this.ratingTitleLabel.Size = new System.Drawing.Size(85, 16);
            this.ratingTitleLabel.TabIndex = 21;
            this.ratingTitleLabel.Text = "Your rating :";
            // 
            // anotherLabel
            // 
            this.anotherLabel.AutoSize = true;
            this.anotherLabel.Location = new System.Drawing.Point(252, 306);
            this.anotherLabel.Name = "anotherLabel";
            this.anotherLabel.Size = new System.Drawing.Size(60, 16);
            this.anotherLabel.TabIndex = 20;
            this.anotherLabel.Text = "Another !";
            // 
            // nextBeerButton
            // 
            this.nextBeerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.nextBeerButton.Enabled = false;
            this.nextBeerButton.Location = new System.Drawing.Point(321, 298);
            this.nextBeerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nextBeerButton.Name = "nextBeerButton";
            this.nextBeerButton.Size = new System.Drawing.Size(33, 33);
            this.nextBeerButton.TabIndex = 19;
            this.nextBeerButton.Text = ">";
            this.nextBeerButton.UseVisualStyleBackColor = false;
            this.nextBeerButton.Click += new System.EventHandler(this.nextBeerButton_Click);
            // 
            // previousBeerButton
            // 
            this.previousBeerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.previousBeerButton.Enabled = false;
            this.previousBeerButton.Location = new System.Drawing.Point(213, 298);
            this.previousBeerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previousBeerButton.Name = "previousBeerButton";
            this.previousBeerButton.Size = new System.Drawing.Size(33, 33);
            this.previousBeerButton.TabIndex = 18;
            this.previousBeerButton.Text = "<";
            this.previousBeerButton.UseVisualStyleBackColor = false;
            this.previousBeerButton.Click += new System.EventHandler(this.previousBeerButton_Click);
            // 
            // beerDescriptionPanel
            // 
            this.beerDescriptionPanel.AutoScroll = true;
            this.beerDescriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.beerDescriptionPanel.Controls.Add(this.beerDescriptionLabel);
            this.beerDescriptionPanel.Location = new System.Drawing.Point(6, 53);
            this.beerDescriptionPanel.Name = "beerDescriptionPanel";
            this.beerDescriptionPanel.Size = new System.Drawing.Size(200, 77);
            this.beerDescriptionPanel.TabIndex = 17;
            // 
            // beerDescriptionLabel
            // 
            this.beerDescriptionLabel.AutoSize = true;
            this.beerDescriptionLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beerDescriptionLabel.Location = new System.Drawing.Point(3, 4);
            this.beerDescriptionLabel.MaximumSize = new System.Drawing.Size(175, 0);
            this.beerDescriptionLabel.Name = "beerDescriptionLabel";
            this.beerDescriptionLabel.Size = new System.Drawing.Size(131, 16);
            this.beerDescriptionLabel.TabIndex = 10;
            this.beerDescriptionLabel.Text = "beerDescriptionLabel";
            this.beerDescriptionLabel.Visible = false;
            // 
            // resultSrmValueLabel
            // 
            this.resultSrmValueLabel.AutoSize = true;
            this.resultSrmValueLabel.Location = new System.Drawing.Point(135, 246);
            this.resultSrmValueLabel.Name = "resultSrmValueLabel";
            this.resultSrmValueLabel.Size = new System.Drawing.Size(30, 16);
            this.resultSrmValueLabel.TabIndex = 16;
            this.resultSrmValueLabel.Text = "srm";
            this.resultSrmValueLabel.Visible = false;
            // 
            // resultIbuValueLabel
            // 
            this.resultIbuValueLabel.AutoSize = true;
            this.resultIbuValueLabel.Location = new System.Drawing.Point(135, 219);
            this.resultIbuValueLabel.Name = "resultIbuValueLabel";
            this.resultIbuValueLabel.Size = new System.Drawing.Size(25, 16);
            this.resultIbuValueLabel.TabIndex = 15;
            this.resultIbuValueLabel.Text = "ibu";
            this.resultIbuValueLabel.Visible = false;
            // 
            // resultAbvValueLabel
            // 
            this.resultAbvValueLabel.AutoSize = true;
            this.resultAbvValueLabel.Location = new System.Drawing.Point(135, 191);
            this.resultAbvValueLabel.Name = "resultAbvValueLabel";
            this.resultAbvValueLabel.Size = new System.Drawing.Size(27, 16);
            this.resultAbvValueLabel.TabIndex = 14;
            this.resultAbvValueLabel.Text = "abv";
            this.resultAbvValueLabel.Visible = false;
            // 
            // resultSrmLabel
            // 
            this.resultSrmLabel.AutoSize = true;
            this.resultSrmLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultSrmLabel.Location = new System.Drawing.Point(3, 246);
            this.resultSrmLabel.Name = "resultSrmLabel";
            this.resultSrmLabel.Size = new System.Drawing.Size(99, 16);
            this.resultSrmLabel.TabIndex = 13;
            this.resultSrmLabel.Text = "SRM (Colour) :";
            // 
            // resultIbuLabel
            // 
            this.resultIbuLabel.AutoSize = true;
            this.resultIbuLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultIbuLabel.Location = new System.Drawing.Point(3, 219);
            this.resultIbuLabel.Name = "resultIbuLabel";
            this.resultIbuLabel.Size = new System.Drawing.Size(112, 16);
            this.resultIbuLabel.TabIndex = 12;
            this.resultIbuLabel.Text = "IBU (Bitterness) :";
            // 
            // resultAbvLabel
            // 
            this.resultAbvLabel.AutoSize = true;
            this.resultAbvLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultAbvLabel.Location = new System.Drawing.Point(3, 191);
            this.resultAbvLabel.Name = "resultAbvLabel";
            this.resultAbvLabel.Size = new System.Drawing.Size(136, 16);
            this.resultAbvLabel.TabIndex = 11;
            this.resultAbvLabel.Text = "Alcohol By Volume :";
            // 
            // resutlTitleLabel
            // 
            this.resutlTitleLabel.AutoSize = true;
            this.resutlTitleLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resutlTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.resutlTitleLabel.Name = "resutlTitleLabel";
            this.resutlTitleLabel.Size = new System.Drawing.Size(54, 18);
            this.resutlTitleLabel.TabIndex = 9;
            this.resutlTitleLabel.Text = "Result";
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
            // beerNameLabel
            // 
            this.beerNameLabel.AutoEllipsis = true;
            this.beerNameLabel.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beerNameLabel.Location = new System.Drawing.Point(3, 32);
            this.beerNameLabel.Name = "beerNameLabel";
            this.beerNameLabel.Size = new System.Drawing.Size(218, 16);
            this.beerNameLabel.TabIndex = 2;
            this.beerNameLabel.Text = "beerNameLabel";
            this.beerNameLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.quitButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.nameSearchTextBox);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 33);
            this.panel1.TabIndex = 6;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.quitButton.Location = new System.Drawing.Point(294, -1);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(65, 33);
            this.quitButton.TabIndex = 22;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.Location = new System.Drawing.Point(229, -1);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(65, 33);
            this.searchButton.TabIndex = 21;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // nameSearchTextBox
            // 
            this.nameSearchTextBox.Location = new System.Drawing.Point(3, 3);
            this.nameSearchTextBox.Name = "nameSearchTextBox";
            this.nameSearchTextBox.Size = new System.Drawing.Size(217, 22);
            this.nameSearchTextBox.TabIndex = 12;
            // 
            // modificationButton
            // 
            this.modificationButton.BackColor = System.Drawing.Color.SteelBlue;
            this.modificationButton.Enabled = false;
            this.modificationButton.Location = new System.Drawing.Point(12, 395);
            this.modificationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.modificationButton.Name = "modificationButton";
            this.modificationButton.Size = new System.Drawing.Size(163, 68);
            this.modificationButton.TabIndex = 38;
            this.modificationButton.Text = "Propose modification on this beer";
            this.modificationButton.UseVisualStyleBackColor = false;
            this.modificationButton.Click += new System.EventHandler(this.modificationButton_Click);
            // 
            // newBeerButton
            // 
            this.newBeerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.newBeerButton.Location = new System.Drawing.Point(209, 395);
            this.newBeerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newBeerButton.Name = "newBeerButton";
            this.newBeerButton.Size = new System.Drawing.Size(163, 68);
            this.newBeerButton.TabIndex = 40;
            this.newBeerButton.Text = "Can\'t find the beer you\'re looking for ? add it !";
            this.newBeerButton.UseVisualStyleBackColor = false;
            this.newBeerButton.Click += new System.EventHandler(this.newBeerButton_Click);
            // 
            // sepLabel
            // 
            this.sepLabel.AutoSize = true;
            this.sepLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sepLabel.Location = new System.Drawing.Point(161, 155);
            this.sepLabel.Name = "sepLabel";
            this.sepLabel.Size = new System.Drawing.Size(13, 19);
            this.sepLabel.TabIndex = 41;
            this.sepLabel.Text = "/";
            // 
            // categoryTitleLabel
            // 
            this.categoryTitleLabel.AutoSize = true;
            this.categoryTitleLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryTitleLabel.Location = new System.Drawing.Point(1, 133);
            this.categoryTitleLabel.Name = "categoryTitleLabel";
            this.categoryTitleLabel.Size = new System.Drawing.Size(106, 16);
            this.categoryTitleLabel.TabIndex = 38;
            this.categoryTitleLabel.Text = "Category / style";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoEllipsis = true;
            this.categoryLabel.Location = new System.Drawing.Point(15, 158);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(140, 33);
            this.categoryLabel.TabIndex = 42;
            this.categoryLabel.Text = "label1";
            this.categoryLabel.Visible = false;
            // 
            // styleLabel
            // 
            this.styleLabel.AutoEllipsis = true;
            this.styleLabel.Location = new System.Drawing.Point(180, 158);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(140, 33);
            this.styleLabel.TabIndex = 43;
            this.styleLabel.Text = "label1";
            this.styleLabel.Visible = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(385, 476);
            this.Controls.Add(this.newBeerButton);
            this.Controls.Add(this.modificationButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.advicePanel);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.advicePanel.ResumeLayout(false);
            this.advicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userRatingNumericUpDown)).EndInit();
            this.beerDescriptionPanel.ResumeLayout(false);
            this.beerDescriptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beerPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel advicePanel;
        private System.Windows.Forms.Label anotherLabel;
        private System.Windows.Forms.Button nextBeerButton;
        private System.Windows.Forms.Button previousBeerButton;
        private System.Windows.Forms.Panel beerDescriptionPanel;
        private System.Windows.Forms.Label beerDescriptionLabel;
        private System.Windows.Forms.Label resultSrmValueLabel;
        private System.Windows.Forms.Label resultIbuValueLabel;
        private System.Windows.Forms.Label resultAbvValueLabel;
        private System.Windows.Forms.Label resultSrmLabel;
        private System.Windows.Forms.Label resultIbuLabel;
        private System.Windows.Forms.Label resultAbvLabel;
        private System.Windows.Forms.Label resutlTitleLabel;
        private System.Windows.Forms.PictureBox beerPictureBox;
        private System.Windows.Forms.Label beerNameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nameSearchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label ratingTitleLabel;
        private System.Windows.Forms.Label userRatingLabel;
        private System.Windows.Forms.Label onFiveLabel;
        private System.Windows.Forms.NumericUpDown userRatingNumericUpDown;
        private System.Windows.Forms.Button ratingButton;
        private System.Windows.Forms.Button helpConditionButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button modificationButton;
        private System.Windows.Forms.Button newBeerButton;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label sepLabel;
        private System.Windows.Forms.Label categoryTitleLabel;
        private System.Windows.Forms.Label styleLabel;
    }
}