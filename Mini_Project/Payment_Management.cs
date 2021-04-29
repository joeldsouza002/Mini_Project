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
    public partial class Payment_Management : Form
    {
        public Payment_Management()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manager_Dashboard md = new Manager_Dashboard();
            this.Hide();
            md.Show();
        }
    }
}
