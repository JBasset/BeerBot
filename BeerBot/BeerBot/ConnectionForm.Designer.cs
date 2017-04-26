namespace AleVisor
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.connexionButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.inscriptionButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.connectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.SlateGray;
            this.connectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.connectionPanel.Controls.Add(this.errorLabel);
            this.connectionPanel.Controls.Add(this.connexionButton);
            this.connectionPanel.Controls.Add(this.passwordTextBox);
            this.connectionPanel.Controls.Add(this.passwordLabel);
            this.connectionPanel.Controls.Add(this.usernameTextBox);
            this.connectionPanel.Controls.Add(this.usernameLabel);
            this.connectionPanel.Controls.Add(this.inscriptionButton);
            this.connectionPanel.Controls.Add(this.titleLabel);
            this.connectionPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionPanel.ForeColor = System.Drawing.Color.White;
            this.connectionPanel.Location = new System.Drawing.Point(238, 30);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(301, 268);
            this.connectionPanel.TabIndex = 0;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorLabel.Location = new System.Drawing.Point(9, 188);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(226, 16);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "User name and password don\'t match";
            this.errorLabel.Visible = false;
            // 
            // connexionButton
            // 
            this.connexionButton.BackColor = System.Drawing.Color.SteelBlue;
            this.connexionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.connexionButton.ForeColor = System.Drawing.Color.White;
            this.connexionButton.Location = new System.Drawing.Point(190, 207);
            this.connexionButton.Name = "connexionButton";
            this.connexionButton.Size = new System.Drawing.Size(104, 35);
            this.connexionButton.TabIndex = 6;
            this.connexionButton.Text = "Log in";
            this.connexionButton.UseVisualStyleBackColor = false;
            this.connexionButton.Click += new System.EventHandler(this.connexionButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(42, 151);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(183, 22);
            this.passwordTextBox.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(9, 132);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 16);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password :";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(42, 89);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(183, 22);
            this.usernameTextBox.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(9, 70);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(79, 16);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "User name :";
            // 
            // inscriptionButton
            // 
            this.inscriptionButton.BackColor = System.Drawing.Color.SteelBlue;
            this.inscriptionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.inscriptionButton.ForeColor = System.Drawing.Color.White;
            this.inscriptionButton.Location = new System.Drawing.Point(190, 3);
            this.inscriptionButton.Name = "inscriptionButton";
            this.inscriptionButton.Size = new System.Drawing.Size(104, 49);
            this.inscriptionButton.TabIndex = 1;
            this.inscriptionButton.Text = "New ?\r\nRegister now !";
            this.inscriptionButton.UseVisualStyleBackColor = false;
            this.inscriptionButton.Click += new System.EventHandler(this.inscriptionButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(6, 19);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(80, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Connection";
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.DarkGray;
            this.logoPanel.Location = new System.Drawing.Point(60, 30);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(183, 268);
            this.logoPanel.TabIndex = 1;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(584, 326);
            this.Controls.Add(this.logoPanel);
            this.Controls.Add(this.connectionPanel);
            this.Name = "ConnectionForm";
            this.Text = "Connexion";
            this.TopMost = true;
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Button inscriptionButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button connexionButton;
    }
}

