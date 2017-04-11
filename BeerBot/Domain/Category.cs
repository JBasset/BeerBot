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
        public string prologName { get; private set; }
        public List<Style> styles { get; private set; }

        public Category(string name, int id, List<Style> styles)
        {
            this.name = name; this.id = id; this.styles = styles;
            prologName = getPrologName();
        }

        private string getPrologName()
        {
            return "category" + id;
        }
    }
}
