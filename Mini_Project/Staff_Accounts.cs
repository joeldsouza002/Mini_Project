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
    public partial class Staff_Accounts : Form
    {
        public Staff_Accounts()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joel Dsouza\Source\Repos\joeldsouza002\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        public void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Staff";
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
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Staff values('" + textBox4.Text + "', '" + textBox5.Text + "', 'Manager', '" + textBox6.Text + "', '"+ comboBox2.Text +"')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Manager Added Successfully");
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Staff_Accounts_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Staff values('" + textBox1.Text + "', '" + textBox2.Text + "', 'Cashier', '" + textBox3.Text + "', '"+ comboBox1.Text +"')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cashier Added Successfully");
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manager_Dashboard db = new Manager_Dashboard();
            this.Hide();
            db.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = "To Add User Enter all Details and Click on Add \n\nTo Update User Details Enter User ID and Details to be Updated and then Click on Update Details";
            msg = msg + "\n\nTo Delete any User Enter User ID and Click on Delete User \n\nTo Search User Enter User ID and Click on Search User to Search any User";
            MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Staff set Working_Day = '"+ comboBox1.Text +"' where UserId = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Successfully Updated");
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
                cmd.CommandText = "update Staff set Working_Day = '" + comboBox2.Text + "' where UserId = '" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Successfully Updated");
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
                cmd.CommandText = "delete from Staff where UserId = '" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Staff where UserId = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Deleted successfully");
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
            cmd.CommandText = "select * from Staff where User_Name = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Staff where User_Name='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
