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
    public partial class GPay : Form
    {
        public GPay()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Payment_Management pm = new Payment_Management();
            this.Hide();
            pm.Show();
        }
    }
}
