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
    public partial class InscriptionForm : Form
    {
        private bool passwordsChecks = false;

        public InscriptionForm()
        {
            InitializeComponent();
        }

        private void InscriptionForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                birthYearComboBox.Items.Add((DateTime.Now.Year - 100) + i);
            }

            genderComboBox.SelectedItem = genderComboBox.Items[0];
            birthYearComboBox.SelectedItem = birthYearComboBox.Items[75];
        }

        private void repeatPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            checkPasswords();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            checkPasswords();
        }

        private void checkPasswords()
        {
            if (passwordTextBox.Text != "" && repeatPasswordTextBox.Text == passwordTextBox.Text)
            {
                passwordsChecksLabel.ForeColor = Color.Green;
                passwordsChecksLabel.Text = "OK";
                passwordsChecks = true;
            }
            else
            {
                passwordsChecksLabel.ForeColor = Color.FromArgb(192, 0, 0);
                passwordsChecksLabel.Text = "X";
            }
        }

        private bool formComplete()
        {
            return usernameTextBox.Text != "" &&
                passwordTextBox.Text != "" &&
                repeatPasswordTextBox.Text != "";
        }

        private bool availableUsername()
        {
            foreach(User user in (Owner as ConnectionForm).db.users)
            {
                if (user.name == usernameTextBox.Text)
                    return false;
            }
            return true;
        }

        private void inscriptionButton_Click(object sender, EventArgs e)
        {
            if (!formComplete())
            {
                errorLabel.Text = "Veuillez completer chaque\nchamps du formulaire.";
                errorLabel.Visible = true;
            }
            else if (!availableUsername())
            {
                errorLabel.Text = "Ce nom d'utilisateur est déjà\npris.";
                errorLabel.Visible = true;
            }
            else if (!passwordsChecks)
            {
                errorLabel.Text = "Les mots de passe ne\ncorrespondent pas.";
                errorLabel.Visible = true;
            }
            else
            {
                errorLabel.Visible = false;
                string name = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string gender = (genderComboBox.SelectedText == "H") ? "0" : "1";
                string birthYear = birthYearComboBox.SelectedText;
                (Owner as ConnectionForm).db.AddUser(name, password, gender, birthYear);
                foreach (User user in (Owner as ConnectionForm).db.users)
                {
                    if (user.name == name)
                    {
                        (Owner as ConnectionForm).loggedUser = user;
                        break;
                    }
                }
                Close();
            }
        }
    }
}
