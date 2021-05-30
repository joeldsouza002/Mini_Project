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
        public static string vall;

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
                dataGridView1.Columns["Product_Id"].DisplayIndex = 0;
                dataGridView1.Columns["Category_Id"].DisplayIndex = 1;
                dataGridView1.Columns["Product_Name"].DisplayIndex = 2;
                dataGridView1.Columns["Product_Price"].DisplayIndex = 3;
                dataGridView1.Columns["Product_Quantity"].DisplayIndex = 4;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }

        public void display2()
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
                dataGridView2.DataSource = dt;
                dataGridView2.Columns["ProductId"].DisplayIndex = 0;
                dataGridView2.Columns["Product_Name"].DisplayIndex = 1;
                dataGridView2.Columns["Product_Price"].DisplayIndex = 2;
                dataGridView2.Columns["Quantity"].DisplayIndex = 3;
                dataGridView2.Columns["Total_Price"].DisplayIndex = 4;
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
            if (textBox3.Text == "")
            {
                MessageBox.Show("Generate Bill First!");
            }
            else
            {
                Payment_Management pm = new Payment_Management();
                this.Hide();
                pm.Show();
            }
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
                label2.Visible = true;
                label2.Text = "Total Amount: Rs ";
                textBox3.Text = dt2.Rows[0][0].ToString();
                vall = textBox3.Text;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
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
                    string pid = textBox1.Text.ToString();
                    string pname = row["Product_Name"].ToString();
                    string pprice = row["Product_Price"].ToString();
                    string pqty = textBox2.Text.ToString();
                    int total = Convert.ToInt32(pprice) * Convert.ToInt32(textBox2.Text);
                    cmd.CommandText = "insert into Bill values('" + pid + "', '" + pname + "', '" + pprice + "', " + pqty + ", '"+ total +"')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                display2();
                MessageBox.Show("Item Added Successfully\n\nInventory Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

            try
            {
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select Product_Quantity from Product where Product_Id = '" + textBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                foreach (DataRow row in dt1.Rows)
                {
                    string pqty = row["Product_Quantity"].ToString();
                    int qty = Convert.ToInt32(pqty) - Convert.ToInt32(textBox2.Text);
                    cmd1.CommandText = "update Product set Product_Quantity = '"+ qty +"' where Product_Id = '"+ textBox1.Text +"'";
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();
                display1();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            Calculator.Calculator c = new Calculator.Calculator();
            this.Hide();
            c.Show();
        }

        Bitmap bitmap;

        private void button8_Click(object sender, EventArgs e)
        {
            int height = dataGridView2.Height;
            dataGridView1.Height = dataGridView2.RowCount * dataGridView2.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView2.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string query = "Delete from Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            display2();
        }
    }
}