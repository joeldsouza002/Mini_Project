using Mini_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Double Result_Value = 0;
        String Operator_Performed = " ";
        bool PerformedOp = false;


        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" || PerformedOp)
                textBox_Result.Clear();

            PerformedOp = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text += button.Text;
            }

            else
            textBox_Result.Text += button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Operator_click_Event(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (Result_Value != 0)
            {
                button16.PerformClick();
                Operator_Performed = button.Text;
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
            else
            {

                Operator_Performed = button.Text;
                Result_Value = Double.Parse(textBox_Result.Text);
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            Result_Value = 0;
            label_Show_Op.Text = " ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (Operator_Performed)
            {
                case "+":
                    textBox_Result.Text = (Result_Value + Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "-":
                    textBox_Result.Text = (Result_Value - Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "*":
                    textBox_Result.Text = (Result_Value * Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "/":
                    textBox_Result.Text = (Result_Value / Double.Parse(textBox_Result.Text)).ToString();
                    break;

                default:
                    break;

            }
            Result_Value = Double.Parse(textBox_Result.Text);
            label_Show_Op.Text = " ";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Login.user == "Manager")
            {
                Manager_Dashboard md = new Manager_Dashboard();
                this.Hide();
                md.Show();
            }
            else
            {
                Bill_Generation md = new Bill_Generation();
                this.Hide();
                md.Show();
            }
        }
    }
}
