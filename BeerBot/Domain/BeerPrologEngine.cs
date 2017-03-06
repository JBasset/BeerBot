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
        public PrologEngine e { get; private set; }

        public BeerPrologEngine()
        {
            e = new PrologEngine();
            createFactsFromDatabase();
        }

        private void createFactsFromDatabase()
        {
            OpenBeerDB db = new OpenBeerDB();

            for (int i = 0; i < db.nbCat; i++)
            {

            }
        }

        public List<string> ask(string functor, string[] args)
        {
            // Creating the query's string
            string query = "";
            query += functor + "(";
            foreach(string arg in args)
                query += arg + ",";
            query = query.Substring(0, query.Length-1); // suppressing the last comma
            query += ").";

            // asking the query to the engine
            e.Query = query;
            List<string> result = new List<string> { };
            foreach(PrologEngine.ISolution s in e.SolutionIterator)
            {
                result.Add(s.ToString());
            }
            return result;
        }

        public string EngineTest()
        {
            PrologEngine.BaseTerm biere = e.NewIsoOrCsStringTerm("biere");
            PrologEngine.BaseTerm jean = e.NewIsoOrCsStringTerm("jean");
            PrologEngine.BaseTerm[] args = new PrologEngine.BaseTerm[] { biere, jean };

            e.CreateFact("likes", args);

            List<string> testFact = ask("likes", new string[] { "biere", "jean" });

            return testFact[0];
        }
    }
}
