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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joeld\OneDrive\Documents\Visual Studio 2015\Projects\Mini_Project\Supermarket_Management.mdf;Integrated Security=True;Connect Timeout=30");

        void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Product_Category";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from Product";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " +ex.Message);
            }
        }

        private void Inventory_Management_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
