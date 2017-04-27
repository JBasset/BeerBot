using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Beer
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public int id { get; private set; } // Id of the beer in the database, needed later to create the prolog name of the beer
        public Category category { get; private set; }
        public Style style { get; private set; }
        public string prologName { get; private set; } // Name of the beer in the prolog engine
        public double abv { get; private set; } // Alcohol By Volume
        public double ibu { get; private set; } // International Bitterness Unit
        public double srm { get; private set; } // Standard Reference Method (used to codify the color of the beer ; the greater the srm, the darker the beer)

        public Beer(string name, string description, int id, Category cat, Style sty, double abv, double ibu, double srm)
        {
            this.name = name;
            this.id = id;
            prologName = "beer" + id;
            this.description = description;
            category = cat;
            style = sty;
            this.abv = abv;
            this.ibu = ibu;
            this.srm = srm;
        }
    }
}
