using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace BeerBot
{
    public partial class MainForm : Form
    {
        public static OpenBeerDB database;
        public static User loggedUser;

        public static int userId;
        public static string userName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.Show();
            connectionForm.FormClosing += new FormClosingEventHandler(this.ConnectionForm_FormClosing);
        }

        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loggedUser == null)
            {
                string msg = "Pas d'utilisateur connecté, fermeture de l'application.";
                string caption = "Erreur";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult msgBox = MessageBox.Show(msg, caption, button);
                this.Close();
            }
            else
            {
                label1.Text = loggedUser.name;
            }
        }
    }
}
