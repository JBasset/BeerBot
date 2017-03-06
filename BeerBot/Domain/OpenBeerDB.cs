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
            nbCat = getNbCat();
            nbSty = getNbSty();
            nbBeers = getNbBeers();
        }

        #region getNb
        private int getNbCat()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM categories";

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int result = reader.GetInt32(0);

            connection.Close();

            return result;
        }
        private int getNbSty()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM styles";

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int result = reader.GetInt32(0);

            connection.Close();

            return result;
        }
        private int getNbBeers()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM beers";

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int result = reader.GetInt32(0);

            connection.Close();

            return result;
        }
        #endregion

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
