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
    public partial class Customer_Accounts : Form
    {
        public Customer_Accounts()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        public void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Customer";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

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
                Payment_Management pm = new Payment_Management();
                this.Hide();
                pm.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = "To Add Customer Enter all Details and Click on Add Customer \n\nTo Update Customer Details Enter Customer ID and Details to be Updated and then Click on Update Customer";
            msg = msg + "\n\nTo Delete any Customer Account Enter Customer Contact Number and Click on Delete Customer \n\nTo Search Customer Enter Customer Contact Number and Click on Search Customer to Search any and Give Discount";
            MessageBox.Show(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Customer values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Added Successfully");
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

        private void Customer_Accounts_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer where Contact_Number = '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Customer set Contact_Number = '" + textBox3.Text + "' where Customer_Id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Customer Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Customer where Customer_Id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Customer Record Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }
    }
}
