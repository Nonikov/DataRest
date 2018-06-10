﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DalRest;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Facade facade;
        public Form1()
        {
            InitializeComponent();
            facade = new Facade();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = facade.GetRecipes();
        }
    }
}