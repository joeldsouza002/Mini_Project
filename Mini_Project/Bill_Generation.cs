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
    public partial class Bill_Generation : Form
    {
        public Bill_Generation()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        public void display1()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Bill";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.CommandText = "select sum(Total_Price) from Bill";
                cmd.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                da2.Fill(dt2);
                label18.Visible = true;
                label18.Text = "Total Amount: = Rs " + dt2.Rows[0][0].ToString() + " /- ";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void display2()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Product";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Inventory_Management im = new Inventory_Management();
            this.Hide();
            im.Show();
        }

        private void Bill_Generation_Load(object sender, EventArgs e)
        {
            display1();
            display2();
        }
    }
}
