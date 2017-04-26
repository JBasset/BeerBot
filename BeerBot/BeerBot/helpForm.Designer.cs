namespace AleVisor
{
    partial class helpForm
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
            this.helpTitleLabel = new System.Windows.Forms.Label();
            this.abvLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.srmPictureBox = new System.Windows.Forms.PictureBox();
            this.quitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.srmPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // helpTitleLabel
            // 
            this.helpTitleLabel.AutoSize = true;
            this.helpTitleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTitleLabel.Location = new System.Drawing.Point(65, 9);
            this.helpTitleLabel.Name = "helpTitleLabel";
            this.helpTitleLabel.Size = new System.Drawing.Size(279, 19);
            this.helpTitleLabel.TabIndex = 0;
            this.helpTitleLabel.Text = "Do you know your VocaBrewLary ?";
            // 
            // abvLabel
            // 
            this.abvLabel.AutoSize = true;
            this.abvLabel.Location = new System.Drawing.Point(12, 44);
            this.abvLabel.Name = "abvLabel";
            this.abvLabel.Size = new System.Drawing.Size(419, 32);
            this.abvLabel.TabIndex = 1;
            this.abvLabel.Text = "    - The ABV correspond to the Alcohol By Volume ; it is defined as the\r\nnumber " +
    "of millilitres of pure ethanol present in 100 millilitres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "    - IBU : International Bitterness Unit. It corresponds to the bitterness of th" +
    "e\r\nbeer ; the higher the IBU, the more bitter the beer. The average beer has an\r" +
    "\nIBU around 16.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "    - The SRM : Standard Method Reference. It corresponds to the color of\r\nthe be" +
    "er ; the higher the SRM, the darker the beer, as follows :";
            // 
            // srmPictureBox
            // 
            this.srmPictureBox.Location = new System.Drawing.Point(12, 184);
            this.srmPictureBox.Name = "srmPictureBox";
            this.srmPictureBox.Size = new System.Drawing.Size(432, 359);
            this.srmPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.srmPictureBox.TabIndex = 4;
            this.srmPictureBox.TabStop = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.SteelBlue;
            this.quitButton.Location = new System.Drawing.Point(381, 3);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(65, 33);
            this.quitButton.TabIndex = 22;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(458, 548);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.srmPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.abvLabel);
            this.Controls.Add(this.helpTitleLabel);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "helpForm";
            this.Text = "helpForm";
            ((System.ComponentModel.ISupportInitialize)(this.srmPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helpTitleLabel;
        private System.Windows.Forms.Label abvLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox srmPictureBox;
        private System.Windows.Forms.Button quitButton;
    }
}