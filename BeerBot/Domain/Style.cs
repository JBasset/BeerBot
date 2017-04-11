using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Style
    {
        public string name { get; private set; }
        public int id { get; private set; }
        public string prologName { get; private set; }

        public Style(string name, int id)
        {
            this.name = name; this.id = id;
            prologName = getPrologName();
        }

        private string getPrologName()
        {
            return "style" + id;
        }
    }
}
