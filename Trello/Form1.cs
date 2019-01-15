using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;

namespace Trello
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices Clist=new Choices();
        Choices Clist2 = new Choices();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ss.SelectVoiceByHints(VoiceGender.Male);
            
            MaximizeBox = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            ss.Speak("Hi Sir. I am trello. A customer service Pizza bot. How can I help you?");
            Clist.Add(new string[] { "Good morning","can I order a pizza?", "what are the types you have?",
                "what is the time", "what are the prizes for large pizzas?", "thank you", "close", " what are the sizes you have?",
                "Who are you?","At what time are you open?", "I want to order online" });
           
            Grammar gr = new Grammar(new GrammarBuilder(Clist));

            // Clist2.Add(new string[] { "good morning","good night" });
            // Grammar gr2 = new Grammar(new GrammarBuilder(Clist2));


            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                //sre.LoadGrammar(gr2);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string str = e.Result.Text.ToString();
            /*if(str=="good morning ")
            {
                ss.Speak("Thank you for the greetings. Wish you the same");

            }*/

            knowledgeBase kb = new knowledgeBase();
            kb.knowledgebase(str);
            /* switch (str)
             {
                 case "good morning ":
                     ss.Speak("Thank you for the greetings. Wish you the same");
                     break;

                 case "can I order a pizza?": 
                     ss.Speak("yes of course sir. what do you prefer?");
                     break;

                 case "what are the types you have?":
                     ss.Speak("we have devilled chicken pizza, cheese pizza and spicy sea food pizza");
                     break;

                 case "what is the time":
                     ss.Speak("current time is " + DateTime.Now.ToLongTimeString());
                     break;

                 case "thank you":
                     ss.Speak(" You are welcome. it is a pleasure to serve you sir");
                     break;

                 case "what are the prizes for large pizzas?":
                     ss.Speak("okay lets see. for devilled chicken it is 1200 rupees. cheese pizza is 1300 rupees. and for spicy sea food pizza it is 1700 rupees");
                   // Process.Start("youtube", " https://www.youtube.com/watch?v=e46jQt4Mnko");
                     break;

                 case "what are the sizes you have?":

                   ss.Speak(" we have large , medium and small size pizzas in all three categories");
                         break;


                 case "close":
                     Application.Exit();
                     break;*/


            txtContent.Text += e.Result.Text.ToString() + Environment.NewLine;


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.pizzahut.lk/Menu.aspx");

        }
    }
}
