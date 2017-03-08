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
                string prologName = "beer" + beer[0];
                lines.Add("beer(" + prologName + ").");
            }
            #endregion

            #region getting all categories
            List<string[]> categories = AskDataBase("SELECT cat_name FROM categories", new string[] { "cat_name" });
            foreach(string[] category in categories)
            {
                string prologName = category[0].Replace(' ', '_').ToLower(); ;
                lines.Add("category(" + prologName + ").");
            }
            #endregion

            #region getting all styles
            List<string[]> styles = AskDataBase("SELECT id FROM styles", new string[] { "id" });
            foreach (string[] style in styles)
            {
                string prologName = "style" + style[0];
                lines.Add("style(" + prologName + ").");
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
