using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW
{
    public partial class Form1 : Form
    {
        //trackers
        bool paused = false;
        bool reset = true;
        
        //initialize start time
        DateTime startTime = DateTime.MinValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!paused && reset)
            {
                //start over
                startTime = DateTime.Now;
                paused = false;
                reset = false;
            }
            else if (!paused && !reset)
            {
                //pause
                TimeSpan newb = DateTime.Now - startTime;
                startTime = DateTime.MinValue + newb;
                //MessageBox.Show("counted seconds: " + (DateTime.Now - startTime).ToString());
                paused = true;
            }
            else if(paused)
            {
                //resume
                TimeSpan newb = DateTime.Now - startTime;
                startTime = DateTime.MinValue + newb;
                paused = false;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reset
            startTime = DateTime.MinValue;
            label1.Text = "00:00:00.0000000";
            paused = false;
            reset = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //update
            if (!paused)
            {
                label1.Text = startTime == DateTime.MinValue ? "00:00:00.0000000" : (DateTime.Now - startTime).ToString();
            }
            
        }

        
    }
}
