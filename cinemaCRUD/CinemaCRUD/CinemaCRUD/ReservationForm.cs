using System;
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
            int row = 0;
            InitializeComponent();
            int j = 0;
            List<Button> lColors = this.Controls.OfType<Button>().ToList();
            for (int i = 0; i < lColors.Count; i++)
            {
                if (lColors[i].TabIndex == 85)
                    break;
                if (i % 12 == 0)
                {
                    j = 0;
                    row+=100;
                }
                    
                j++;
                lColors[i].Text = j.ToString();
                lColors[i].Name = (row + j).ToString();

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
