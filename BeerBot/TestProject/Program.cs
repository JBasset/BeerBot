using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBeerDB db = new OpenBeerDB();

            foreach(User user in db.users)
            {
                Console.Write(user.id
                    + " " + user.name
                    + " " + user.password
                    + " " + user.birthYear
                    + " " + user.gender);
                Console.WriteLine();
            }
        }
    }
}
