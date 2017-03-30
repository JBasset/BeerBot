using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Prolog;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBeerDB db = new OpenBeerDB();
            foreach (Beer beer in db.beers)
                Console.WriteLine(beer.name);
        }
    }
}
