using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Domain
{
    public class PrologEngine
        // Communication with the prolog file predicates.pl
    {
        public OpenBeerDB database { get; private set; }

        private string CSToPrologPath { get; set; }
        private string PrologToCSPath { get; set; }

        public PrologEngine(OpenBeerDB database)
        {
            CSToPrologPath = @"..\\..\\..\\PrologEngine\\CSToProlog.txt";
            PrologToCSPath = @"..\\..\\..\\PrologEngine\\PrologToCS.txt";
            this.database = database;
        }

        public bool AskAdvice(string[] conditions)
            // the conditions are, in order :
                // the user to whow we give the advice
                // the kind (style or category)
                // the min average rating
                // the min abv
                // the max abv
                // min max ibu
                // min max srm
            // For all, default value is -1
            // Ultimately, this function will send a signal to prolog. For now this work is done manually
        {
            try
            {
                File.WriteAllLines(CSToPrologPath, conditions); // writing all the conditions in a text file
                return true;
            }
            catch
            { return false; }
        }

        public List<Beer> GetAdviceResults()
            // get the list of beer from the text file containing the result of the advice
        {
            List<Beer> beers = new List<Beer> { };

            string[] beerPrologNames = File.ReadAllLines(PrologToCSPath); // getting all beers prolog name from the text result
            foreach (string beerPrologName in beerPrologNames)
            {
                int id = int.Parse(beerPrologName.Substring(4)); // getting the id of the beer from its prolog name (beer50 => 50)
                foreach (Beer beer in database.beers) // we search the beer corresponding the id
                {
                    if (beer.id == id)
                    {
                        beers.Add(beer); // we add it to the result
                        break;
                    }
                }
            }

            return beers;
        }
    }
}
