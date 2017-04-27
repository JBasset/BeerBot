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
        private string mySqlConnectionString = "SERVER=127.0.0.1; DATABASE=openbeerdb; UID=root; PASSWORD="; // the connection string to the database
        private MySqlConnection connection;

        // lists of items in the database ; these list are created at the initialisation of the application to avoid having to fetch informations in the database after
        public List<User> users { get; private set; }
        public List<Beer> beers { get; private set; }
        public List<Category> categories { get; private set; }
        private List<double[]> ratings { get; set; } // double[3] : { userid, beerid, rating }

        public OpenBeerDB()
        {
            connection = new MySqlConnection(mySqlConnectionString);
            // setting the lists of items
            ratings = getRatings();
            users = getUsers();
            categories = getCategories();
            beers = getBeers();
            generateFactFile(); // creating the file "facts.pl", countaining all the facts from the database in their prolog form
        }

        public void UpdateDatabase()
            // to call when data is added / deleted, to keep the application up to date with it's data
        {
            ratings = getRatings();
            users = getUsers();
            categories = getCategories();
            beers = getBeers();
            generateFactFile(); // creating the file "facts.pl", countaining all the facts from the database in their prolog form
        }

        public User UpdateUser(int userId)
            // this function will be used when the database is updated, to get the new informations on the logged user if it's necessary
        {
            foreach (User user in users)
            {
                if (user.id == userId)
                    return user;
            }
            return new User("ERROR", "ERROR", 0000, false); // Error value
        }

        private List<User> getUsers()
            // getting all users in the database
        {
            // getting all the users attributes from the database
            List<string[]> usersAttributes = Select(new string[] { "id", "name", "password", "birth_year", "gender", "admin" }, "users");
            List<User> users = new List<User> { };
            foreach(string[] userAttributes in usersAttributes) // for each attributes, we create a user
            {
                // getting all ratings from the user
                List<double[]> userRatings = new List<double[]> { };
                foreach (double[] rating in ratings)
                {
                    if (rating[0] == int.Parse(userAttributes[0])) // if the user at the origin of this rating correspond to the user in userAttributes
                    {
                        userRatings.Add(new double[] { rating[1], rating[2] });
                    }
                }
                users.Add(new User(
                    int.Parse(userAttributes[0]),
                    userAttributes[1],
                    userAttributes[2],
                    int.Parse(userAttributes[3]),
                    bool.Parse(userAttributes[4]),
                    userRatings,
                    bool.Parse(userAttributes[5]))); // adding the user to the list of users
            }
            return users;
        }

        private List<Beer> getBeers()
            // getting all beers in the database
        {
            // getting all the beers attributes in the database
            List<string[]> beersAttributes = Select(new string[]
            {
                "id", "name", "cat_id", "style_id", "abv", "ibu", "srm", "descript"
            }, "beers");
            List<Beer> beers = new List<Beer> { };
            foreach (string[] beerAttributes in beersAttributes) // for each attributes, we create a beer
            {
                if (int.Parse(beerAttributes[0]) != -1) // if the beer isn't the default beer
                {
                    Style sty = new Style("Unknown Style", -1);
                    Category cat = new Category("Unknown Category", -1, new List<Style> { sty });
                    foreach (Category category in categories) // we search for the category of the beer
                    {
                        if (int.Parse(beerAttributes[2]) == category.id)
                            cat = category;
                        foreach (Style style in category.styles) // we search for the style of the beer
                        {
                            if (int.Parse(beerAttributes[3]) == style.id)
                                sty = style;
                        }
                    }

                    beers.Add(new Beer(
                        beerAttributes[1],
                        beerAttributes[7],
                        int.Parse(beerAttributes[0]),
                        cat,
                        sty,
                        double.Parse(beerAttributes[4]),
                        double.Parse(beerAttributes[5]),
                        double.Parse(beerAttributes[6])
                        )); // adding the beer to the list of beers
                }
            }
            return beers;
        }

        private List<Category> getCategories()
            // function used to get all categories from the database
        {
            // getting all categories attributes from the database
            List<string[]> categoriesAttributes = Select(new string[]
            {
                "id", "cat_name"
            }, "categories");
            List<Category> categories = new List<Category> { };
            foreach (string[] categoryAttributes in categoriesAttributes) // for each attributes we create a category
            {
                #region getting styles in this category
                // getting all styles attributes from the database
                List<string[]> stylesAttributes = Select(new string[]
                {
                    "id", "cat_id", "style_name"
                }, "styles");
                List<Style> styles = new List<Style> { };
                foreach (string[] styleAttributes in stylesAttributes) // for each attributes we create a style
                {
                    if (int.Parse(styleAttributes[1]) == int.Parse(categoryAttributes[0])) // if the style is part of the category we are working on
                        styles.Add(new Style(styleAttributes[2], int.Parse(styleAttributes[0]))); // we add it to the category's list of styles
                }
                #endregion
                categories.Add(new Category(categoryAttributes[1], int.Parse(categoryAttributes[0]), styles)); // we add the category to the list of categories
            }
            return categories;
        }

        private List<double[]> getRatings()
            // getting all ratings from the database
        {
            // getting ratings attributes from the database
            List<string[]> ratingsAttributes = Select(new string[]
            {
                "user_id", "beer_id", "rating"
            }, "ratings");
            List<double[]> ratings = new List<double[]> { };
            foreach (string[] ratingAttributes in ratingsAttributes) //for each attributes we create a rating array
            {
                ratings.Add(new double[3]
                {
                    double.Parse(ratingAttributes[0]),
                    double.Parse(ratingAttributes[1]),
                    double.Parse(ratingAttributes[2])
                });
            }
            return ratings;
        }

        public List<Request> getRequests()
            // getting all requests from the database
        {
            // getting all the requests attributes : they are almost the same as the beers attributes
            List<string[]> requestsAttributes = Select(new string[]
            {
                "id", "beer_id", "name", "cat_id", "style_id", "abv", "ibu", "srm", "descript"
            }, "requests");
            List<Request> requests = new List<Request> { };
            foreach (string[] requestAttributes in requestsAttributes) // for each request attribute we create a request
            {
                #region getting the style and the category of the request
                Style sty = new Style("Unknown Style", -1);
                Category cat = new Category("Unknown Category", -1, new List<Style> { sty });
                foreach (Category category in categories)
                {
                    if (int.Parse(requestAttributes[3]) == category.id)
                        cat = category;
                    foreach (Style style in category.styles)
                    {
                        if (int.Parse(requestAttributes[4]) == style.id)
                            sty = style;
                    }
                }
                #endregion

                requests.Add(new Request(
                    int.Parse(requestAttributes[0]),
                    int.Parse(requestAttributes[1]),
                    requestAttributes[2],
                    requestAttributes[8],
                    cat,
                    sty,
                    double.Parse(requestAttributes[5]),
                    double.Parse(requestAttributes[6]),
                    double.Parse(requestAttributes[7])
                    )); // we add the request to the list of requests
            }
            return requests;
        }

        public void AddUser(string name, string password, string gender, string birthYear)
            // used when a new user is registrated ; enters the user's attributes in the database, and updates the list of users
        {
            string[] rows = new string[] { "name", "password", "gender", "birth_year" };
            string[] values = new string[] { name, password, gender, birthYear };
            Insert("users", rows, values);
            users = getUsers();
        }

        private void generateFactFile()
            // this function creates the file 'facts.pl', containing all informations needed by the expert system translated in Prolog facts
        {
            List<string> lines = new List<string> { }; // all the lines contained in the file

            // first comment on top of the file
            lines.Add("%this file is automatically generated from the main program. It musn't be changed in any way, since changes will be erased by the program");

            #region creating lines from the data in the database

            /*
            the names will be automatically generated from the Id of the object in the database before being made into
            a prolog element, since the names in the database often contain unallowed characters in prolog
            */

            // all clauses of a fact must be together in the source file, hence the successive foreach loops when one should have been enough

            #region getting all beers
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    lines.Add("beer(" + beer.prologName + ").");
                }
            }
            #endregion
            
            #region getting all categories
            foreach (Category category in categories)
            {
                if (category.id != -1) // if it isn't the unknown category
                {
                    lines.Add("category(" + category.prologName + ").");
                }
                else
                    lines.Add("category(unknownCategory)."); // We need an unknown category, but the name "category-1" isn't acceptable
            }
            #endregion

            #region getting all styles
            // for the styles it is easier to fetch them in the database, since there isn't a list of all the styles, but just lists of styles in a category
            List<string[]> styles = Select(new string[] { "id" }, "styles");
            foreach (string[] style in styles)
            {
                if (int.Parse(style[0]) != -1) // if it isn't the unknown style
                {
                    string prologName = "style" + style[0];
                    lines.Add("style(" + prologName + ").");
                }
                else
                    lines.Add("style(unknownStyle)."); // We need an unknown style, but the name "style-1" isn't acceptable
            }
            #endregion

            #region getting all abv (alcohol by volume)
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    string abv = (beer.abv == 0) ? "-1" :  "" + beer.abv; // we set the abv at -1 if it is unknown
                    lines.Add("abv(" + beer.prologName + "," + abv.Replace(',', '.') + ")."); // decimals are separated with a dot in prolog, not a comma
                }
            }
            #endregion

            #region getting all ibu (internationnal bitterness unit)
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    string ibu = (beer.ibu == 0) ? "-1" : "" + beer.ibu; // we set the ibu at -1 if it is unknown
                    lines.Add("ibu(" + beer.prologName + "," + ibu.Replace(',', '.') + ")."); // decimals should be separated with a dot, not a comma
                }
            }
            #endregion

            #region getting all srm (standard reference method)
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    string srm = (beer.srm == 0) ? "-1" : "" + beer.srm; // we set the srm at -1 if it is unknown
                    lines.Add("srm(" + beer.prologName + "," + srm.Replace(',', '.') + ")."); // decimals should be separated with a dot, not a comma
                }
            }
            #endregion

            #region getting all beers categories
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    lines.Add("beerCategory(" + beer.prologName + "," + beer.category.prologName + ").");
                }
            }
            #endregion

            #region getting all beers styles
            foreach (Beer beer in beers)
            {
                if (beer.id != -1) // if it isn't the default beer
                {
                    lines.Add("beerStyle(" + beer.prologName + "," + beer.style.prologName + ").");
                }
            }
            #endregion

            #region getting all styles categories
            // for the styles it is easier to fetch them in the database, since there isn't a list of all the styles, but just lists of styles in a category
            List<string[]> stylesCat = Select(new string[] { "id", "cat_id" }, "styles");
            foreach (string[] styleCat in stylesCat)
            {
                // getting the prolog name of the style
                string stylePrologName;
                if (int.Parse(styleCat[0]) != -1)
                    stylePrologName = "style" + styleCat[0];
                else
                    stylePrologName = "unknownStyle";

                // getting the prolog name of the category
                string catPrologName;
                if (int.Parse(styleCat[1]) != -1)
                    catPrologName = "category" + styleCat[1];
                else
                    catPrologName = "unknownCategory";

                lines.Add("styleCategory(" + stylePrologName + "," + catPrologName + ").");
            }
            #endregion

            #region getting all users
            foreach (User user in users)
            {
                lines.Add("user(" + user.getPrologName() + ").");
            }
            #endregion

            #region getting all users birth years
            foreach (User user in users)
            {
                lines.Add("birthDate(" + user.getPrologName() + "," + user.birthYear + ").");
            }
            #endregion

            #region getting all users genders
            foreach (User user in users)
            {
                lines.Add("gender(" + user.getPrologName() + "," + (user.gender ? "woman" : "man") + ").");
            }
            #endregion

            #region getting all users ratings
            foreach (User user in users)
            {
                foreach (double[] rating in user.ratings)
                {
                    string r = ("" + rating[1]).Replace(',', '.'); // the decimal separator in prolog is a dot, not a comma
                    lines.Add("rates(" + user.getPrologName() + ",beer" + rating[0] + "," + r + ").");
                }
            }
            #endregion
            
            #endregion

            // creating the fact.pl file
            using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\PrologEngine\\facts.pl"))
            {
                foreach (string line in lines) // we write all the lines in the file
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        #region SQL like functions
        public List<string[]> Select(string[] rows, string table)
            // return the list of string array corresponding to the SQL command "SELECT rows FROM table"
        {
            connection.Open(); // we open connected to the database

            // we create the query from the rows and the table given in argument
            string query = "SELECT ";
            foreach (string row in rows)
                query += row + ", ";
            query = query.Substring(0, query.Length-2); // suppressing the last ", "
            query += " FROM ";
            query += table;

            List<string[]> results = new List<string[]> { };

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader(); // we execute the query

            while (reader.Read()) // foreach line in the query's result
            {
                string[] thisRow = new string[rows.Length];
                for (int i = 0; i < rows.Length; i++)
                {
                    thisRow[i] = reader.GetString(rows[i]);
                }
                results.Add(thisRow); // we add a row to the results
            }

            //closing the connection to the database and returning the results
            connection.Close();
            return results;
        }

        public void Insert(string table, string[] rows, string[] values)
            // execute the SQL command "INSERT INTO table (rows) VALUES (values)"
        {
            connection.Open(); // we open the connection with the database

            // creating the query
            string query = "INSERT INTO " + table + " (";
            foreach (string row in rows)
                query += row + ", ";
            query = query.Substring(0, query.Length - 2); // suppressing the last ", "
            query += ") VALUES (";
            foreach (string value in values)
            {
                string v;
                try
                {
                    double test = double.Parse(value); // If it is possible to change convert value in a double
                    v = value.Replace(',', '.'); // then the comma becomes a dot ; MySql seperates decimals with a dot
                }
                catch
                {
                    v = "\"" + value +"\""; // Else, the text must be quoted
                }

                query += v + ", ";
            }
            query = query.Substring(0, query.Length - 2); // suppressing the last ", "
            query += ")";

            //executing the query
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            connection.Close(); // closing the connection
        }

        public void Update(string table, string[] rows, string[] values, int id)
            // execute the SQL command "UPDATE table SET rows=values WHERE `id` = id"
        {
            //creating the query
            string query = "UPDATE `beers` SET ";
            for (int i = 0; i < rows.Length; i++)
            {
                string v;
                try
                {
                    double test = double.Parse(values[i]); // If it is possible to change convert value in a double
                    v = values[i].Replace(',', '.'); // then the comma becomes a dot ; MySql seperates decimals with a dot
                }
                catch
                {
                    v = "\"" + values[i] + "\""; // Else, the text must be quoted
                }
                query += "`" + rows[i] + "` =" + v + ", ";
            }
            query = query.Substring(0, query.Length - 2); // suppressing the last ", "
            query += "WHERE `id` = " + id;

            connection.Open(); // opening the connection with the database

            // executing the query
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            connection.Close(); // closing the connection
        }

        public void Execute(string query)
            // execute the SQL command query
        {
            connection.Open(); // opening the connection to the database
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery(); // executing the query
            connection.Close(); // closing the connection to the database
        }
        #endregion
    }
}
