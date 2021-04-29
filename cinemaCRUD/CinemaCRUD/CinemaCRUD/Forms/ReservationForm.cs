using CinemaCRUD.Controller;
using Newtonsoft.Json;
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
        CheckController checkController;
        int numberOfTicket = 0;
        public ReservationForm()
        {
            
            
            InitializeComponent();
            checkController = new CheckController();
            ChangePlaces();
        }
        void ChangePlaces()
        {
            int row = 0;
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
            Reservate();
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

        void Reservate()
        {
            var a = checkController.Shows(FileWorker.pathToChecks);
            for (int i = 0; i < a.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<CheckModel>(a[i]);
                if (s.Name == label1.Text && s.Session == label2.Text)
                {
                    List<Button> lColors = Controls.OfType<Button>().ToList();
                    for (int j = 0; j < lColors.Count; j++)
                    {
                        for (int k = 0; k < s.Rows.Split(',').Count(); k++)
                        {
                            var b = (int.Parse(s.Rows.Split(',')[k]) * 100 + int.Parse(s.Seats.Split(',')[k])).ToString();
                            if (lColors[j].Name == b)
                            {
                                lColors[j].Enabled = false;
                                lColors[j].Text = "";
                            }
                        }
                    }
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckForm.Check.ContainsKey("Row1") || !CheckForm.Check.ContainsKey("Seat1"))
            {
                MessageBox.Show("Вы не забронировали ни одного места!","ОшибОчка");
            }
            else
            {
                Hide();
                CheckForm checkForm = new CheckForm();
                checkForm.Show();
            }
           
        }

    }
}
