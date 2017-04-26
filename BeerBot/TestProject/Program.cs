using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBeerDB db = new OpenBeerDB();
            db.Execute("DELETE FROM `ratings` WHERE `ratings`.`user_id` = 1 AND `ratings`.`beer_id` = 42");
        }
    }
}
