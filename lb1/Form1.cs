using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lb1.MyClasses;

namespace lb1
{
    public partial class Form1 : Form
    {
        Store data;
        public Form1()
        {
            InitializeComponent();
            data = new Store();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            data.AddItem("name");
            richTextBox1.Text += data.GetListAsText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox2.Text += "кол-во свежих товаров " + data.CalculateCountOnCounter() + '\n';
            richTextBox2.Text += "кол-во просроченных товаров " + data.CalculateCountNotOnCounter() + '\n';
        }
    }
}
