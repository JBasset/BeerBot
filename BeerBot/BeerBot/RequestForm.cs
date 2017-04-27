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
    public partial class RequestForm : Form
    {
        // form used to submit a modification to the admins

        private Beer modifiedBeer;
        private OpenBeerDB database;

        public RequestForm(Beer b, OpenBeerDB database)
        {
            InitializeComponent();
            modifiedBeer = b; // the beer for which the request asks for a modification. If it is the default beer, (id = -1), the request is adding a beer
            this.database = database;

            if (modifiedBeer.id == -1)
                submitButton.Text = "Submit new beer";

            beerNameCheckLabel.ForeColor = Color.Chartreuse;
            beerNameCheckLabel.Text = "\u2713"; // validation symbol
            descriptionCheckLabel.ForeColor = Color.Chartreuse;
            descriptionCheckLabel.Text = "\u2713";
            categoryCheckLabel.ForeColor = Color.Chartreuse;
            categoryCheckLabel.Text = "\u2713";
            styleCheckLabel.ForeColor = Color.Chartreuse;
            styleCheckLabel.Text = "\u2713";
            abvCheckLabel.ForeColor = Color.Chartreuse;
            abvCheckLabel.Text = "\u2713";
            ibuCheckLabel.ForeColor = Color.Chartreuse;
            ibuCheckLabel.Text = "\u2713";
            srmCheckLabel.ForeColor = Color.Chartreuse;
            srmCheckLabel.Text = "\u2713";

            showBeer();
        }

        private void showBeer()
            // show the beer we want to modify
        {
            beernameTextBox.Text = modifiedBeer.name;
            descriptionTextBox.Text = modifiedBeer.description;
            abvNumericUpDown.Value = (decimal)modifiedBeer.abv;
            ibuNumericUpDown.Value = (decimal)modifiedBeer.ibu;
            srmNumericUpDown.Value = (decimal)modifiedBeer.srm;

            foreach (Category cat in database.categories)
                if (cat.id != -1) // not the "unknown category"
                    categoryComboBox.Items.Add(cat);

            Style style = new Style("Unknown Style", -1);
            styleComboBox.Items.Add(style);
            Category category = new Category("Unknown Category", -1, new List<Style> { style });
            categoryComboBox.Items.Add(category);

            categoryComboBox.SelectedItem = (modifiedBeer.category.id == -1) ? category : modifiedBeer.category;
            styleComboBox.SelectedItem = (modifiedBeer.style.id == -1) ? style : modifiedBeer.style;
        }

        private void helpConditionButton_Click(object sender, EventArgs e)
        {
            helpForm hf = new helpForm();
            hf.Disposed += helpForm_Disposed;
            hf.Show();
            helpConditionButton.Enabled = false;
        }

        private void helpForm_Disposed(object sender, EventArgs e)
        {
            helpConditionButton.Enabled = true;
        }

        #region check labels
        // if the entered informations are different from the orginal ones, we show a green validation symbol to signal it

        private void beernameTextBox_TextChanged(object sender, EventArgs e)
        {
            beerNameCheckLabel.Visible = (beernameTextBox.Text != modifiedBeer.name);
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            descriptionCheckLabel.Visible = (descriptionTextBox.Text != modifiedBeer.description);
        }

        private void abvNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            abvCheckLabel.Visible = ((double)abvNumericUpDown.Value != modifiedBeer.abv);
        }

        private void ibuNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ibuCheckLabel.Visible = ((double)ibuNumericUpDown.Value != modifiedBeer.ibu);
        }

        private void srmNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            srmCheckLabel.Visible = ((double)srmNumericUpDown.Value != modifiedBeer.srm);
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                styleCheckLabel.Visible = ((styleComboBox.SelectedItem as Style).id != modifiedBeer.style.id);
            }
            catch
            {
                categoryCheckLabel.Visible = false;
            }
        }
        #endregion

        private void resetButton_Click(object sender, EventArgs e)
            // reseting the form to the original informations of the beers
        {
            showBeer();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
            // submit the modification
        {
            if (beernameTextBox.Text != "") // if the beer's name is set
            {
                string name = (beerNameCheckLabel.Visible) ? beernameTextBox.Text : modifiedBeer.name;
                string descript = (descriptionCheckLabel.Visible) ? descriptionTextBox.Text : modifiedBeer.description;
                double abv = (abvCheckLabel.Visible) ? (double)abvNumericUpDown.Value : modifiedBeer.abv;
                double ibu = (ibuCheckLabel.Visible) ? (double)ibuNumericUpDown.Value : modifiedBeer.ibu;
                double srm = (srmCheckLabel.Visible) ? (double)srmNumericUpDown.Value : modifiedBeer.srm;
                Category category = (categoryCheckLabel.Visible) ? (categoryComboBox.SelectedItem as Category) : modifiedBeer.category;
                Style style = (styleCheckLabel.Visible) ? (styleComboBox.SelectedItem as Style) : modifiedBeer.style;

                string[] rows = new string[]
                {
                "beer_id",
                "name",
                "cat_id",
                "style_id",
                "abv",
                "ibu",
                "srm",
                "descript"
                };

                string[] values = new string[]
                {
                "" + modifiedBeer.id,
                name,
                "" + category.id,
                "" + style.id,
                "" + abv,
                "" + ibu,
                "" + srm,
                descript
                };

                database.Insert("requests", rows, values); // insert a request in the database

                // the user in thanked for his help. We're not savages
                string msg = "Thank you for your contribution to AleVisor !!";
                string caption = "Thanks !";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult msgBox = MessageBox.Show(msg, caption, button);
                Close();
            }
            else
            {
                errorLabel.Visible = true; // the minimal information to create a new beer is giving it a name
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            // setting the possible styles for the selected category
        {
            try
            {
                categoryCheckLabel.Visible = ((categoryComboBox.SelectedItem as Category).id != modifiedBeer.category.id);
            }
            catch // if the cateogry is the unknown category, there can be a exception, catched here
            {
                categoryCheckLabel.Visible = false;
            }

            styleComboBox.Enabled = true;
            styleComboBox.Items.Clear();
            Category cat = (categoryComboBox.SelectedItem as Category); // the control being read-only, there can only be a category selected
            foreach (Style style in cat.styles)
                styleComboBox.Items.Add(style);
            Style sty = new Style("Unknown Style", -1);
            styleComboBox.Items.Add(sty);
            styleComboBox.SelectedItem = sty;
        }
    }
}
