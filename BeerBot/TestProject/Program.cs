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
            foreach (Category cat in db.categories)
            {
                Console.WriteLine(cat.name + " :\n");
                foreach (Style style in cat.styles)
                    Console.WriteLine("\t- "+style.name);
                Console.WriteLine();
            }
        }
    }
}
