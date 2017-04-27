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
    public partial class SearchForm : Form
    {
        // form used by users to search for beer, by name

        private List<Beer> results = new List<Beer> { };
        private int resultIndex = 0;
        private bool rated = false;

        public SearchForm()
        {
            InitializeComponent();

            beerPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\pint.png");
        }

        private void searchButton_Click(object sender, EventArgs e)
            // search beers and load the result
        {
            results = new List<Beer> { };
            resultIndex = 0;
            foreach(Beer b in (this.Owner as MainForm).database.beers)
            {
                string searchString = nameSearchTextBox.Text;
                if (searchString.Length <= b.name.Length && b.name.Substring(0,searchString.Length).ToLower() == searchString.ToLower())
                {
                    results.Add(b); // add all beers corresponding the search string
                }
            }

            if (results.Count == 0) // if no beer correspond to the search
            {
                beerNameLabel.Text = "No results for this search.";
                modificationButton.Enabled = false;
                beerDescriptionLabel.Visible = false;
                categoryLabel.Visible = false;
                styleLabel.Visible = false;
                resultSrmValueLabel.Visible = false;
                resultIbuValueLabel.Visible = false;
                resultAbvValueLabel.Visible = false;
                beerNameLabel.Visible = true;
            }
            else // show the result
            {
                showResult();
                anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
                resultSrmLabel.Visible = true;
                resultIbuLabel.Visible = true;
                resultAbvLabel.Visible = true;
                modificationButton.Enabled = true;
            }
        }

        private void showResult()
            // show the result of the search
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
            foreach (double[] rating in (Owner as MainForm).loggedUser.ratings)
            {
                if (rating[0] == results[resultIndex].id) // if we find the user's rating for this beer
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
            if (!rated) // if the user has not rated the beer yet
            {
                userRatingLabel.Visible = false;
                userRatingNumericUpDown.Visible = true;
                ratingButton.Text = "Rate it !";
                ratingButton.Visible = true;
            }

            // setting the navigation possibilities
            previousBeerButton.Enabled = resultIndex > 0;
            nextBeerButton.Enabled = resultIndex < results.Count - 1;
        }

        private void nextBeerButton_Click(object sender, EventArgs e)
            // we increment the result index, and show the corresponding beer
        {
            resultIndex++;
            userRatingNumericUpDown.Value = 0;
            showResult();
            anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
        }

        private void previousBeerButton_Click(object sender, EventArgs e)
            // we decrement the result index, and show the corresponding beer
        {
            resultIndex--;
            userRatingNumericUpDown.Value = 0;
            showResult();
            anotherLabel.Text = (resultIndex+1) + " / " + results.Count;
        }

        private void ratingButton_Click(object sender, EventArgs e)
            // sets or unsets the rating of the beer
        {
            if (!rated) // if the beer isn't rated by the user yet
            {
                string[] rows = new string[] { "user_id", "beer_id", "rating" };
                string[] values = new string[]
                {
                "" + (Owner as MainForm).loggedUser.id,
                "" + results[resultIndex].id,
                "" + userRatingNumericUpDown.Value
                };

                // we add the rating to the database
                (Owner as MainForm).database.Insert("ratings", rows, values);
                (Owner as MainForm).database.UpdateDatabase();
                (Owner as MainForm).loggedUser = (Owner as MainForm).database.UpdateUser((Owner as MainForm).loggedUser.id);

                rated = true;
                userRatingLabel.Text = "" + userRatingNumericUpDown.Value;
                userRatingLabel.Visible = true;
                userRatingNumericUpDown.Visible = false;
                ratingButton.Text = "Reset rating";
                ratingButton.Visible = true;
            }
            else // if the user already rated this beer, this button deletes the existing rating
            {
                int user_id = (Owner as MainForm).loggedUser.id;
                int beer_id = results[resultIndex].id;
                string query = "DELETE FROM `ratings` WHERE `ratings`.`user_id` = " + user_id + " AND `ratings`.`beer_id` = " + beer_id;
                (Owner as MainForm).database.Execute(query);
                (Owner as MainForm).database.UpdateDatabase();
                (Owner as MainForm).loggedUser = (Owner as MainForm).database.UpdateUser((Owner as MainForm).loggedUser.id);
                rated = false;
                userRatingLabel.Visible = false;
                userRatingNumericUpDown.Visible = true;
                ratingButton.Text = "Rate it !";
                ratingButton.Visible = true;
            }
            userRatingNumericUpDown.Value = 0;
        }

        private void helpConditionButton_Click(object sender, EventArgs e)
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modificationButton_Click(object sender, EventArgs e)
            // shows a request form, with the beer results[resultIndex] in argument
        {
            RequestForm requestForm = new RequestForm(results[resultIndex], (Owner as MainForm).database);
            requestForm.Disposed += RequestForm_Disposed;
            requestForm.Show();
            modificationButton.Enabled = false;
            newBeerButton.Enabled = false;
        }

        private void RequestForm_Disposed(object sender, EventArgs e)
        {
            modificationButton.Enabled = (results.Count != 0);
            newBeerButton.Enabled = true;
        }

        private void newBeerButton_Click(object sender, EventArgs e)
            // shows a request form, with the default beer in argument
        {
            Style style = new Style("Unknown Style", -1);
            Category category = new Category("Unknown Category", -1, new List<Style> { style });
            Beer unknownBeer = new Beer("", "", -1, category, style, 0, 0, 0);
            RequestForm requestForm = new RequestForm(unknownBeer, (Owner as MainForm).database);
            requestForm.Disposed += RequestForm_Disposed;
            requestForm.Show();
            modificationButton.Enabled = false;
            newBeerButton.Enabled = false;
        }
    }
}
