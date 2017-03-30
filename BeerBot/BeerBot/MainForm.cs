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
        /* Main form of the application. This is where the logged user can ask for an advice based on his profile and conditions he fixes */

        // adviceConditionPanel : panel where the conditions on the advice will be asked to the user
        // advicePanel : panel where the result of the advice appears

        public BeerPrologEngine engine; // the prolog engine to which the advice will be asked
        public OpenBeerDB database; // the database containing all data for the application
        public User loggedUser; // the logged user, to whom the application gives the advice

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
            beerPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\pint.png");
            arrowPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\next.png");
        }

        private void ConnectionForm_Disposed(object sender, EventArgs e)
        {
            if (loggedUser == null)
                // when the connection form closes, if no user is logged then the application can't work, so it closes too
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
            beerNameLabel.Text = "Veuillez patientier, la recherche est en cours...";
            beerNameLabel.Visible = true;
            List <Beer> result = engine.adviceOnKind(loggedUser);
            beerNameLabel.Text = result[0].name;
        }
    }
}
