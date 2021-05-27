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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

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

        private void Payment_Management_Load(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = Bill_Generation.vall;
                label3.Visible = true;
                label3.Text = "Initial Amount: Rs ";
                label4.Visible = true;
                label4.Text = "Total Amount: Rs ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string msg;
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from Customer where Contact_Number = '" + textBox4.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                msg = "Account Found!\n\nEnter Discount in Percent";
                MessageBox.Show(msg);
                textBox2.Enabled = true;
                button1.Enabled = true;
                label5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Account Not Found!\n\nNo Discount");
                textBox2.Enabled = false;
                button1.Enabled = false;
                label5.Enabled = false;
                textBox1.Text = textBox3.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(msg == "Account Found!\n\nEnter Discount in Percent")
            {
                try
                {
                    int cal = (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox2.Text))/100;
                    cal = Convert.ToInt32(textBox3.Text) - cal;
                    textBox1.Text = cal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer_Accounts ca = new Customer_Accounts();
            this.Hide();
            ca.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string n1 = textBox5.Text;
                string n2 = textBox1.Text;
                int n3 = Convert.ToInt32(n1) - Convert.ToInt32(n2);
                textBox6.Text = n3.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            button1.Enabled = false;
            label5.Enabled = false;
            textBox1.Text = textBox3.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Sales_Transections(Transection_Date, Seller_Type, Transection_Amount) values(GETDATE(), 'Customer', '"+ textBox1.Text +"')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Transection Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Transection_Management tm = new Transection_Management();
            this.Hide();
            tm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Successful\nDon't Forget to Record the Transection!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GPay gp = new GPay();
            this.Hide();
            gp.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Successful\nDon't Forget to Record the Transection!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
