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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            Hide();
            reservationForm.Show();
        }
    }
}
