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
    public partial class Transection_Management : Form
    {
        public Transection_Management()
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
                cmd.CommandText = "select * from Purchase_Transections";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd.CommandText = "select sum(Transection_Amount) from Purchase_Transections";
                cmd.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                da2.Fill(dt2);
                label18.Visible = true;
                label18.Text = "Total Purchase Amount: = Rs " + dt2.Rows[0][0].ToString() + " /- ";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void display2()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sales_Transections";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            cmd.CommandText = "select sum(Transection_Amount) from Sales_Transections";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            label19.Visible = true;
            label19.Text = "Total Sales Amount: = Rs " + dt1.Rows[0][0].ToString() + "/-";
            con.Close();
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

        private void Transection_Management_Load(object sender, EventArgs e)
        {
            display1();
            display2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Purchase_Transections values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Transection Added Successfully");
                display1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = "To Add Transection Enter all Transection Details and Click on Add Transection \nTo Search Transection Enter Transection Date in YYYY-MM-DD Format or Transection ID and Click on Search Transection";
            MessageBox.Show(msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Purchase_Transections where Transection_Id = '" + textBox1.Text + "' or Transection_Date = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Sales_Transections values('" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Transection Added Successfully");
                display2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sales_Transections where Transection_Id = '" + textBox5.Text + "' or Transection_Date = '" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
    }
}
