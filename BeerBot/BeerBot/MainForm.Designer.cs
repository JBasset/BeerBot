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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.userPanel = new System.Windows.Forms.Panel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.logOffButton = new System.Windows.Forms.Button();
            this.beerAdviceButton = new System.Windows.Forms.Button();
            this.beerNameLabel = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userLogoPictureBox)).BeginInit();
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
            this.userPanel.Size = new System.Drawing.Size(865, 54);
            this.userPanel.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(531, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(128, 50);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "X";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userNameLabel.Visible = false;
            // 
            // userLogoPictureBox
            // 
            this.userLogoPictureBox.Location = new System.Drawing.Point(666, -2);
            this.userLogoPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userLogoPictureBox.Name = "userLogoPictureBox";
            this.userLogoPictureBox.Size = new System.Drawing.Size(52, 55);
            this.userLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userLogoPictureBox.TabIndex = 0;
            this.userLogoPictureBox.TabStop = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.quitButton.Location = new System.Drawing.Point(726, 25);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(132, 28);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quitter";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // logOffButton
            // 
            this.logOffButton.BackColor = System.Drawing.Color.SteelBlue;
            this.logOffButton.Location = new System.Drawing.Point(726, -2);
            this.logOffButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logOffButton.Name = "logOffButton";
            this.logOffButton.Size = new System.Drawing.Size(132, 28);
            this.logOffButton.TabIndex = 2;
            this.logOffButton.Text = "Se déconnecter";
            this.logOffButton.UseVisualStyleBackColor = false;
            this.logOffButton.Click += new System.EventHandler(this.logOffButton_Click);
            // 
            // beerAdviceButton
            // 
            this.beerAdviceButton.BackColor = System.Drawing.Color.SteelBlue;
            this.beerAdviceButton.Image = ((System.Drawing.Image)(resources.GetObject("beerAdviceButton.Image")));
            this.beerAdviceButton.Location = new System.Drawing.Point(14, 78);
            this.beerAdviceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beerAdviceButton.Name = "beerAdviceButton";
            this.beerAdviceButton.Size = new System.Drawing.Size(308, 325);
            this.beerAdviceButton.TabIndex = 1;
            this.beerAdviceButton.UseVisualStyleBackColor = false;
            this.beerAdviceButton.Click += new System.EventHandler(this.beerAdviceButton_Click);
            // 
            // beerNameLabel
            // 
            this.beerNameLabel.AutoSize = true;
            this.beerNameLabel.Location = new System.Drawing.Point(355, 137);
            this.beerNameLabel.Name = "beerNameLabel";
            this.beerNameLabel.Size = new System.Drawing.Size(42, 16);
            this.beerNameLabel.TabIndex = 2;
            this.beerNameLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(894, 475);
            this.Controls.Add(this.beerNameLabel);
            this.Controls.Add(this.beerAdviceButton);
            this.Controls.Add(this.userPanel);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.userPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.PictureBox userLogoPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button logOffButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button beerAdviceButton;
        private System.Windows.Forms.Label beerNameLabel;
    }
}