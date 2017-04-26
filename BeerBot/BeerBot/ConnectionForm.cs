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

namespace AleVisor
{
    public partial class ConnectionForm : Form
    {
        public OpenBeerDB db = new OpenBeerDB();
        public User loggedUser;

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
                        passwordError = true;
                    break;
                }
            }
            if (passwordError)
            {
                errorLabel.Text = "The password doesn't match";
                errorLabel.Visible = true;
            }
            else if (loggedUser == null)
            {
                errorLabel.Text = "This user doesn't exist";
                errorLabel.Visible = true;
            }
            else
            {
                (Owner as MainForm).database = db;
                (Owner as MainForm).loggedUser = loggedUser;
                Close();
            }
        }

        private void inscriptionButton_Click(object sender, EventArgs e)
        {
            RegistrationForm inscrForm = new RegistrationForm();
            AddOwnedForm(inscrForm);
            inscrForm.Disposed += InscriptionForm_Disposed;
            inscrForm.Show();
        }

        private void InscriptionForm_Disposed(object sender, EventArgs e)
        {
            if (loggedUser != null)
            {
                (Owner as MainForm).database = db;
                (Owner as MainForm).loggedUser = loggedUser;
                Close();
            }
        }
    }
}
