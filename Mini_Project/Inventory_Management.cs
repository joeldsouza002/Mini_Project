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
    public partial class Inventory_Management : Form
    {
        public Inventory_Management()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joel Dsouza\Source\Repos\joeldsouza002\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        public void display1()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Product_Category";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " +ex.Message);
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

        private void Inventory_Management_Load(object sender, EventArgs e)
        {
            display1();
            display2();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manager_Dashboard md = new Manager_Dashboard();
            this.Hide();
            md.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Product_Category values('" + textBox1.Text + "', '" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Category Added Successfully");
                display1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Product_Category where Category_Id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display1();
                MessageBox.Show("Category Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product_Category where Category_Id = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where Product_Id = '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Product values('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product Added Successfully");
                display2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Product set Category_Id = '" + textBox4.Text + "', Product_Price = '" + textBox6.Text + "', Product_Quantity = '"+ textBox7.Text +"' where Product_Id = '" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display2();
                MessageBox.Show("Product Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Product where Product_Id = '" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display2();
                MessageBox.Show("Product Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = "CATEGORY\n\nTo Add Category Enter all Details and Click on Add \n";
            msg = msg + "\n\nTo Delete any Category Enter Category ID and Click on Delete\nTo Search Category Enter Category ID and Click on Search Category\n\n";
            msg = msg + "PRODUCT\n\nTo Add Product Enter all Details and Click on Add \nTo Udate Product Enter Product ID and Updated Details and click on Update\n";
            msg = msg + "To Delete any Product Enter Product ID and Click on Delete\nTo Search Product Enter Product ID and Click on Search Product\n";
            MessageBox.Show(msg);
        }
    }
}
