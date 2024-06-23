using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class MainForm : Form
    {
        enum operation {empty, plus, minus, multiply, devide, percent };
        operation oper=operation.empty;
        double number;

        public MainForm()
        {
            InitializeComponent();

            button_0.Click += NumberButton_Click;
            button_1.Click += NumberButton_Click;
            button_2.Click += NumberButton_Click;
            button_3.Click += NumberButton_Click;
            button_4.Click += NumberButton_Click;
            button_5.Click += NumberButton_Click;
            button_6.Click += NumberButton_Click;
            button_7.Click += NumberButton_Click;
            button_8.Click += NumberButton_Click;
            button_9.Click += NumberButton_Click;
            button_dot.Click += NumberButton_Click;
          
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            label_result.Text = String.Empty;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button=(Button)sender;
            label_result.Text += button.Text;
        }

        private void Check_Operation(operation oper, ref double number)
        {
            if(oper==operation.empty)
            {
                number = double.Parse(label_result.Text);
            }
            else
            {
                if(oper == operation.plus)
                {
                    number += double.Parse(label_result.Text);
                }
                else if (oper == operation.minus)
                {
                    number -= double.Parse(label_result.Text);
                }
                else if (oper == operation.multiply)
                {
                    number *= double.Parse(label_result.Text);
                }
                else if(oper == operation.devide)
                {
                    number /= double.Parse(label_result.Text);
                }
                else
                {
                    number = number / double.Parse(label_result.Text) * 100;
                }
            }
        }


        private void button_plus_Click(object sender, EventArgs e)
        {           
            Check_Operation(oper, ref number);
            label_result.Text = String.Empty;
            oper = operation.plus;
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            Check_Operation(oper, ref number);
            label_result.Text = String.Empty;
            oper = operation.minus;
        }

        private void button_mult_Click(object sender, EventArgs e)
        {
            Check_Operation(oper, ref number);
            label_result.Text = String.Empty;
            oper = operation.multiply;
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            Check_Operation(oper, ref number);
            label_result.Text = String.Empty;
            oper = operation.devide;
        }

        private void button_perc_Click(object sender, EventArgs e)     //Считает, сколько процентов одно число составляет от другого
        {
            Check_Operation(oper, ref number);
            label_result.Text = String.Empty;
            oper = operation.percent;
        }

        private void button_equ_Click(object sender, EventArgs e)
        {
            Check_Operation(oper, ref number);           
            label_result.Text=number.ToString();
            if(oper==operation.percent)
            {
                label_result.Text += "%";
                MessageBox.Show("Result is "+ label_result.Text+"\nPlease, click on CE");
            }
            oper = operation.empty;
        }

        private void button_CE_Click(object sender, EventArgs e)
        {
            number = 0;
            label_result.Text = String.Empty;
            oper = operation.empty;
        }

        
    }
}
