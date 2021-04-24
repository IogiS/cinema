using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaCRUD
{
    public partial class AddFilmForm : Form
    {
        public string path { get; set; }
        public List<string> sessions { get; set; }
        public List<string> newSessions = new List<string> { };
        FilmController filmController;
        SessionController sessionController;
        public AddFilmForm()
        {
            InitializeComponent();
            filmController = new FilmController();
            sessionController = new SessionController();
            initializeCombo();
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
            sessions = sessionController.Shows(FileWorker.pathToSession);

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < sessions.Count; j++)
                {
                    var s = JsonConvert.DeserializeObject<SessionModel>(sessions[j]);
                    if ((bool)dataGridView1.Rows[i].Cells[1].Value)
                    {

                        var a = s.timeSession.ToString();
                        newSessions.Add(a);
                    }


                }
            }

            int err = 0;
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text)) err++;
                }
            }
            if (err > 0)
                MessageBox.Show($"Неправильно заполнены поля ({err})");
            else
            {
                filmController.Add(textBox1.Text, comboBox2.Text, textBox4.Text, textBox3.Text, textBox2.Text, newSessions, path);
            }
            
       }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int err = 0;
                foreach (Control c in Controls)
                {
                    if (c is TextBox)
                    {
                        if (string.IsNullOrEmpty((c as TextBox).Text)) err++;
                    }
                }
                if (err > 0)
                    MessageBox.Show($"Неправильно заполнены поля ({err})");
                else
                {
                    // необходимые действия
                    sessionController.Add(dateTimePicker1.Value);
                    MessageBox.Show("Сеанс добавлен успешно!", "Успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void initializeCombo()
        {
            dataGridView1.Rows.Clear();

            sessions = sessionController.Shows(FileWorker.pathToSession);

            for (int i = 0; i < sessions.Count; i++)
            {
                var s = JsonConvert.DeserializeObject<SessionModel>(sessions[i]);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = s.timeSession;
                dataGridView1.Rows[i].Cells[1].Value = false;

            }
            var a  = dataGridView1.Rows[0].Cells[1].Value;



        }

    }
}
