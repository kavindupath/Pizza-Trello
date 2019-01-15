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
    class knowledgeBase
    {
        SpeechSynthesizer ss1 = new SpeechSynthesizer();
        public void knowledgebase(String stringline)
        {
            switch (stringline)
            {
                case "Good morning ":
                    ss1.Speak("Thank you for the greetings. Wish you the same"); break;

                case "can I order a pizza?":
                    ss1.Speak("yes of course sir. what do you prefer?"); break;

                case "what are the types you have?":
                    ss1.Speak("we have mainly devilled chicken pizzas, cheese pizzas and veggie pizzas in large,medium and small sizes"); break;

                case "what are the sizes you have?":
                    ss1.Speak(" we have large , medium and small size pizzas in all three categories"); break;

                case "what are the prizes for large pizzas?":
                    ss1.Speak("okay lets see. for devilled chicken it is 1200 rupees. cheese pizza is 1300 rupees. and veggie pizza it is 1700 rupees");break;

                case "I want to order online":
                    ss1.Speak("No problem sir. Click the button Please come inside Pizza Trelllo hut below. You will be directed to our amazing web site");break;

                case "At what time are you open?":
                    ss1.Speak("We are open from 8 in the morning till 10 O clock in the night"); break;

                case "what is the time":
                    ss1.Speak("current time is " + DateTime.Now.ToLongTimeString()); break;
                    

                case "thank you":
                    ss1.Speak(" You are welcome. it is a pleasure to serve you sir"); break;

                case "close":
                    Application.Exit(); break;























            }
        }
    }
}
