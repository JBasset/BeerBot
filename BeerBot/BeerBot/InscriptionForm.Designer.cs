namespace BeerBot
{
    partial class InscriptionForm
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
            this.logoPanel = new System.Windows.Forms.Panel();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.repeatPasswordTextBox = new System.Windows.Forms.TextBox();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.inscriptionButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.passwordErrorLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.birthYearLabel = new System.Windows.Forms.Label();
            this.birthYeaComboBox = new System.Windows.Forms.ComboBox();
            this.connectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.DarkGray;
            this.logoPanel.Location = new System.Drawing.Point(60, 30);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(183, 268);
            this.logoPanel.TabIndex = 3;
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.SlateGray;
            this.connectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.connectionPanel.Controls.Add(this.birthYeaComboBox);
            this.connectionPanel.Controls.Add(this.birthYearLabel);
            this.connectionPanel.Controls.Add(this.genderComboBox);
            this.connectionPanel.Controls.Add(this.genderLabel);
            this.connectionPanel.Controls.Add(this.passwordErrorLabel);
            this.connectionPanel.Controls.Add(this.repeatPasswordTextBox);
            this.connectionPanel.Controls.Add(this.repeatPasswordLabel);
            this.connectionPanel.Controls.Add(this.errorLabel);
            this.connectionPanel.Controls.Add(this.inscriptionButton);
            this.connectionPanel.Controls.Add(this.passwordTextBox);
            this.connectionPanel.Controls.Add(this.passwordLabel);
            this.connectionPanel.Controls.Add(this.usernameTextBox);
            this.connectionPanel.Controls.Add(this.usernameLabel);
            this.connectionPanel.Controls.Add(this.titleLabel);
            this.connectionPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionPanel.ForeColor = System.Drawing.Color.White;
            this.connectionPanel.Location = new System.Drawing.Point(238, 30);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(301, 268);
            this.connectionPanel.TabIndex = 2;
            // 
            // repeatPasswordTextBox
            // 
            this.repeatPasswordTextBox.Location = new System.Drawing.Point(42, 132);
            this.repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            this.repeatPasswordTextBox.PasswordChar = '*';
            this.repeatPasswordTextBox.Size = new System.Drawing.Size(142, 22);
            this.repeatPasswordTextBox.TabIndex = 9;
            // 
            // repeatPasswordLabel
            // 
            this.repeatPasswordLabel.AutoSize = true;
            this.repeatPasswordLabel.Location = new System.Drawing.Point(9, 113);
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            this.repeatPasswordLabel.Size = new System.Drawing.Size(158, 16);
            this.repeatPasswordLabel.TabIndex = 8;
            this.repeatPasswordLabel.Text = "Repeter le mot de passe :";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorLabel.Location = new System.Drawing.Point(9, 225);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(34, 16);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            // 
            // inscriptionButton
            // 
            this.inscriptionButton.BackColor = System.Drawing.Color.SteelBlue;
            this.inscriptionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.inscriptionButton.ForeColor = System.Drawing.Color.White;
            this.inscriptionButton.Location = new System.Drawing.Point(190, 216);
            this.inscriptionButton.Name = "inscriptionButton";
            this.inscriptionButton.Size = new System.Drawing.Size(104, 35);
            this.inscriptionButton.TabIndex = 6;
            this.inscriptionButton.Text = "M\'inscrire";
            this.inscriptionButton.UseVisualStyleBackColor = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(42, 88);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(142, 22);
            this.passwordTextBox.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(9, 69);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(95, 16);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Mot de passe :";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(42, 44);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(142, 22);
            this.usernameTextBox.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(9, 25);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(112, 16);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Nom d\'utilisateur :";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(74, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Inscription";
            // 
            // passwordErrorLabel
            // 
            this.passwordErrorLabel.AutoSize = true;
            this.passwordErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passwordErrorLabel.Location = new System.Drawing.Point(204, 88);
            this.passwordErrorLabel.Name = "passwordErrorLabel";
            this.passwordErrorLabel.Size = new System.Drawing.Size(90, 64);
            this.passwordErrorLabel.TabIndex = 10;
            this.passwordErrorLabel.Text = "Les mots de\r\npasse ne\r\ncorrespondent\r\npas";
            this.passwordErrorLabel.Visible = false;
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(9, 157);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(46, 16);
            this.genderLabel.TabIndex = 11;
            this.genderLabel.Text = "Sexe :";
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "H",
            "F"});
            this.genderComboBox.Location = new System.Drawing.Point(42, 177);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(35, 24);
            this.genderComboBox.TabIndex = 12;
            // 
            // birthYearLabel
            // 
            this.birthYearLabel.AutoSize = true;
            this.birthYearLabel.Location = new System.Drawing.Point(83, 157);
            this.birthYearLabel.Name = "birthYearLabel";
            this.birthYearLabel.Size = new System.Drawing.Size(65, 16);
            this.birthYearLabel.TabIndex = 13;
            this.birthYearLabel.Text = "Né(e) en :";
            // 
            // birthYeaComboBox
            // 
            this.birthYeaComboBox.FormattingEnabled = true;
            this.birthYeaComboBox.Location = new System.Drawing.Point(105, 177);
            this.birthYeaComboBox.Name = "birthYeaComboBox";
            this.birthYeaComboBox.Size = new System.Drawing.Size(79, 24);
            this.birthYeaComboBox.TabIndex = 14;
            // 
            // InscriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(584, 326);
            this.Controls.Add(this.logoPanel);
            this.Controls.Add(this.connectionPanel);
            this.Name = "InscriptionForm";
            this.Text = "InscriptionForm";
            this.Load += new System.EventHandler(this.InscriptionForm_Load);
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button inscriptionButton;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordTextBox;
        private System.Windows.Forms.Label passwordErrorLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label birthYearLabel;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.ComboBox birthYeaComboBox;
    }
}