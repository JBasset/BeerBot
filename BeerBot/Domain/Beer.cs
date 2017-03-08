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
        public int id { get; private set; } // Id of the beer in the database
        public int catId { get; private set; } // Id of the beer's category
        public int styId { get; private set; } // Id of the beer's style
        public string prologName { get; private set; } // Name of the beer in the prolog engine
        public double abv { get; private set; } // Alcohol By Volume
        public double ibu { get; private set; } // International Bitterness Unit
        public double srm { get; private set; } // Standard Reference Method (used to codify the color of the beer ; the greater the srm, the darker the beer)

        public Beer(string name, string description, int id, int catId, int styId, double abv, double ibu, double srm)
        {
            this.name = name;
            this.id = id;
            prologName = "beer" + id;
            this.description = description;
            this.catId = catId;
            this.styId = styId;
            this.abv = abv;
            this.ibu = ibu;
            this.srm = srm;
        }
    }
}
