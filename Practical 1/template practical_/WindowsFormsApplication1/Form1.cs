using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// needed for circumventing XP - SAPI interaction bug 
using System.Threading;

// additionally needed libraries
using System.Speech.Synthesis;
using System.Speech.Recognition;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // init GUI
        public Form1()
        { InitializeComponent(); }

        // init speechrecognition Engine
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();

        // generic function which uses methods of SpeechRecognitionEngine objects
        private void genericFunction()
        {
            // start new thread to control for XP - SAPI bug
            Thread t1 = new Thread(delegate()
            {

                // call methods of SpeechRecognitionEngine object here
                // ...

                // use delegate to access GUI element not created in this thread
                // for example update hearbox textbox on form with the string 'herkend!'
                String word = "herkend!";  
                hearBox.Invoke(new UpdateTextCallback(this.UpdatehearBox), word);         
            });

            // set right state for thread and start
            t1.SetApartmentState(ApartmentState.MTA);
            t1.Start();
        }

        // update function
        private void UpdatehearBox(string word)
        { 
            // function to update hearBox
        }
    }

    // delegate needed for communication between threads
    public delegate void UpdateTextCallback(string word);
}
