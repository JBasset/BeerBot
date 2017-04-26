namespace AleVisor
{
    partial class RequestForm
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
            this.resetButton = new System.Windows.Forms.Button();
            this.srmCheckLabel = new System.Windows.Forms.Label();
            this.ibuCheckLabel = new System.Windows.Forms.Label();
            this.abvCheckLabel = new System.Windows.Forms.Label();
            this.descriptionCheckLabel = new System.Windows.Forms.Label();
            this.beerNameCheckLabel = new System.Windows.Forms.Label();
            this.srmNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ibuNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.abvNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.beernameTextBox = new System.Windows.Forms.TextBox();
            this.helpConditionButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.resultSrmLabel = new System.Windows.Forms.Label();
            this.resultIbuLabel = new System.Windows.Forms.Label();
            this.resultAbvLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryConditionLabel = new System.Windows.Forms.Label();
            this.categoryCheckLabel = new System.Windows.Forms.Label();
            this.styleCheckLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.advicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srmNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abvNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // advicePanel
            // 
            this.advicePanel.BackColor = System.Drawing.Color.SlateGray;
            this.advicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.advicePanel.Controls.Add(this.errorLabel);
            this.advicePanel.Controls.Add(this.styleCheckLabel);
            this.advicePanel.Controls.Add(this.categoryCheckLabel);
            this.advicePanel.Controls.Add(this.styleComboBox);
            this.advicePanel.Controls.Add(this.categoryComboBox);
            this.advicePanel.Controls.Add(this.categoryConditionLabel);
            this.advicePanel.Controls.Add(this.quitButton);
            this.advicePanel.Controls.Add(this.resetButton);
            this.advicePanel.Controls.Add(this.srmCheckLabel);
            this.advicePanel.Controls.Add(this.ibuCheckLabel);
            this.advicePanel.Controls.Add(this.abvCheckLabel);
            this.advicePanel.Controls.Add(this.descriptionCheckLabel);
            this.advicePanel.Controls.Add(this.beerNameCheckLabel);
            this.advicePanel.Controls.Add(this.srmNumericUpDown);
            this.advicePanel.Controls.Add(this.ibuNumericUpDown);
            this.advicePanel.Controls.Add(this.abvNumericUpDown);
            this.advicePanel.Controls.Add(this.descriptionTextBox);
            this.advicePanel.Controls.Add(this.beernameTextBox);
            this.advicePanel.Controls.Add(this.helpConditionButton);
            this.advicePanel.Controls.Add(this.submitButton);
            this.advicePanel.Controls.Add(this.resultSrmLabel);
            this.advicePanel.Controls.Add(this.resultIbuLabel);
            this.advicePanel.Controls.Add(this.resultAbvLabel);
            this.advicePanel.Controls.Add(this.titleLabel);
            this.advicePanel.Location = new System.Drawing.Point(12, 12);
            this.advicePanel.Name = "advicePanel";
            this.advicePanel.Size = new System.Drawing.Size(430, 272);
            this.advicePanel.TabIndex = 6;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.SteelBlue;
            this.resetButton.Location = new System.Drawing.Point(302, 146);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(123, 54);
            this.resetButton.TabIndex = 48;
            this.resetButton.Text = "Reset modifications";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // srmCheckLabel
            // 
            this.srmCheckLabel.AutoSize = true;
            this.srmCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srmCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.srmCheckLabel.Location = new System.Drawing.Point(181, 191);
            this.srmCheckLabel.Name = "srmCheckLabel";
            this.srmCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.srmCheckLabel.TabIndex = 47;
            this.srmCheckLabel.Text = "X";
            this.srmCheckLabel.Visible = false;
            // 
            // ibuCheckLabel
            // 
            this.ibuCheckLabel.AutoSize = true;
            this.ibuCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibuCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ibuCheckLabel.Location = new System.Drawing.Point(181, 165);
            this.ibuCheckLabel.Name = "ibuCheckLabel";
            this.ibuCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.ibuCheckLabel.TabIndex = 46;
            this.ibuCheckLabel.Text = "X";
            this.ibuCheckLabel.Visible = false;
            // 
            // abvCheckLabel
            // 
            this.abvCheckLabel.AutoSize = true;
            this.abvCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abvCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.abvCheckLabel.Location = new System.Drawing.Point(181, 139);
            this.abvCheckLabel.Name = "abvCheckLabel";
            this.abvCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.abvCheckLabel.TabIndex = 45;
            this.abvCheckLabel.Text = "X";
            this.abvCheckLabel.Visible = false;
            // 
            // descriptionCheckLabel
            // 
            this.descriptionCheckLabel.AutoSize = true;
            this.descriptionCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.descriptionCheckLabel.Location = new System.Drawing.Point(203, 83);
            this.descriptionCheckLabel.Name = "descriptionCheckLabel";
            this.descriptionCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.descriptionCheckLabel.TabIndex = 44;
            this.descriptionCheckLabel.Text = "X";
            this.descriptionCheckLabel.Visible = false;
            // 
            // beerNameCheckLabel
            // 
            this.beerNameCheckLabel.AutoSize = true;
            this.beerNameCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beerNameCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.beerNameCheckLabel.Location = new System.Drawing.Point(203, 30);
            this.beerNameCheckLabel.Name = "beerNameCheckLabel";
            this.beerNameCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.beerNameCheckLabel.TabIndex = 43;
            this.beerNameCheckLabel.Text = "X";
            this.beerNameCheckLabel.Visible = false;
            // 
            // srmNumericUpDown
            // 
            this.srmNumericUpDown.Location = new System.Drawing.Point(138, 189);
            this.srmNumericUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.srmNumericUpDown.Name = "srmNumericUpDown";
            this.srmNumericUpDown.Size = new System.Drawing.Size(37, 22);
            this.srmNumericUpDown.TabIndex = 42;
            this.srmNumericUpDown.ValueChanged += new System.EventHandler(this.srmNumericUpDown_ValueChanged);
            // 
            // ibuNumericUpDown
            // 
            this.ibuNumericUpDown.Location = new System.Drawing.Point(138, 163);
            this.ibuNumericUpDown.Name = "ibuNumericUpDown";
            this.ibuNumericUpDown.Size = new System.Drawing.Size(37, 22);
            this.ibuNumericUpDown.TabIndex = 41;
            this.ibuNumericUpDown.ValueChanged += new System.EventHandler(this.ibuNumericUpDown_ValueChanged);
            // 
            // abvNumericUpDown
            // 
            this.abvNumericUpDown.DecimalPlaces = 1;
            this.abvNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.abvNumericUpDown.Location = new System.Drawing.Point(138, 137);
            this.abvNumericUpDown.Name = "abvNumericUpDown";
            this.abvNumericUpDown.Size = new System.Drawing.Size(37, 22);
            this.abvNumericUpDown.TabIndex = 40;
            this.abvNumericUpDown.ValueChanged += new System.EventHandler(this.abvNumericUpDown_ValueChanged);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(6, 56);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(191, 74);
            this.descriptionTextBox.TabIndex = 39;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            // 
            // beernameTextBox
            // 
            this.beernameTextBox.Location = new System.Drawing.Point(6, 27);
            this.beernameTextBox.Name = "beernameTextBox";
            this.beernameTextBox.Size = new System.Drawing.Size(191, 22);
            this.beernameTextBox.TabIndex = 38;
            this.beernameTextBox.TextChanged += new System.EventHandler(this.beernameTextBox_TextChanged);
            // 
            // helpConditionButton
            // 
            this.helpConditionButton.BackColor = System.Drawing.Color.SteelBlue;
            this.helpConditionButton.Location = new System.Drawing.Point(3, 232);
            this.helpConditionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.helpConditionButton.Name = "helpConditionButton";
            this.helpConditionButton.Size = new System.Drawing.Size(33, 33);
            this.helpConditionButton.TabIndex = 37;
            this.helpConditionButton.Text = "?";
            this.helpConditionButton.UseVisualStyleBackColor = false;
            this.helpConditionButton.Click += new System.EventHandler(this.helpConditionButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.submitButton.Location = new System.Drawing.Point(302, 214);
            this.submitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(123, 54);
            this.submitButton.TabIndex = 25;
            this.submitButton.Text = "Submit modification";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // resultSrmLabel
            // 
            this.resultSrmLabel.AutoSize = true;
            this.resultSrmLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultSrmLabel.Location = new System.Drawing.Point(3, 191);
            this.resultSrmLabel.Name = "resultSrmLabel";
            this.resultSrmLabel.Size = new System.Drawing.Size(99, 16);
            this.resultSrmLabel.TabIndex = 13;
            this.resultSrmLabel.Text = "SRM (Colour) :";
            // 
            // resultIbuLabel
            // 
            this.resultIbuLabel.AutoSize = true;
            this.resultIbuLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultIbuLabel.Location = new System.Drawing.Point(3, 165);
            this.resultIbuLabel.Name = "resultIbuLabel";
            this.resultIbuLabel.Size = new System.Drawing.Size(112, 16);
            this.resultIbuLabel.TabIndex = 12;
            this.resultIbuLabel.Text = "IBU (Bitterness) :";
            // 
            // resultAbvLabel
            // 
            this.resultAbvLabel.AutoSize = true;
            this.resultAbvLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultAbvLabel.Location = new System.Drawing.Point(3, 139);
            this.resultAbvLabel.Name = "resultAbvLabel";
            this.resultAbvLabel.Size = new System.Drawing.Size(136, 16);
            this.resultAbvLabel.TabIndex = 11;
            this.resultAbvLabel.Text = "Alcohol By Volume :";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(139, 18);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Your modification :";
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.quitButton.Location = new System.Drawing.Point(42, 232);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(60, 33);
            this.quitButton.TabIndex = 49;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(248, 76);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(150, 24);
            this.styleComboBox.TabIndex = 52;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(248, 46);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(150, 24);
            this.categoryComboBox.TabIndex = 51;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // categoryConditionLabel
            // 
            this.categoryConditionLabel.AutoSize = true;
            this.categoryConditionLabel.Location = new System.Drawing.Point(259, 27);
            this.categoryConditionLabel.Name = "categoryConditionLabel";
            this.categoryConditionLabel.Size = new System.Drawing.Size(100, 16);
            this.categoryConditionLabel.TabIndex = 50;
            this.categoryConditionLabel.Text = "Category / style";
            // 
            // categoryCheckLabel
            // 
            this.categoryCheckLabel.AutoSize = true;
            this.categoryCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.categoryCheckLabel.Location = new System.Drawing.Point(404, 49);
            this.categoryCheckLabel.Name = "categoryCheckLabel";
            this.categoryCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.categoryCheckLabel.TabIndex = 53;
            this.categoryCheckLabel.Text = "X";
            this.categoryCheckLabel.Visible = false;
            // 
            // styleCheckLabel
            // 
            this.styleCheckLabel.AutoSize = true;
            this.styleCheckLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleCheckLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.styleCheckLabel.Location = new System.Drawing.Point(404, 79);
            this.styleCheckLabel.Name = "styleCheckLabel";
            this.styleCheckLabel.Size = new System.Drawing.Size(17, 16);
            this.styleCheckLabel.TabIndex = 54;
            this.styleCheckLabel.Text = "X";
            this.styleCheckLabel.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(203, 214);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(93, 51);
            this.errorLabel.TabIndex = 55;
            this.errorLabel.Text = "At lest the beer name must be given";
            this.errorLabel.Visible = false;
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(454, 294);
            this.Controls.Add(this.advicePanel);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RequestForm";
            this.Text = "RequestForm";
            this.advicePanel.ResumeLayout(false);
            this.advicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srmNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibuNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abvNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel advicePanel;
        private System.Windows.Forms.Button helpConditionButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label resultSrmLabel;
        private System.Windows.Forms.Label resultIbuLabel;
        private System.Windows.Forms.Label resultAbvLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox beernameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.NumericUpDown srmNumericUpDown;
        private System.Windows.Forms.NumericUpDown ibuNumericUpDown;
        private System.Windows.Forms.NumericUpDown abvNumericUpDown;
        private System.Windows.Forms.Label beerNameCheckLabel;
        private System.Windows.Forms.Label descriptionCheckLabel;
        private System.Windows.Forms.Label srmCheckLabel;
        private System.Windows.Forms.Label ibuCheckLabel;
        private System.Windows.Forms.Label abvCheckLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryConditionLabel;
        private System.Windows.Forms.Label styleCheckLabel;
        private System.Windows.Forms.Label categoryCheckLabel;
        private System.Windows.Forms.Label errorLabel;
    }
}