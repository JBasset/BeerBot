﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeerBot
{
    public partial class InscriptionForm : Form
    {
        public InscriptionForm()
        {
            InitializeComponent();
        }

        private void InscriptionForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                birthYeaComboBox.Items.Add((DateTime.Now.Year - 100) + i);
            }
        }
    }
}
