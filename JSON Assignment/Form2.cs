using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON_Assignment
{
    public partial class Form2 : Form
    {
        Random randomIndex = new Random();
        public string GamePath;
        int tracker,userlife= 0;
        int fails = 3;
        string response;
        private object quizpath;
        private string userResponse;

        public Form2()
        {
            InitializeComponent();
        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetJsonData (GamePath);
            userlife = 3;
        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            userResponse= btnOption1.Text;
            VerifyUserResponses(GamePath);
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            userResponse = btnOption2.Text;
            VerifyUserResponses(GamePath);
        }
        public void GetJsonData(string filelocation)
        {

            string jsontext = File.ReadAllText(filelocation);
            var quizdata = Newtonsoft.Json.JsonConvert.DeserializeObject<RepQuiz>(jsontext);
            tracker = randomIndex.Next(0, quizdata.questions.Length - 1);
            listBox1.Items.Clear();
            listBox1.Items.Add(quizdata.questions[tracker].question);
            btnOption1.Text = quizdata.questions[tracker].options[0];
            btnOption2.Text = quizdata.questions[tracker].options[1];
        }
        public void VerifyUserResponses(string filelocation)
        {
            string jsontext = File.ReadAllText(filelocation);
            var quizdata = Newtonsoft.Json.JsonConvert.DeserializeObject<RepQuiz>(jsontext);
            if (listBox1.Items.Contains(quizdata.questions[tracker].question) && userResponse == quizdata.questions[tracker].answer)
            {
              DialogResult res=  MessageBox.Show(quizdata.questions[tracker].correct_feadback, "",MessageBoxButtons.OK); 
                if (res==DialogResult.OK)
                {
                    GetJsonData(GamePath);
                }
            }
            else 
            {
                userlife--;
                TrackUserLife(userlife);

               DialogResult res= MessageBox.Show(quizdata.questions[tracker].wrong_feadback, "", MessageBoxButtons.OK);
            }
        }
        public void TrackUserLife (int userlife)
        {
            if (userlife ==0)
            {
                MessageBox.Show("oops try again later,system shut down");
                Application.Exit ();
            }
        }
    }
}
