using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_Project
{
    public partial class Payment_Management : Form
    {
        public Payment_Management()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joel Dsouza\Source\Repos\joeldsouza002\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        private void button9_Click(object sender, EventArgs e)
        {
            if (Login.user == "Manager")
            {
                Manager_Dashboard md = new Manager_Dashboard();
                this.Hide();
                md.Show();
            }
            else if (Login.user == "Cashier")
            {
                Bill_Generation bg = new Bill_Generation();
                this.Hide();
                bg.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
