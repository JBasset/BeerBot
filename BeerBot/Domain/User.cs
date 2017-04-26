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
        public List<double[]> ratings { get; private set; } // list of double[2] : the first number is the id of the beer, the second its rating
        public bool admin;

        public string getPrologName()
        {
            return "user" + id;
        }

        public User(int id, string name, string password, int birthYear, bool gender, List<double[]> ratings, bool admin)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.birthYear = birthYear;
            this.gender = gender;
            this.ratings = ratings;
            this.admin = admin;
        }

        public User(string name, string password, int birthYear, bool gender)
        {
            this.name = name;
            this.password = password;
            this.birthYear = birthYear;
            this.gender = gender;
            ratings = new List<double[]> { };
            admin = false;
        }
    }
}
