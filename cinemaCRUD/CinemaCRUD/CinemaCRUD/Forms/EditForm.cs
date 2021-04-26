using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaCRUD.Forms
{
    public partial class EditForm : Form
    {
        public List<string> sessions { get; set; }
        public List<string> films { get; set; }
        public string oldname { get; set; }
        FilmController filmController;
        SessionController sessionController;
        public EditForm()
        {
            InitializeComponent();
            filmController = new FilmController();
            sessionController = new SessionController();
            initializeCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sessionController.Delete(DateTime.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), FileWorker.pathToSession);
            initializeCombo();
        }

        public void initializeCombo()
        {
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();

            films = filmController.Shows(FileWorker.pathToDesktopFilms);
            sessions = sessionController.Shows(FileWorker.pathToSession);

            for (int i = 0; i < films.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<FilmModel>(films[i]);
                comboBox1.Items.Add(s.Name);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.Text = comboBox1.Items[0].ToString();

            sessions = sessionController.Shows(FileWorker.pathToSession);
            films = filmController.Shows(FileWorker.pathToDesktopFilms);
            for (int i = 0; i < sessions.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<SessionModel>(sessions[i]);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = s.timeSession;
                dataGridView1.Rows[i].Cells[1].Value = false;
            }

        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            oldname = comboBox1.Text;

            for (int i = 0; i < films.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<FilmModel>(films[i]);
                if (s.Name == oldname)
                {
                    textBox2.Text = s.Description;
                    textBox4.Text = s.AgeRating;
                    textBox1.Text = s.Genre;
                    textBox3.Text = s.Director;
                    for (int r = 0; r < comboBox1.Items.Count; r++)
                    {
                        if (comboBox1.Items[r].ToString() == s.Genre)
                        {
                            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(comboBox1.Items[r]);
                            break;
                        }
                        else
                            comboBox1.Text = "";



                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                filmController.Edit(oldname, comboBox1.Text, FileWorker.pathToDesktopFilms, textBox1.Text, textBox4.Text, textBox3.Text, textBox2.Text);
                initializeCombo();
                MessageBox.Show("Успешно");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filmController.Delete(comboBox1.Text, FileWorker.pathToDesktopFilms);
            initializeCombo();
        }
    }
}
