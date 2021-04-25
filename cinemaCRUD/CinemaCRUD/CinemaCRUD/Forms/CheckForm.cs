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
    public partial class CheckForm : Form
    {
        static public Dictionary<string, string> Check = new Dictionary<string, string>();
        CheckController checkController = new CheckController();
        private List<int> rows = new List<int>();
        private List<int> seats = new List<int>();
        public CheckForm()
        {
            InitializeComponent();
            var a = Check.Keys.ToArray();
            List<Label> lColors = Controls.OfType<Label>().ToList();
            List<TextBox> ltext = Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < Check.Keys.Count; i++)
            {
                if (Check.Keys.ToArray()[i].Contains("Row"))
                    rows.Add(int.Parse(Check.Values.ToArray()[i]));
                if (Check.Keys.ToArray()[i].Contains("Seat"))
                    seats.Add(int.Parse(Check.Values.ToArray()[i]));

            }

            for (int i = 0; i < ltext.Count ; i++)
            {
                var count = 0;
                if (ltext[i].Name == "textBox5")
                {
                    ltext[i].Text = CalculateTheMount(false, 0.0).ToString();
                    continue;
                }
                else if (ltext[i].Name == "textBox3")
                {
                    foreach (var item in rows)
                    {
                        ltext[i].Text += item.ToString() ;
                        if (!(rows.Count - count == 1))
                            ltext[i].Text += ",";
                        count++;
                    }
                }
                else if (ltext[i].Name == "textBox4")
                {
                    count = 0;
                    foreach (var item in seats)
                    {
                        ltext[i].Text += item.ToString();
                        if (!(rows.Count - count == 1))
                            ltext[i].Text += ",";
                        count++;
                    }
                }
                else if (ltext[i].Name == "textBox2")
                {
                    ltext[i].Text = Check.Values.ToArray()[0];
                }
                if (ltext[i].Name == "textBox1")
                {
                    ltext[i].Text = Check.Values.ToArray()[1];
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkController.Add(textBox1.Text, textBox4.Text, textBox3.Text, int.Parse(textBox5.Text), textBox2.Text);
        }


        

        private void CheckForm_Load(object sender, EventArgs e)
        {

        }

        private double CalculateTheMount(bool Discounts, double discountCount)
        {
            int amount = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i] > 2)
                    amount += 250;
                else if (rows[i] > 4)
                    amount += 400;
                else
                    amount += 150;

                
            }
            if (!Discounts)
                return amount;
            else
                return amount * discountCount;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
