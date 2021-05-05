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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                System.Threading.Thread.Sleep(50);
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                string query = "select * from Staff where UserId = '" + textBox3.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    if (radioButton1.Checked == true)
                    {
                        MessageBox.Show("Successfully Logged In as Manager!");
                        this.Hide();
                        Manager_Dashboard m = new Manager_Dashboard();
                        m.Show();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        MessageBox.Show("Successfully Logged In as Cashier!");
                        this.Hide();
                        Bill_Generation bg = new Bill_Generation();
                        bg.Show();
                    }
                    else
                    {
                        MessageBox.Show("Choose User Type \n\nAre You a \n\nMANAGER or CASHIER");
                    }
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "No Account Found!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error! " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text = "Password";
            textBox3.Text = "";
            textBox3.Text = "User Id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forgot_password fp = new Forgot_password();
            this.Hide();
            fp.Show();
        }
    }
}
