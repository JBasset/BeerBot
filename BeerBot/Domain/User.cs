using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int id { get; private set; } // the id will be needed to create the prolog name ("user"+id)
        public string name { get; private set; }
        public string password { get; private set; }
        public int birthYear { get; private set; }
        public bool gender { get; private set; } // false for man, true for woman (let's pretend nobody's going to find that offensive)

        public User(int id, string name, string password, int birthYear, bool gender)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.birthYear = birthYear;
            this.gender = gender;
        }
    }
}
