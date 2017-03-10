using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace Domain
{
    public class OpenBeerDB
        // Manipulations of the database will use this class
    {
        private string mySqlConnectionString = "SERVER=127.0.0.1; DATABASE=openbeerdb; UID=root; PASSWORD=";
        private MySqlConnection connection;

        public int nbCat { get; private set; } // number of categories of beer in the database
        public int nbSty { get; private set; } // number of styles of beer in the database
        public int nbBeers { get; private set; } // number of beers in the database

        public OpenBeerDB()
        {
            connection = new MySqlConnection(mySqlConnectionString);
            //nbCat = getNbCat();
            //nbSty = getNbSty();
            //nbBeers = getNbBeers();
            generateFactFile();
        }

        #region gets from database
        /*
        private int getNbCat()
        {
            return int.Parse(AskDataBase("SELECT COUNT(*) FROM categories")[0]);
        }
        private int getNbSty()
        {
            return int.Parse(AskDataBase("SELECT COUNT(*) FROM styles")[0]);
        }
        private int getNbBeers()
        {
            return int.Parse(AskDataBase("SELECT COUNT(*) FROM beers")[0]);
        }
        */
        #endregion

        private void generateFactFile()
        {
            List<string> lines = new List<string> { };

            #region getting all beers
            List<string[]> beers = AskDataBase("SELECT id FROM beers", new string[] { "id" });
            foreach (string[] beer in beers)
            {
                string prologName = "beer" + beer[0]; // Names in the database include a lot of not allowed characters, hence the automatically generated name
                lines.Add("beer(" + prologName + ").");
            }
            #endregion

            #region getting all categories
            List<string[]> categories = AskDataBase("SELECT id FROM categories", new string[] { "id" });
            foreach(string[] category in categories)
            {
                if (int.Parse(category[0]) != -1)
                {
                    string prologName = "category" + category[0]; // Names in the database include a lot of not allowed characters, hence the automatically generated name
                    lines.Add("category(" + prologName + ").");
                }
                else
                    lines.Add("category(unknownCategory)."); // We need an unknown category, but the name "category-1" isn't acceptable
            }
            #endregion

            #region getting all styles
            List<string[]> styles = AskDataBase("SELECT id FROM styles", new string[] { "id" });
            foreach (string[] style in styles)
            {
                if (int.Parse(style[0]) != -1)
                {
                    string prologName = "style" + style[0];// Names in the database include a lot of not allowed characters, hence the automatically generated name
                    lines.Add("style(" + prologName + ").");
                }
                else
                    lines.Add("style(unknownStyle)."); // We need an unknown style, but the name "style-1" isn't acceptable
            }
            #endregion

            #region getting all abv (alcohol by volume)
            List<string[]> abvs = AskDataBase("SELECT id,abv FROM beers", new string[] { "id", "abv" });
            foreach (string[] abv in abvs)
            {
                lines.Add("abv(beer"+ abv[0] + ","+abv[1].Replace(',','.')+")."); // decimals should be separated with a dot, not a comma
            }
            #endregion

            #region getting all ibu (internationnal bitterness unit)
            List<string[]> ibus = AskDataBase("SELECT id,ibu FROM beers", new string[] { "id", "ibu" });
            foreach (string[] ibu in ibus)
            {
                lines.Add("ibu(beer" + ibu[0] + "," + ibu[1].Replace(',', '.') + ")."); // decimals should be separated with a dot, not a comma
            }
            #endregion

            #region getting all srm (standard reference method)
            List<string[]> srms = AskDataBase("SELECT id,srm FROM beers", new string[] { "id", "srm" });
            foreach (string[] srm in srms)
            {
                lines.Add("srm(beer" + srm[0] + "," + srm[1].Replace(',', '.') + ")."); // decimals should be separated with a dot, not a comma
            }
            #endregion

            #region getting all beers categories
            List<string[]> beersCat = AskDataBase("SELECT id, cat_id FROM beers", new string[] { "id", "cat_id" });
            foreach (string[] beerCat in beersCat)
            {
                string beerPrologName = "beer" + beerCat[0]; // Names in the database include a lot of not allowed characters, hence the automatically generated name
                string catPrologName;
                if (int.Parse(beerCat[1]) != -1)
                    catPrologName = "category" + beerCat[1];
                else
                    catPrologName = "unknownCategory";
                lines.Add("beerCategory(" + beerPrologName + "," + catPrologName + ").");
            }
            #endregion

            #region getting all beers styles
            List<string[]> beersSty = AskDataBase("SELECT id, style_id FROM beers", new string[] { "id", "style_id" });
            foreach (string[] beerSty in beersSty)
            {
                string beerPrologName = "beer" + beerSty[0]; // Names in the database include a lot of not allowed characters, hence the automatically generated name
                string styPrologName;
                if (int.Parse(beerSty[1]) != -1)
                    styPrologName = "style" + beerSty[1];
                else
                    styPrologName = "unknownStyle";
                lines.Add("beerStyle(" + beerPrologName + "," + styPrologName + ").");
            }
            #endregion

            #region getting all styles categories
            List<string[]> stylesCat = AskDataBase("SELECT id, cat_id FROM styles", new string[] { "id", "cat_id" });
            foreach (string[] styleCat in stylesCat)
            {
                string stylePrologName;
                if (int.Parse(styleCat[0]) != -1)
                    stylePrologName = "style" + styleCat[0];
                else
                    stylePrologName = "unknownStyle";

                string catPrologName;
                if (int.Parse(styleCat[1]) != -1)
                    catPrologName = "category" + styleCat[1];
                else
                    catPrologName = "unknownCategory";

                lines.Add("styleCategory(" + stylePrologName + "," + catPrologName + ").");
            }
            #endregion

            using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\PrologEngine\\facts.pl"))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        public List<string[]> AskDataBase(string query, string[] expectedRows)
        {
            connection.Open();

            List<string[]> results = new List<string[]> { };

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] thisRow = new string[expectedRows.Length];
                for (int i = 0; i < expectedRows.Length; i++)
                {
                    thisRow[i] = reader.GetString(expectedRows[i]);
                }
                results.Add(thisRow);
            }

            connection.Close();
            return results;
        }

        /*
        // Basic database manipulation :
        public string DBTest()
        {
            this.connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT name,descript FROM beers WHERE id = 1";

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string result = reader.GetString(0);
            result += "\n" + reader.GetString(1);

            connection.Close();

            return result;
        }
        */
    }
}
