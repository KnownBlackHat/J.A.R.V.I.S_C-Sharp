using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace First_GUI
{
    public partial class GUI : Form
    {
        SpeechSynthesizer talk = new SpeechSynthesizer();
        bool wake = false;

        Choices list = new Choices();

        

        public GUI()
        {
            InitializeComponent();
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(new String[] { "hello", "how are you", "what is the time", "what is today", "open google", "jarvis" });
            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                say("Voice Recognition is not working right now!");
            }
            talk.SelectVoiceByHints(VoiceGender.Male);
            talk.Speak("Initialising System!");
            if (DateTime.Now.Hour < 12)
            {
            gree.Text="Good Morning!";

            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 17)
            {
                gree.Text = "Good Afternoon!";
            }
            else
            {
                gree.Text = "Good Evening!";
            }
        }

        public void say(String h)
        {
            output.AppendText(h + "\r\n");
            talk.SpeakAsync(h);
            wake = false;
            label3.Text = "SLEEP";
            stat1.Text = "";
       
        }
        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //gree.Text="Good Morning!";
            if (e.Result.Text == "jarvis")
            {
                wake = true;
                label3.Text = "";
                stat1.Text = "LISTENING";
            }
                if (wake == true)
                {
                    string r = e.Result.Text;
                    //input.AppendText(r + "\r\n");
                    wake = true;
                    switch (e.Result.Text)
                    {
                        case "hello":
                            say("Hi!");
                            break;
                        case "how are you":
                            say("Great, and you?");
                            break;
                        case "what is the time":
                            say(DateTime.Now.ToString("h:mm tt"));
                            break;
                        case "what is today":
                            say(DateTime.Now.ToString("M/d/yyyy"));
                            break;
                        case "open google":
                            say("Launching Google!");
                            Process.Start("https://google.com");
                            break;
                    }
                }
            }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            wake = true;
            stat1.Text = "LISTENING";
            label3.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void stat1_Click(object sender, EventArgs e)
        {
            wake = false;
            stat1.Text = "";
            label3.Text = "SLEEP";
        }
    }
}
