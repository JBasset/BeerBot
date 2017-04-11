using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBeerDB db = new OpenBeerDB();
            PrologEngine engine = new PrologEngine(db);
            foreach (Beer beer in engine.GetAdviceResults())
                Console.WriteLine(beer.name);
        }
    }
}
