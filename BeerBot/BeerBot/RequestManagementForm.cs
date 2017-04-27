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
    public partial class RequestManagementForm : Form
    {
        // form used by the admins to validate or refuse requests (and delete them in both cases)

        private List<Request> Requests;
        private int RequestIndex = 0;
        private Beer OriginalBeer;

        public RequestManagementForm()
        {
            InitializeComponent();

            arrowPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\next.png");
        }

        private void RequestManagementForm_Load(object sender, EventArgs e)
        {
            updateRequests();
            showRequest();
        }

        private void showRequest()
            // showing the request
        {
            if (Requests.Count > 0)
            {
                validationButton.Enabled = true;
                deleteButton.Enabled = true;

                Request req = Requests[RequestIndex];
                if (req.beer_id == -1) // if the request is adding a beer
                {
                    #region setting display
                    requestLabel.Text = "Adding a new beer";

                    originalBeerNameLabel.Visible = true;
                    originalBeerDescriptionLabel.Visible = false;
                    originalCategoryLabel.Visible = false;
                    originalStyleLabel.Visible = false;
                    originalResultAbvValueLabel.Visible = false;
                    originalResultIbuValueLabel.Visible = false;
                    originalResultSrmValueLabel.Visible = false;

                    beerNameLabel.Visible = true;
                    beerDescriptionLabel.Visible = true;
                    categoryLabel.Visible = true;
                    styleLabel.Visible = true;
                    resultAbvValueLabel.Visible = true;
                    resultIbuValueLabel.Visible = true;
                    resultSrmValueLabel.Visible = true;
                    #endregion

                    originalBeerNameLabel.Text = "No original beer"; // we don't need to show the modified beer since the beer proposed is brand new
                    adviceTitleLabel.Text = "Addition request :";

                    beerNameLabel.Text = req.name;
                    beerDescriptionLabel.Text = req.description;
                    categoryLabel.Text = req.category.name;
                    styleLabel.Text = req.style.name;
                    resultAbvValueLabel.Text = "" + req.abv;
                    resultIbuValueLabel.Text = "" + req.ibu;
                    resultSrmValueLabel.Text = "" + req.srm;

                    beerNameLabel.ForeColor = Color.White;
                    beerDescriptionLabel.ForeColor = Color.White;
                    categoryLabel.ForeColor = Color.White;
                    styleLabel.ForeColor = Color.White;
                    resultAbvValueLabel.ForeColor = Color.White;
                    resultIbuValueLabel.ForeColor = Color.White;
                    resultSrmValueLabel.ForeColor = Color.White;
                }
                else // if the request is a modification of an existing beer
                {
                    #region setting display
                    requestLabel.Text = "Modifying an existing beer";

                    originalBeerNameLabel.Visible = true;
                    originalBeerDescriptionLabel.Visible = true;
                    originalCategoryLabel.Visible = true;
                    originalStyleLabel.Visible = true;
                    originalResultAbvValueLabel.Visible = true;
                    originalResultIbuValueLabel.Visible = true;
                    originalResultSrmValueLabel.Visible = true;

                    beerNameLabel.Visible = true;
                    beerDescriptionLabel.Visible = true;
                    categoryLabel.Visible = true;
                    styleLabel.Visible = true;
                    resultAbvValueLabel.Visible = true;
                    resultIbuValueLabel.Visible = true;
                    resultSrmValueLabel.Visible = true;
                    #endregion

                    // we show both the original beer without modifications and the proposed modifications

                    adviceTitleLabel.Text = "Modification request :";

                    OriginalBeer = getOriginalBeer();

                    originalBeerNameLabel.Text = OriginalBeer.name;
                    originalBeerDescriptionLabel.Text = OriginalBeer.description;
                    originalCategoryLabel.Text = OriginalBeer.category.name;
                    originalStyleLabel.Text = OriginalBeer.style.name;
                    originalResultAbvValueLabel.Text = "" + OriginalBeer.abv;
                    originalResultIbuValueLabel.Text = "" + OriginalBeer.ibu;
                    originalResultSrmValueLabel.Text = "" + OriginalBeer.srm;

                    beerNameLabel.Text = req.name;
                    beerDescriptionLabel.Text = req.description;
                    categoryLabel.Text = req.category.name;
                    styleLabel.Text = req.style.name;
                    resultAbvValueLabel.Text = "" + req.abv;
                    resultIbuValueLabel.Text = "" + req.ibu;
                    resultSrmValueLabel.Text = "" + req.srm;

                    // for every modified field, we show the information in red to make it more visible
                    beerNameLabel.ForeColor = (req.name == OriginalBeer.name) ? Color.White : Color.DarkRed;
                    beerDescriptionLabel.ForeColor = (req.description == OriginalBeer.description) ? Color.White : Color.DarkRed;
                    categoryLabel.ForeColor = (req.category.id == OriginalBeer.category.id) ? Color.White : Color.DarkRed;
                    styleLabel.ForeColor = (req.style.id == OriginalBeer.style.id) ? Color.White : Color.DarkRed;
                    resultAbvValueLabel.ForeColor = (req.abv == OriginalBeer.abv) ? Color.White : Color.DarkRed;
                    resultIbuValueLabel.ForeColor = (req.ibu == OriginalBeer.ibu) ? Color.White : Color.DarkRed;
                    resultSrmValueLabel.ForeColor = (req.srm == OriginalBeer.srm) ? Color.White : Color.DarkRed;
                }
            }
            else // if there are no requests left
            {
                #region setting display
                requestLabel.Text = "No requests left to show";

                originalBeerNameLabel.Visible = false;
                originalBeerDescriptionLabel.Visible = false;
                originalCategoryLabel.Visible = false;
                originalStyleLabel.Visible = false;
                originalResultAbvValueLabel.Visible = false;
                originalResultIbuValueLabel.Visible = false;
                originalResultSrmValueLabel.Visible = false;

                beerNameLabel.Visible = false;
                beerDescriptionLabel.Visible = false;
                categoryLabel.Visible = false;
                styleLabel.Visible = false;
                resultAbvValueLabel.Visible = false;
                resultIbuValueLabel.Visible = false;
                resultSrmValueLabel.Visible = false;
                #endregion

                validationButton.Enabled = false;
                deleteButton.Enabled = false;
            }

            // we set the navigation possibilities
            nextButton.Enabled = RequestIndex < Requests.Count - 1;
            previousButton.Enabled = RequestIndex > 0;
        }

        private Beer getOriginalBeer()
            // get the information on the beer before modifications
        {
            Style style = new Style("Unknown Style", -1);
            Category category = new Category("Unknown Category", -1, new List<Style> { style });
            Beer beer = new Beer("", "", -1, category, style, 0, 0, 0);
            foreach(Beer b in (Owner as MainForm).database.beers)
            {
                if (b.id == Requests[RequestIndex].beer_id)
                    return b;
            }
            return beer;
        }

        private void updateRequests()
            // load all the requests in the Requests list
        {
            Requests = (Owner as MainForm).database.getRequests();
            int nb = (Requests.Count == 0) ? 0 : RequestIndex + 1;
            requestNumberLabel.Text = nb + "/" + Requests.Count;
            (Owner as MainForm).database.UpdateDatabase();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
            // decrement the request index and shows the corresponding request
        {
            RequestIndex--;
            updateRequests();
            showRequest();
        }

        private void nextButton_Click(object sender, EventArgs e)
            // increment the request index and shows the corresponding request
        {
            RequestIndex++;
            updateRequests();
            showRequest();
        }

        private void deleteRequest()
            // delete the request
        {
            (Owner as MainForm).database.Execute("DELETE FROM `requests` WHERE `requests`.`id` = " + Requests[RequestIndex].id);
            RequestIndex = 0;
            updateRequests();
            showRequest();
        }

        private void validationButton_Click(object sender, EventArgs e)
            // add the new data to the database, and deletes the request
        {
            // we get the request information
            Request req = Requests[RequestIndex];
            string name = req.name;
            string descript = req.description;
            double abv = req.abv;
            double ibu = req.ibu;
            double srm = req.srm;
            Category category = req.category;
            Style style = req.style;

            string[] rows = new string[]
            {
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
                name,
                "" + category.id,
                "" + style.id,
                "" + abv,
                "" + ibu,
                "" + srm,
                descript
            };

            if (req.beer_id == -1) // if the request is adding a beer
            {
                (Owner as MainForm).database.Insert("beers", rows, values); // we add a new beer with the request informations
            }
            else // if the request is modifying an existing beer
            {
                (Owner as MainForm).database.Update("beers", rows, values, req.beer_id); // we modify all fields of the beer to the request informations
            }

            // we then delete the request and update the database loaded by the application
            deleteRequest();
            (Owner as MainForm).database.UpdateDatabase();
        }

        private void deleteButton_Click(object sender, EventArgs e)
            // if the delete is denied, we simply delete it
        {
            deleteRequest();
        }
    }
}
