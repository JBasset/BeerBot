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
        public OpenBeerDB database;
        public User loggedUser;

        public static int userId;
        public static string userName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            AddOwnedForm(connectionForm);
            connectionForm.Show();
            connectionForm.Disposed += ConnectionForm_Disposed;
        }

        private void ConnectionForm_Disposed(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                string msg = "Pas d'utilisateur connecté, fermeture de l'application.";
                string caption = "Erreur";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult msgBox = MessageBox.Show(msg, caption, button);
                Close();
            }
            else
            {
                label1.Text = loggedUser.name;
            }
        }
    }
}
