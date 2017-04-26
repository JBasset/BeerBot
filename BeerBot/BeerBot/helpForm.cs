using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AleVisor
{
    public partial class helpForm : Form
    {
        public helpForm()
        {
            InitializeComponent();

            srmPictureBox.Image = Image.FromFile(@"..\\..\\..\\Ressources\\SRMChart.jpg");
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
