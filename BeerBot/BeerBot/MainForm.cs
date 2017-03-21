using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace BeerBot
{
    public partial class MainForm : Form
    {
        public static OpenBeerDB database = new OpenBeerDB();

        public static int userId;
        public static string userName;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
