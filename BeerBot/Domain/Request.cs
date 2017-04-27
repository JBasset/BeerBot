using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Request
        // a request has the same characteristic than a beer, except an id of it's own
    {
        public int id { get; private set; }
        public int beer_id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public Category category { get; private set; }
        public Style style { get; private set; }
        public double abv { get; private set; }
        public double ibu { get; private set; }
        public double srm { get; private set; }

        public Request(int id, int beer_id, string name, string description, Category category, Style style, double abv, double ibu, double srm)
        {
            this.id = id;
            this.beer_id = beer_id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.style = style;
            this.abv = abv;
            this.ibu = ibu;
            this.srm = srm;
        }
    }
}
