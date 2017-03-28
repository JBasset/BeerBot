using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace Domain
{
    public class BeerPrologEngine
        // Manipulations of the prolog engine will use this class
    {
        public PrologEngine engine { get; private set; }
        public OpenBeerDB database { get; private set; }

        public BeerPrologEngine(OpenBeerDB database)
        {
            this.database = database;
            engine = new PrologEngine();
            engine.Consult("..\\..\\..\\PrologEngine\\facts.pl");
            engine.Consult("..\\..\\..\\PrologEngine\\predicates.pl");
        }

        public List<string> adviceOnKind(User user)
        {
            string[] args = new string[] { user.getPrologName(), "B" };
            List<string> results = AskPrologEngine("adviceOnKind", args);

            List<string> beers = new List<string> { };
            foreach(string result in results)
            {
                if (result.Length > 11) // else, this result is not a value for B and getBeerName will find a out of range exeption
                    beers.Add(getBeerName(result));
            }
            foreach(string beer in beers)
            {
                //get the name from the ID
            }
            return beers;
        }

        private List<string> AskPrologEngine(string functor, string[] args)
        {
            // Creating the query's string
            string query = "";
            query += functor + "(";
            foreach(string arg in args)
            {
                query += arg + ",";
            }
            query = query.Substring(0, query.Length-1); // suppressing the last comma
            query += ").";

            // asking the query to the engine
            engine.Query = query;
            List<string> result = new List<string> { };
            foreach(PrologEngine.ISolution s in engine.SolutionIterator)
            {
                result.Add(s.ToString());
            }
            return result;
        }

        private string getBeerName(string queryResult) // getting the name of a beer from a query result such as : "B = beer338 (5,5 sec)"
        {
            queryResult = queryResult.Substring(11);
            string beerName = "";
            foreach(char c in queryResult)
            {
                if (c != ' ')
                    beerName += c;
                else
                    break;
            }
            return beerName;
        }
    }
}
