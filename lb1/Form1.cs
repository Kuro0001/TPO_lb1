﻿using System;
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
        Mydata data;
        public Form1()
        {
            InitializeComponent();
            data = new Mydata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            data.AddItem();
            richTextBox1.Text += data.GetText();
        }
    }
}