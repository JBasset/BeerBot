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
    {
        private string mySqlConnectionString = "SERVER=127.0.0.1; DATABASE=openbeerdb; UID=root; PASSWORD=";
        private MySqlConnection connection;

        public OpenBeerDB()
        {
            connection = new MySqlConnection(mySqlConnectionString);
        }

        /*
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
