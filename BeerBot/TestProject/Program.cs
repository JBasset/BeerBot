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
            string queryResult = "B = beer338 (153,177 sec)";
            queryResult = queryResult.Substring(8);
            string beerName = "";
            foreach (char c in queryResult)
            {
                if (c != ' ')
                    beerName += c;
                else
                    break;
            }
            Console.WriteLine(beerName);
        }
    }
}
