using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaCRUD
{
    public partial class AddFilmForm : Form
    {
        public string path { get; set; }
        FilmController filmController;
        List<int> idSession = new List<int>() { 0, 1 };
        public AddFilmForm()
        {
            InitializeComponent();
            filmController = new FilmController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            path = file.FileName;
            pictureBox1.ImageLocation = path;
        }

        private void AddFilmForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filmController.Add(textBox1.Text,comboBox2.Text,textBox4.Text,textBox3.Text,textBox2.Text, idSession,path);
            
        }
    }
}
