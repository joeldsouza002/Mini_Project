﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Project
{
    public partial class Bill_Generation : Form
    {
        public Bill_Generation()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manager_Dashboard md = new Manager_Dashboard();
            this.Hide();
            md.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Payment_Management pm = new Payment_Management();
            this.Hide();
            pm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer_Accounts ca = new Customer_Accounts();
            this.Hide();
            ca.Show();
        }
    }
}
