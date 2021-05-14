using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Mini_Project
{
    public partial class Manager_Dashboard : Form
    {
        public Manager_Dashboard()
        {
            InitializeComponent();
        }

        private void Manager_Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff_Accounts sa = new Staff_Accounts();
            this.Hide();
            sa.Show();
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        */

        private void button7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            this.Hide();
            ab.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Customer_Accounts ca = new Customer_Accounts();
            this.Hide();
            ca.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Inventory_Management im = new Inventory_Management();
            this.Hide();
            im.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Transection_Management tm = new Transection_Management();
            this.Hide();
            tm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Bill_Generation bg = new Bill_Generation();
            this.Hide();
            bg.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Payment_Management pm = new Payment_Management();
            this.Hide();
            pm.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff_Accounts sa = new Staff_Accounts();
            this.Hide();
            sa.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Accounts ca = new Customer_Accounts();
            this.Hide();
            ca.Show();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory_Management im = new Inventory_Management();
            this.Hide();
            im.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transection_Management tm = new Transection_Management();
            this.Hide();
            tm.Show();
        }

        private void billGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill_Generation bg = new Bill_Generation();
            this.Hide();
            bg.Show();
        }

        private void managePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Management pm = new Payment_Management();
            this.Hide();
            pm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void locateStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.co.in/maps/place/Super+Market/@15.593837,73.7471776,15z/data=!4m9!1m2!2m1!1ssupermarket!3m5!1s0x3bbfebcd7d2cc4e1:0xc614ede9daa8a066!8m2!3d15.5926839!4d73.7597323!15sCgtzdXBlcm1hcmtldFoaCgtzdXBlcm1hcmtldCILc3VwZXJtYXJrZXSSAQtzdXBlcm1hcmtldA?hl=en&authuser=0");
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Process.Start("https://open.spotify.com/playlist/1ZAXL8W9niwaTaQVRHAGD4");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            About ab = new About();
            this.Hide();
            ab.Show();
        }

        private void bankBalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.onlinesbi.com/");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator.Calculator c = new Calculator.Calculator();
            this.Hide();
            c.Show();
        }

        private void dailyNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://timesofindia.indiatimes.com/");
        }

        private void weatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://weather.com/en-IN/weather/today/l/15.60,73.76?par=google&temp=c");
        }

        private void amazonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.amazon.in/");
        }

        private void flipkartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.flipkart.com/");
        }

        private void snapdealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.snapdeal.com/");
        }

        private void myntraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.myntra.com/");
        }

        private void sheinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.firstcry.com/");
        }

        private void pharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://pharmeasy.in/");
        }

        private void bigBasketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.bigbasket.com/");
        }

        private void eBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.ebay.com/");
        }

        private void gMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://mail.google.com/");
        }
    }
}
