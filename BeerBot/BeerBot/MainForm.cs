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
        public BeerPrologEngine engine;
        public OpenBeerDB database;
        public User loggedUser;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // connection of a user
            ConnectionForm connectionForm = new ConnectionForm();
            AddOwnedForm(connectionForm);
            connectionForm.Show();
            connectionForm.Disposed += ConnectionForm_Disposed;

            userLogoPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\user.png");
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
                userNameLabel.Text = loggedUser.name;
                userNameLabel.Visible = true;
                engine = new BeerPrologEngine(database);
                this.Enabled = true;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logOffButton_Click(object sender, EventArgs e)
        {
            loggedUser = null;
            userNameLabel.Visible = false;
            this.Enabled = false;
            ConnectionForm connectionForm = new ConnectionForm();
            AddOwnedForm(connectionForm);
            connectionForm.Show();
            connectionForm.Disposed += ConnectionForm_Disposed;
        }

        private void beerAdviceButton_Click(object sender, EventArgs e)
        {
            List<string> result = engine.adviceOnKind(loggedUser);
            beerNameLabel.Text = result[0];
        }
    }
}
