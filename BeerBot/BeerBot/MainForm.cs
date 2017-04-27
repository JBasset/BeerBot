using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Domain;
using System.Threading;

namespace AleVisor
{
    public partial class MainForm : Form
    {
        /* Main form of the application. This is where the logged user can ask for an advice based on his profile and conditions he fixes */

        // adviceConditionPanel : panel where the conditions on the advice will be asked to the user
        // advicePanel : panel where the result of the advice appears

        private List<Beer> results;
        private int resultIndex = 0;
        private bool rated = false;

        public PrologEngine engine; // the prolog engine to which the advice will be asked
        public OpenBeerDB database; // the database containing all data for the application
        public User loggedUser; // the logged user, to whom the application gives the advice

        public MainForm()
        {
            InitializeComponent();

            // connection of a user
            ConnectionForm connectionForm = new ConnectionForm();
            AddOwnedForm(connectionForm);
            connectionForm.Show();
            connectionForm.Disposed += ConnectionForm_Disposed;

            userLogoPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\user.png");
            beerPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\pint.png");
            arrowPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\next.png");
            conditionsPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\list.png");

            categoryComboBox.Items.Add("Any");
            categoryComboBox.SelectedItem = "Any";
            styleComboBox.Items.Add("Any");
            styleComboBox.SelectedItem = "Any";
        }

