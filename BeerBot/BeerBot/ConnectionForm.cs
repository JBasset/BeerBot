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
    public partial class ConnectionForm : Form
    {
        private OpenBeerDB db = new OpenBeerDB();
        private User loggedUser;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            bool passwordError = false;
            foreach(User user in db.users)
            {
                if (usernameTextBox.Text == user.name)
                {
                    if (passwordTextBox.Text == user.password)
                        loggedUser = user;
                    else
                    {
                        errorLabel.Text = "Le mot de passe ne correspond pas";
                        errorLabel.Visible = true;
                        passwordError = true;
                    }
                    break;
                }
            }
            if (loggedUser == null && !passwordError) // if the logged user isn't defined, and it's not because the password is wrong
            {
                errorLabel.Text = "Cet utilisateur n'existe pas";
                errorLabel.Visible = true;
            }
            else
            {
                MainForm.database = db;
                MainForm.loggedUser = loggedUser;
                this.Close();
            }
        }

        private void inscriptionButton_Click(object sender, EventArgs e)
        {
            InscriptionForm inscrForm = new InscriptionForm();
            inscrForm.Show();
        }
    }
}
