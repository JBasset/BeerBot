using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public string name { get; private set; }
        public int id { get; private set; }
        public string prologName { get; private set; } // = "category"+id : corresponds to the name of the category in the prolog engine
        public List<Style> styles { get; private set; } // list of styles in this category

        public Category(string name, int id, List<Style> styles)
        {
            this.name = name; this.id = id; this.styles = styles;
            prologName = getPrologName();
        }

        private string getPrologName()
        {
            return (id == -1) ? "unknownCategory" : "category" + id; // we need an unknown category, but the name category-1 isn't acceptable
        }

        public override string ToString()
        {
            return name;
        }
    }
}
