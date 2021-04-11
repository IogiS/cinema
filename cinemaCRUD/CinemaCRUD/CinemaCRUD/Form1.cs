using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int j = 0;
            List<Button> lColors = this.Controls.OfType<Button>().ToList();
            for (int i = 0; i < lColors.Count; i++)
            {
                if (i%12 == 0)
                    j = 0;
            j++;
            lColors[i].Text = j.ToString();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string place = ((Button)sender).Text;
            DialogResult result = MessageBox.Show(
            "Окрасить кнопку в красный цвет?",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                ((Button)sender).BackColor = Color.Red;
        }
    }
}
