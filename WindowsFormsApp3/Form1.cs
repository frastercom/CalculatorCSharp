using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    { 
        private static readonly string findSpaces = @"[\s]+";
        private static readonly string findCommas = @"(?<=\d)\,(?=\d)+";

        private static readonly Regex regexSpaces = new Regex(findSpaces, RegexOptions.Compiled);
        private static readonly Regex regexCommas = new Regex(findCommas, RegexOptions.Compiled);

        private String d = null;
        private String oper = null;
        private bool iscleare = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e) 
        {
            if (textBox1.TextLength > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
                
            }
            if(textBox1.TextLength == 0)
                {
                    textBox1.Text = "0";
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Калькулятор";
            textBox1.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (iscleare)
            {
                textBox1.Text = "0";
            }
            textBox1.Text = textBox1.Text + ((Button)sender).Text;
            iscleare = false;

        }

        private void buttonMath_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                return;

            }
            oper = ((Button)sender).Text;
            d = textBox1.Text;
            iscleare = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                textBox1.Text = String.Format("{0}", double.Parse(textBox1.Text) * -1);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            d = null;
            oper = null;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (oper == "+")
            {
                textBox1.Text = String.Format("{0}", double.Parse(textBox1.Text) + double.Parse(d));
                return;
            }
            if (oper == "-")
            {
                textBox1.Text = String.Format("{0}", double.Parse(d) - double.Parse(textBox1.Text));
                return;
            }
            if (oper == "÷")
            {
                if (double.Parse(textBox1.Text) != 0)
                {
                    textBox1.Text = String.Format("{0}", double.Parse(d) / double.Parse(textBox1.Text));

                    return;
                }
                DialogResult result = MessageBox.Show(
        "Окрасить кнопку в красный цвет?",
        "Сообщение",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
            }
            if (oper == "×")
            {
                textBox1.Text = String.Format("{0}", double.Parse(textBox1.Text) * double.Parse(d));
                return;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Count(t => t == ',') == 1)
            {
                return;
            }
           
            try
            {
                double d = double.Parse(textBox1.Text);
                textBox1.Text = String.Format("{0}", d);
            }
            catch
            {
                if (textBox1.TextLength > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);

                }
                
            }

        }
    }
}
  