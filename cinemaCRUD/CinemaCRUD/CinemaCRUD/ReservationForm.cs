﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRUD
{
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
            int j = 0;
            List<Button> lColors = this.Controls.OfType<Button>().ToList();
            for (int i = 0; i < lColors.Count; i++)
            {
                if (i % 12 == 0)
                    j = 0;
                j++;
                lColors[i].Text = j.ToString();

            }
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
