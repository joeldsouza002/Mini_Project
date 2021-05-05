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
    public partial class Forgot_password : Form
    {
        public Forgot_password()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Staff where UserId = '" + textBox3.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                try
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Staff set Password ='" + textBox2.Text + "' where UserId = '" + textBox3.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Successfully Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Account Found With That User ID, Please Contact The Manager!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login li = new Login();
            this.Hide();
            li.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text = "Password";
            textBox3.Text = "";
            textBox3.Text = "User Id";
        }
    }
}
