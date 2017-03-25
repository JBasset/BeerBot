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
        public OpenBeerDB database;
        public User connectedUser;

        public static int userId;
        public static string userName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectionForm connectionFrom = new ConnectionForm();
            connectionFrom.Show();
        }
    }
}
