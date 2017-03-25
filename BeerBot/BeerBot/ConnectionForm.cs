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

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            User loggedUser = new User(0, "default", "", 1995, false, "default" );
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
            if (loggedUser.id == 0 && !passwordError) // if the logged user isn't defined
            {
                errorLabel.Text = "Cet utilisateur n'existe pas";
                errorLabel.Visible = true;
            }
            else
            {
                MainForm mainForm = new MainForm();
                Close();
            }
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
