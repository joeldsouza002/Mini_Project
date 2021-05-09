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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joel Dsouza\Source\Repos\joeldsouza002\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        public void display1()
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
                dataGridView1.DataSource = dt;
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
                cmd.CommandText = "select Product_Name, Product_Price, Quantity, Total_Price from Bill";
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
            if(Login.user == "Manager")
            {
                Manager_Dashboard md = new Manager_Dashboard();
                this.Hide();
                md.Show();
            }
            else if(Login.user == "Cashier")
            {
                Login li = new Login();
                this.Hide();
                li.Show();
            }
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
            if(Login.user == "Manager")
            {
                button9.Text = "";
                button9.Text = "Back";
            }
            else if(Login.user == "Cashier")
            {
                button9.Text = "";
                button9.Text = "Logout";
            }

            timer1.Start();
            label9.Text = DateTime.Now.ToLongTimeString();
            label10.Text = DateTime.Now.ToLongDateString();

            display1();
            string query = "delete from Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            display2();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select sum(Total_Price) from Bill";
                cmd.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                da2.Fill(dt2);
                label18.Visible = true;
                label2.Visible = true;
                label2.Text = "Total Amount: = Rs ";
                label18.Text = dt2.Rows[0][0].ToString() + " /- ";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Product_Name, Product_Price from Product where Product_Id = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                foreach (DataRow row in dt.Rows)
                {
                    string pname = row["Product_Name"].ToString();
                    string pprice = row["Product_Price"].ToString();
                    int total = Convert.ToInt32(pprice) * Convert.ToInt32(textBox2.Text);
                    cmd.CommandText = "insert into Bill values('" + textBox1.Text + "', '" + pname + "', '" + pprice + "', " + textBox2.Text + ", '"+ total +"')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                display2();
                MessageBox.Show("Item Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Bill where ProductId = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                foreach (DataRow row in dt.Rows)
                {
                    string pprice = row["Product_Price"].ToString();
                    int total = Convert.ToInt32(pprice) * Convert.ToInt32(textBox2.Text);
                    cmd.CommandText = "update Bill set Quantity = '" + textBox2.Text + "', Total_Price = '" + total + "' where ProductId = '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                display2();
                MessageBox.Show("Record Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}