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
    }
}