        private void ConnectionForm_Disposed(object sender, EventArgs e)
        {
            if (loggedUser == null)
            // when the connection form closes, if no user is logged then the application can't work, so it closes too
            {
                string msg = "No user connected, application closing.";
                string caption = "Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult msgBox = MessageBox.Show(msg, caption, button);
                Close();
            }
            else // we initialize the form
            {
                userNameLabel.Text = loggedUser.name;
                userNameLabel.Visible = true;
                engine = new PrologEngine(database);

                foreach (Category cat in database.categories)
                    if (cat.id != -1) // not the "unknown category"
                        categoryComboBox.Items.Add(cat);

                manageButton.Visible = loggedUser.admin;

                this.Enabled = true;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logOffButton_Click(object sender, EventArgs e)
            // allows the user to change profile without closing the application
        {
            loggedUser = null;
            userNameLabel.Visible = false;
            this.Enabled = false;
            ConnectionForm connectionForm = new ConnectionForm();
            AddOwnedForm(connectionForm);
            connectionForm.Show();
            connectionForm.Disposed += ConnectionForm_Disposed; // when the new connection form closes, the same verifications must be made
        }

        private void beerAdviceButton_Click(object sender, EventArgs e)
            // write the conditions of the advice to a text file
        {
            #region setting the conditions
            // for all conditions, the default value is "-1" : if the condition is equal to "-1", it won't be taken in account in the Expert System
            string user = loggedUser.getPrologName();

            string kind = "-1";
            if (styleComboBox.Enabled && styleComboBox.SelectedItem.ToString() != "Any")
                kind = (styleComboBox.SelectedItem as Style).prologName;
            else if (categoryComboBox.SelectedItem.ToString() != "Any")
                kind = (categoryComboBox.SelectedItem as Category).prologName;

            string minRating = (minRatingNumericUpDown.Value == 0) ? "-1" : "" + minRatingNumericUpDown.Value;
            minRating = minRating.Replace(',', '.'); // in Prolog, double are written with a . and not a , ( e.g. : C# : 4,0 ; Prolog : 4.0)

            string minAbv = (minAbvCheckBox.Checked) ? "" + minAbvNumericUpDown.Value : "-1";
            minAbv = minAbv.Replace(',', '.');
            string maxAbv = (maxAbvCheckBox.Checked) ? "" + maxAbvNumericUpDown.Value : "-1";
            maxAbv = maxAbv.Replace(',', '.');
            string minIbu = (minIbuCheckBox.Checked) ? "" + minIbuNumericUpDown.Value : "-1";
            minIbu = minIbu.Replace(',', '.');
            string maxIbu = (maxIbuCheckBox.Checked) ? "" + maxIbuNumericUpDown.Value : "-1";
            maxIbu = maxIbu.Replace(',', '.');
            string minSrm = (minSrmCheckBox.Checked) ? "" + minSrmNumericUpDown.Value : "-1";
            minSrm = minSrm.Replace(',', '.');
            string maxSrm = (maxSrmCheckBox.Checked) ? "" + maxSrmNumericUpDown.Value : "-1";
            maxSrm = maxSrm.Replace(',', '.');

            string[] conditions = new string[] { user, kind, minRating, minAbv, maxAbv, minIbu, maxIbu, minSrm, maxSrm };
            #endregion

            if (engine.AskAdvice(conditions))
            {
                loadingLabel.Text = "Enter the \"adviceFromCS.\" command in the Prolog engine predicates.pl, then click \"Load result\"";
                loadingLabel.Visible = true;
                beerNameLabel.Text = "Searching...";
                beerNameLabel.Visible = true;
            }
            else // if the program couldn't write the conditions to the text file
            {
                loadingLabel.Text = "There has been a problem.";
                loadingLabel.Visible = true;
            }
        }

        private void answerLoadButton_Click(object sender, EventArgs e)
            // load the result of the advice from the text file
        {
            results = engine.GetAdviceResults(); // read the result
            resultIndex = 0;
            if (results.Count == 0) // if the result is empty
            {
                beerDescriptionLabel.Text = "No beers found. Make your conditions less restrictive to improve the qualtity of the advice";
                beerDescriptionLabel.Visible = true;
                categoryLabel.Visible = false;
                styleLabel.Visible = false;
                beerNameLabel.Visible = false;
                resultAbvValueLabel.Visible = false;
                resultIbuValueLabel.Visible = false;
                resultSrmValueLabel.Visible = false;
            }
            else
            {
                showAdvicedBeer();
                anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
            }
            loadingLabel.Visible = false;
        }

        private void showAdvicedBeer()
            // showing the beer results[resultIndex]
        {
            beerNameLabel.Text = results[resultIndex].name;
            beerDescriptionLabel.Text = (results[resultIndex].description == "") ? "No description provided." : results[resultIndex].description;

            categoryLabel.Text = results[resultIndex].category.name;
            styleLabel.Text = results[resultIndex].style.name;

            resultAbvValueLabel.Text = "Non alcoholic";
            if (results[resultIndex].style.id != 140) // style140 correspond to non alcoholic beers, hence no ABV
                resultAbvValueLabel.Text = (results[resultIndex].abv != 0) ? "" + results[resultIndex].abv : "Unknown";

            resultIbuValueLabel.Text = (results[resultIndex].ibu != 0) ? "" + results[resultIndex].ibu : "Unkown";
            resultSrmValueLabel.Text = (results[resultIndex].srm != 0) ? "" + results[resultIndex].srm : "Unkown";

            beerNameLabel.Visible = true;
            beerDescriptionLabel.Visible = true;
            categoryLabel.Visible = true;
            styleLabel.Visible = true;
            resultAbvValueLabel.Visible = true;
            resultIbuValueLabel.Visible = true;
            resultSrmValueLabel.Visible = true;

            rated = false;
            foreach (double[] rating in loggedUser.ratings)
            {
                if (rating[0] == results[resultIndex].id) // if we find the rating of the user for this beer
                {
                    rated = true;
                    userRatingLabel.Text = "" + rating[1];
                    userRatingLabel.Visible = true;
                    userRatingNumericUpDown.Visible = false;
                    ratingButton.Text = "Reset rating";
                    ratingButton.Visible = true;
                    break;
                }
            }
            if (!rated) // if the user has not rated this beer
            {
                userRatingLabel.Visible = false;
                userRatingNumericUpDown.Visible = true;
                ratingButton.Text = "Rate it !";
                ratingButton.Visible = true;
            }

            // we set the possibilities of navigation
            previousBeerButton.Enabled = resultIndex > 0;
            nextBeerButton.Enabled = resultIndex < results.Count - 1;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            // loading the possible styles from the selected category
        {
            if (categoryComboBox.SelectedItem.ToString() != "Any")
            {
                styleComboBox.Enabled = true;
                styleComboBox.Items.Clear();
                styleComboBox.Items.Add("Any");
                styleComboBox.SelectedItem = "Any";
                Category cat = (categoryComboBox.SelectedItem as Category); // the control being read-only, there can only be a category selected
                foreach (Style style in cat.styles)
                    styleComboBox.Items.Add(style); // load all the category's styles
            }
            else
            {
                styleComboBox.Enabled = false;
                styleComboBox.Items.Clear();
                styleComboBox.Items.Add("Any");
            }
        }

        #region checkboxes
        // shows a red cross if the condition is not taken in account, and a green validation symbol if it is
        // also resets the extremas

        private void minAbvCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (minAbvCheckBox.Checked)
            {
                minAbvCheckBox.Text = "\u2713"; // validation symbol
                minAbvCheckBox.ForeColor = Color.Chartreuse;
                minAbvNumericUpDown.Enabled = true;
                minAbvNumericUpDown.Visible = true;
                minAbvNumericUpDown.Value = minAbvNumericUpDown.Minimum;
            }
            else
            {
                minAbvCheckBox.Text = "X";
                minAbvCheckBox.ForeColor = Color.DarkRed;
                minAbvNumericUpDown.Enabled = false;
                minAbvNumericUpDown.Visible = false;
                maxAbvNumericUpDown.Minimum = 0;
            }
        }

        private void minIbuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (minIbuCheckBox.Checked)
            {
                minIbuCheckBox.Text = "\u2713"; // validation symbol
                minIbuCheckBox.ForeColor = Color.Chartreuse;
                minIbuNumericUpDown.Enabled = true;
                minIbuNumericUpDown.Visible = true;
                minIbuNumericUpDown.Value = minIbuNumericUpDown.Minimum;
            }
            else
            {
                minIbuCheckBox.Text = "X";
                minIbuCheckBox.ForeColor = Color.DarkRed;
                minIbuNumericUpDown.Enabled = false;
                minIbuNumericUpDown.Visible = false;
                maxIbuNumericUpDown.Minimum = 0;
            }
        }

        private void minSrmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (minSrmCheckBox.Checked)
            {
                minSrmCheckBox.Text = "\u2713"; // validation symbol
                minSrmCheckBox.ForeColor = Color.Chartreuse;
                minSrmNumericUpDown.Enabled = true;
                minSrmNumericUpDown.Visible = true;
                minSrmNumericUpDown.Value = minSrmNumericUpDown.Minimum;
            }
            else
            {
                minSrmCheckBox.Text = "X";
                minSrmCheckBox.ForeColor = Color.DarkRed;
                minSrmNumericUpDown.Enabled = false;
                minSrmNumericUpDown.Visible = false;
                maxSrmNumericUpDown.Minimum = 0;
            }
        }

