using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices; 

namespace Simple_Word
{
    public partial class Form1 : Form
    { 
        int Minute = DateTime.Now.Minute;
            int Hour = DateTime.Now.Hour;
            int Seconds = DateTime.Now.Second;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = Hour + 1;
            numericUpDown2.Value = Minute + 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Minute = DateTime.Now.Minute;
            Hour = DateTime.Now.Hour;
            Seconds = DateTime.Now.Second;

            label5.Text = Hour + ":" + Minute + ":" + Seconds;


            int H = int.Parse(numericUpDown1.Value.ToString());
            int M = int.Parse(numericUpDown2.Value.ToString());

            if (H == 0 && M == 0) return;
         
            if (ShutDown.Checked)
            {
                if (Minute == M && Hour == H)
                {
                    Process.Start("shutdown", "/s /t 0");
                //    timer1.Enabled = false;
                  //  return;
                }
            }
            if (Restart.Checked)
            {
                if (Minute == M && Hour == H)
                {
                    Process.Start("shutdown", "/r /t 0"); 
                    //timer1.Enabled = false;
                    //return;
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
