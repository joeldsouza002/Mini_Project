using System;
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
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            int i;
            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                System.Threading.Thread.Sleep(50);
            }

            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            this.Hide();
            ab.Show();
        }

        private void locateStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start("https://www.google.co.in/maps/place/Super+Market/@15.593837,73.7471776,15z/data=!4m9!1m2!2m1!1ssupermarket!3m5!1s0x3bbfebcd7d2cc4e1:0xc614ede9daa8a066!8m2!3d15.5926839!4d73.7597323!15sCgtzdXBlcm1hcmtldFoaCgtzdXBlcm1hcmtldCILc3VwZXJtYXJrZXSSAQtzdXBlcm1hcmtldA?hl=en&authuser=0");
        }
    }
}