        private void maxAbvCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maxAbvCheckBox.Checked)
            {
                maxAbvCheckBox.Text = "\u2713"; // validation symbol
                maxAbvCheckBox.ForeColor = Color.Chartreuse;
                maxAbvNumericUpDown.Enabled = true;
                maxAbvNumericUpDown.Visible = true;
                maxAbvNumericUpDown.Value = maxAbvNumericUpDown.Minimum;
            }
            else
            {
                maxAbvCheckBox.Text = "X";
                maxAbvCheckBox.ForeColor = Color.DarkRed;
                maxAbvNumericUpDown.Enabled = false;
                maxAbvNumericUpDown.Visible = false;
                minAbvNumericUpDown.Maximum = 100;
            }
        }

        private void maxIbuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maxIbuCheckBox.Checked)
            {
                maxIbuCheckBox.Text = "\u2713"; // validation symbol
                maxIbuCheckBox.ForeColor = Color.Chartreuse;
                maxIbuNumericUpDown.Enabled = true;
                maxIbuNumericUpDown.Visible = true;
                maxIbuNumericUpDown.Value = maxIbuNumericUpDown.Minimum;
            }
            else
            {
                maxIbuCheckBox.Text = "X";
                maxIbuCheckBox.ForeColor = Color.DarkRed;
                maxIbuNumericUpDown.Enabled = false;
                maxIbuNumericUpDown.Visible = false;
                minIbuNumericUpDown.Maximum = 100;
            }
        }

        private void maxSrmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maxSrmCheckBox.Checked)
            {
                maxSrmCheckBox.Text = "\u2713"; // validation symbol
                maxSrmCheckBox.ForeColor = Color.Chartreuse;
                maxSrmNumericUpDown.Enabled = true;
                maxSrmNumericUpDown.Visible = true;
                maxSrmNumericUpDown.Value = maxSrmNumericUpDown.Minimum;
            }
            else
            {
                maxSrmCheckBox.Text = "X";
                maxSrmCheckBox.ForeColor = Color.DarkRed;
                maxSrmNumericUpDown.Enabled = false;
                maxSrmNumericUpDown.Visible = false;
                minSrmNumericUpDown.Maximum = 40;
            }
        }

        #endregion

        #region set numeric up-downs extrema
        private void minAbvNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (minAbvCheckBox.Checked)
                maxAbvNumericUpDown.Minimum = minAbvNumericUpDown.Value + 1;
        }

        private void maxAbvNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (maxAbvCheckBox.Checked)
                minAbvNumericUpDown.Maximum = maxAbvNumericUpDown.Value - 1;
        }

        private void minIbuNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (minIbuCheckBox.Checked)
                maxIbuNumericUpDown.Minimum = minIbuNumericUpDown.Value + 1;
        }

        private void maxIbuNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (maxIbuCheckBox.Checked)
                minIbuNumericUpDown.Maximum = maxIbuNumericUpDown.Value - 1;
        }

        private void minSrmNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (minSrmCheckBox.Checked)
                maxSrmNumericUpDown.Minimum = minSrmNumericUpDown.Value + 1;
        }

        private void maxSrmNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(maxSrmCheckBox.Checked)
                minSrmNumericUpDown.Maximum = maxSrmNumericUpDown.Value - 1;
        }
        #endregion

        private void helpConditionButton_Click(object sender, EventArgs e)
            // shows an help form to explain the vocabrewlary
        {
            helpForm helpForm = new helpForm();
            helpForm.Disposed += helpForm_Disposed;
            helpConditionButton.Enabled = false;
            helpForm.Show();
        }

        private void helpForm_Disposed(object sender, EventArgs e)
        {
            helpConditionButton.Enabled = true;
        }

        private void previousBeerButton_Click(object sender, EventArgs e)
            // decrement the result index and shows the corresponding beer
        {
            resultIndex--;
            userRatingNumericUpDown.Value = 0;
            showAdvicedBeer();
            anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
        }

        private void nextBeerButton_Click(object sender, EventArgs e)
            // increment the result index and shows the corresponding beer
        {
            resultIndex++;
            userRatingNumericUpDown.Value = 0;
            showAdvicedBeer();
            anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
        }

        private void beerSearchButton_Click(object sender, EventArgs e)
            // shows a search form
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Owner = this;
            searchForm.Show();
            beerSearchButton.Enabled = false;
            searchForm.Disposed += searchForm_disposed;
        }

        private void searchForm_disposed(object sender, EventArgs e)
        {
            beerSearchButton.Enabled = true;
        }

        private void ratingButton_Click(object sender, EventArgs e)
        {
            if (!rated) // if the beer result[resultIndex] isn't rated yet
            {
                string[] rows = new string[] { "user_id", "beer_id", "rating" };
                string[] values = new string[]
                {
                "" + loggedUser.id,
                "" + results[resultIndex].id,
                "" + userRatingNumericUpDown.Value
                };

                database.Insert("ratings", rows, values); // we insert the new rating in the database
                database.UpdateDatabase();
                loggedUser = database.UpdateUser(loggedUser.id);

                rated = true;
                userRatingLabel.Text = "" + userRatingNumericUpDown.Value;
                userRatingLabel.Visible = true;
                userRatingNumericUpDown.Visible = false;
                ratingButton.Text = "Reset rating";
                ratingButton.Visible = true;
            }
            else // if the beer is already rated, the button ad for effect erasing the rating
            {
                int user_id = loggedUser.id;
                int beer_id = results[resultIndex].id;
                string query = "DELETE FROM `ratings` WHERE `ratings`.`user_id` = " + user_id + " AND `ratings`.`beer_id` = " + beer_id;
                database.Execute(query);
                rated = false;
                userRatingLabel.Visible = false;
                userRatingNumericUpDown.Visible = true;
                ratingButton.Text = "Rate it !";
                ratingButton.Visible = true;
            }
            userRatingNumericUpDown.Value = 0;
        }

        private void manageButton_Click(object sender, EventArgs e)
            // shows a management form. Only accessible to a admin user
        {
            RequestManagementForm requestForm = new RequestManagementForm();
            requestForm.Owner = this;
            manageButton.Enabled = false;
            requestForm.Show();
            requestForm.Disposed += RequestManagementForm_Disposed;
        }

        private void RequestManagementForm_Disposed(object sender, EventArgs e)
        {
            manageButton.Enabled = true;
        }
    }
}
