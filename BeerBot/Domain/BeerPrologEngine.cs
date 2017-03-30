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

        private string query;

        public BeerPrologEngine(OpenBeerDB database)
        {
            this.database = database;
            engine = new PrologEngine();
            engine.Consult("..\\..\\..\\PrologEngine\\facts.pl");
            engine.Consult("..\\..\\..\\PrologEngine\\predicates.pl");
        }

        public List<Beer> adviceOnKind(User user)
                // ultimately this function will return not strings but objects from the class Beer.cs
        {
            string[] args = new string[] { user.getPrologName(), "B" };
            List<string> results = AskPrologEngine("adviceOnKind", args);

            List<Beer> beers = new List<Beer> { };
            foreach(string result in results)
            {
                if (result.Length > 11) // else, this result is not a value for B and getBeerName will find a out of range exeption
                    beers.Add(getBeerFromQueryResult(result));
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

        private Beer getBeerFromQueryResult(string queryResult) // getting the name of a beer from a query result such as : "B = beer338 (5,5 sec)"
        {
            queryResult = queryResult.Substring(11);
            string beerIdString = "";
            foreach(char c in queryResult)
            {
                if (c != ' ')
                    beerIdString += c;
                else
                    break;
            }
            int beerId = int.Parse(beerIdString);
            foreach(Beer beer in database.beers)
            {
                if (beer.id == beerId)
                    return beer;
            }
            return new Beer();
        }
    }
}
