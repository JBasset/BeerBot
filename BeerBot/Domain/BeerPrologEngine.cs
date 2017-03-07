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

        public BeerPrologEngine()
        {
            engine = new PrologEngine();
            createFactsFromDatabase();
        }

        private void createFactsFromDatabase()
        {
            // Creating the database class also writes all facts from the database in a prolog file
            OpenBeerDB db = new OpenBeerDB();
            engine.Consult("..\\..\\..\\PrologEngine\\facts.pl");
        }

        public List<string> AskPrologEngine(string functor, string[] args)
        {
            // Creating the query's string
            string query = "";
            query += functor + "(";
            foreach(string arg in args)
            {
                PrologEngine.BaseTerm argBaseTerm = engine.NewIsoOrCsStringTerm(arg);
                query += argBaseTerm.ToString() + ",";
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
    }
}
