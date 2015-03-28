using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            trans.Text = "";
            StreamReader myPage = new StreamReader("Words.txt", Encoding.Default);
            Hashtable hash = new Hashtable();
            string[] split;
            string words;

            while ((words = myPage.ReadLine()) != null)
            {
                split = words.Split(' ');
                if (split[0] == "") break;
                hash.Add(split[1], split[0]);

            }

            string[] another = Words.Text.Split(' ');

            for (int i = 0; i < another.Length; ++i)
            {
                if (hash.Contains(another[i]))
                {
                    trans.Text += hash[another[i]].ToString();
                    trans.Text += "  ";
                    
                }

            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            trans.Text = "";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textBox1.UseSystemPasswordChar = false;



        }
    }
}
