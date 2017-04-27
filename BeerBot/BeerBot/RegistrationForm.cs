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
    public partial class RegistrationForm : Form
    {
        // form used to create a new user, that automatically connects when created

        private bool passwordsChecks = false;

        public RegistrationForm()
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
            // check if both passwords are the same
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
                passwordsChecks = false;
            }
        }

        private bool formComplete()
            // checks if all fields are completed
        {
            return usernameTextBox.Text != "" &&
                passwordTextBox.Text != "" &&
                repeatPasswordTextBox.Text != "";
        }

        private bool availableUsername()
            // check if the user name doesn't already exists in the database
        {
            foreach(User user in (Owner as ConnectionForm).db.users)
            {
                if (user.name == usernameTextBox.Text)
                    return false;
            }
            return true;
        }

        private void inscriptionButton_Click(object sender, EventArgs e)
            // finalize the inscription
        {
            // checking for errors
            if (!formComplete())
            {
                errorLabel.Text = "Please fill all form fields.";
                errorLabel.Visible = true;
            }
            else if (!availableUsername())
            {
                errorLabel.Text = "This user name is already\ntaken.";
                errorLabel.Visible = true;
            }
            else if (usernameTextBox.Text.Length > 40)
            {
                errorLabel.Text = "The user name can't have\nmore than 40 characters.";
                errorLabel.Visible = true;
            }
            else if (!passwordsChecks)
            {
                errorLabel.Text = "passwords don't check.";
                errorLabel.Visible = true;
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                errorLabel.Text = "The password must be at\nleast 8 characters long.";
                errorLabel.Visible = true;
            }
            else if (passwordTextBox.Text.Length > 40)
            {
                errorLabel.Text = "The password can't have\nmore than 40 characters.";
                errorLabel.Visible = true;
            }
            else // if no error is encontered, we create the new user and connect him
            {
                errorLabel.Visible = false;
                string name = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string gender = (genderComboBox.SelectedItem.ToString() == "H") ? "0" : "1";
                string birthYear = birthYearComboBox.SelectedItem.ToString();
                (Owner as ConnectionForm).db.AddUser(name, password, gender, birthYear);
                foreach (User user in (Owner as ConnectionForm).db.users)
                {
                    if (user.name == name)
                    {
                        (Owner as ConnectionForm).loggedUser = user;
                        break;
                    }
                }
                Close(); // and close the registration form
            }
        }
    }
}
