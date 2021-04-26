using CinemaCRUD.Forms;
using Newtonsoft.Json;
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
         public static string Film { get; set; }
         public static string Time { get; set; }
        FilmController filmController;
        SessionController sessionController;
        public List<string> films { get; set; }
        public List<string> sessions { get; set; }
        public MainForm()
        {
            InitializeComponent();
            filmController = new FilmController();
            sessionController = new SessionController();
            initializeCombo();
            toolStripMenuItem1.Click += menuStrip1_ItemClicked_1;
            toolStripMenuItem2.Click += menuStrip2_ItemClicked_2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, EventArgs e)
        {

            Hide();
            AddFilmForm addFilmForm = new AddFilmForm();
            addFilmForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int err = 0;
            foreach (Control c in Controls)
            {
                if (c is ComboBox)
                {
                    if (string.IsNullOrEmpty((c as ComboBox).Text)) err++;
                }
            }
            if (err > 0)
                MessageBox.Show($"Не выбраны поля ({err})");
            else
            {
                CheckForm.Check.Add("Film", comboBox1.Text);
                CheckForm.Check.Add("Time", comboBox2.Text);
                ReservationForm reservationForm = new ReservationForm();
                Hide();
                reservationForm.Show();
            }
            
        }
        public void initializeCombo()
        {
            comboBox2.Items.Clear();

            films = filmController.Shows(FileWorker.pathToDesktopFilms);
            sessions = sessionController.Shows(FileWorker.pathToSession);

            for (int i = 0; i < films.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<FilmModel>(films[i]);
                comboBox2.Items.Add(s.Name);

            }
            if (comboBox2.Items.Count < 0)
            {
                comboBox2.Text = comboBox2.Items[0].ToString();
                pictureBox1.ImageLocation = JsonConvert.DeserializeObject<FilmModel>(films[0]).PathToPoster;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = JsonConvert.DeserializeObject<FilmModel>(films[comboBox2.SelectedIndex]).PathToPoster;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkCompability(comboBox2.SelectedIndex);
        }

        void checkCompability(int index)
        {
            try
            {
                comboBox1.Items.Clear();
                var s = JsonConvert.DeserializeObject<FilmModel>(films[index]);
                for (int j = 0; j < sessions.Count; j++)
                {
                    var sb = JsonConvert.DeserializeObject<SessionModel>(sessions[j]);
                    if (s.Session != null)
                    {
                        for (int i = 0; i < s.Session.Count; i++)
                        {
                            if (s.Session[i] == sb.timeSession.ToString())
                            {
                                comboBox1.Items.Add(sb.timeSession);
                            }
                        }
                    }
                    else { throw new Exception("Для выбранного фильма нет сеансов"); }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void menuStrip2_ItemClicked_2(object sender, EventArgs e)
        {
            Hide();
            EditForm editForm = new EditForm();
            editForm.Show();
        }
    }
}
