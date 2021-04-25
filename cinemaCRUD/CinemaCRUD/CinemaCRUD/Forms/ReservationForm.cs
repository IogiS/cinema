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
        int numberOfTicket = 0;
        public ReservationForm()
        {
            
            int row = 0;
            InitializeComponent();
            int j = 0;
            List<Button> lColors = Controls.OfType<Button>().ToList();
            for (int i = 0; i < lColors.Count; i++)
            {
                if (lColors[i].TabIndex == 85)
                    break;
                if (i % 12 == 0)
                {
                    j = 0;
                    row += 100;
                }

                j++;
                lColors[i].Text = j.ToString();
                lColors[i].Name = (row + j).ToString();

            }

            label1.Text = CheckForm.Check["Time"];
            label2.Text = CheckForm.Check["Film"];
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            string place = ((Button)sender).Text;
            DialogResult result = MessageBox.Show(
            "Забронировать место?",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                numberOfTicket++;
                ((Button)sender).Enabled = false;
                ((Button)sender).Text = "";
                CheckForm.Check.Add("Row" + numberOfTicket, (int.Parse(((Button)sender).Name) / 100).ToString()) ;
                CheckForm.Check.Add("Seat" + numberOfTicket, (int.Parse(((Button)sender).Name) % 100).ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        void reservate()
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            CheckForm checkForm = new CheckForm();
            checkForm.Show();
        }
    }
}
