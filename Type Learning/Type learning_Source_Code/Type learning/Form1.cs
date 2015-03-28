using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Type_learning
{
    public partial class Form1 : Form
    {
        Button[] a = new Button[59];
        Keys[] b = new Keys[59];
        public Form1()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            a[1] = button1;
            a[2] = button2;
            a[3] = button3;
            a[4] = button4;
            a[5] = button5;
            a[6] = button6;
            a[7] = button7;
            a[8] = button8;
            a[9] = button9;
            a[10] = button10;
            a[11] = button11;
            a[12] = button12;
            a[13] = button13;
            a[14] = button14;
            a[15] = button15;
            a[16] = button16;
            a[17] = button17;
            a[18] = button18;
            a[19] = button19;
            a[20] = button20;
            a[21] = button21;
            a[22] = button22;
            a[23] = button23;
            a[24] = button24;
            a[25] = button25;
            a[26] = button26;
            a[27] = button27;
            a[28] = button28;
            a[29] = button29;
            a[30] = button30;
            a[31] = button31;
            a[32] = button32;
            a[33] = button33;
            a[34] = button34;
            a[35] = button35;
            a[36] = button36;
            a[37] = button37;
            a[38] = button38;
            a[39] = button39;
            a[40] = button40;
            a[41] = button41;
            a[42] = button42;
            a[43] = button43;
            a[44] = button44;
            a[45] = button45;
            a[46] = button46;
            a[47] = button47;
            a[48] = button48;
            a[49] = button49;
            a[50] = button50;
            a[51] = button51;
            a[52] = button52;
            a[53] = button53;
            a[54] = button54;
            a[55] = button55;
            a[56] = button56;
            a[57] = button57;
            a[58] = button58;
            b[1] = Keys.Oemtilde;
            b[2] = Keys.D1;
            b[3] = Keys.D2;
            b[4] = Keys.D3;
            b[5] = Keys.D4;
            b[6] = Keys.D5;
            b[7] = Keys.D6;
            b[8] = Keys.D7;
            b[9] = Keys.D8;
            b[10] = Keys.D9;
            b[11] = Keys.D0;
            b[12] = Keys.OemMinus;
            b[13] = Keys.Oemplus;
            b[14] = Keys.Back;
            b[15] = Keys.Tab;
            b[16] = Keys.Q;
            b[17] = Keys.W;
            b[18] = Keys.E;
            b[19] = Keys.R;
            b[20] = Keys.T;
            b[21] = Keys.Y;
            b[22] = Keys.U;
            b[23] = Keys.I;
            b[24] = Keys.O;
            b[25] = Keys.P;
            b[26] = Keys.OemOpenBrackets;
            b[27] = Keys.OemCloseBrackets;
            b[28] = Keys.OemBackslash;
            b[29] = Keys.Capital;
            b[30] = Keys.A;
            b[31] = Keys.S;
            b[32] = Keys.D;
            b[33] = Keys.F;
            b[34] = Keys.G;
            b[35] = Keys.H;
            b[36] = Keys.J;
            b[37] = Keys.K;
            b[38] = Keys.L;
            b[39] = Keys.OemSemicolon;
            b[40] = Keys.Oem7;
            b[41] = Keys.Return;
            b[42] = Keys.ShiftKey;
            b[43] = Keys.Z;
            b[44] = Keys.X;
            b[45] = Keys.C;
            b[46] = Keys.V;
            b[47] = Keys.B;
            b[48] = Keys.N;
            b[49] = Keys.M;
            b[50] = Keys.Oemcomma;
            b[51] = Keys.OemPeriod;
            b[52] = Keys.OemQuestion;
            b[53] = Keys.ShiftKey;
            b[54] = Keys.ControlKey;
            b[55] = Keys.Menu;
            b[56] = Keys.Space;
            b[57] = Keys.Menu;
            b[58] = Keys.ControlKey;
            for (int i = 1; i < 102; i++)
            {
                listBox1.Items.Add("Level "+i);
                
            }
            listBox1.SelectedIndex = 0;
            btnStart.Focus();
        }
        int length = 0;
        int selected=0;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            
            string number=(listBox1.SelectedIndex+1).ToString();
            try
            {
                richTextBox1.LoadFile(path + "\\Levels\\" + number + ".txt", RichTextBoxStreamType.PlainText);
                selected = listBox1.SelectedIndex;
            }
            catch (Exception)
            {
                
               
            }
            
            length = richTextBox1.Text.Length;
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

     
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            
        }
        int j = 0;
        int wrong = 0;
        bool iswrong =false;
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            for (int i = 1; i < 59; i++)
                {
                    a[i].BackColor = Color.Black;
                    a[i].FlatStyle = FlatStyle.Flat;                    
                }
            e.Handled = true;

            iswrong=false;
            int n = richTextBox1.Find(e.KeyCode.ToString(), 0, -1, RichTextBoxFinds.None);
            richTextBox1.SelectionStart = j;
            richTextBox1.SelectionLength = 1;

            string key;
            if (e.Shift == true)
            {
                key = (e.KeyCode).ToString();
                if (e.KeyCode == Keys.D0)
                    key = ")";
                else if (e.KeyCode == Keys.D1)
                    key = "!";
                else if (e.KeyCode == Keys.D2)
                    key = "@";
                else if (e.KeyCode == Keys.D3)
                    key = "#";
                else if (e.KeyCode == Keys.D4)
                    key = "$";
                else if (e.KeyCode == Keys.D5)
                    key = "%";
                else if (e.KeyCode == Keys.D6)
                    key = "^";
                else if (e.KeyCode == Keys.D7)
                    key = "&";
                else if (e.KeyCode == Keys.D8)
                    key = "*";
                else if (e.KeyCode == Keys.D9)
                    key = "(";
                else if (e.KeyCode == Keys.Oem7)
                    key = "\"";
                else if (e.KeyCode == Keys.Oem1)
                    key = ":";
                else if (e.KeyCode == Keys.OemQuestion)
                    key = "?";
                else if (e.KeyCode == Keys.Oemcomma)
                    key = "<";
                else if (e.KeyCode == Keys.OemMinus)
                    key = "_";
                else if (e.KeyCode == Keys.Oemplus)
                    key = "+";
                else if (e.KeyCode == Keys.OemPeriod)
                    key = ">";
                else if (e.KeyCode == Keys.Oemtilde)
                    key = "~";
                else if (e.KeyCode == Keys.Oem5)
                    key = "|";
                else if (e.KeyCode == Keys.Oem6)
                    key = "}";
                else if (e.KeyCode == Keys.OemOpenBrackets)
                    key = "{";
            }
            else
            {
                key = (e.KeyCode).ToString().ToLower();
                if (e.KeyCode == Keys.Oemcomma)
                    key = ",";
                else if (e.KeyCode == Keys.D0)
                    key = "0";
                else if (e.KeyCode == Keys.D1)
                    key = "1";
                else if (e.KeyCode == Keys.D2)
                    key = "2";
                else if (e.KeyCode == Keys.D3)
                    key = "3";
                else if (e.KeyCode == Keys.D4)
                    key = "4";
                else if (e.KeyCode == Keys.D5)
                    key = "5";
                else if (e.KeyCode == Keys.D6)
                    key = "6";
                else if (e.KeyCode == Keys.D7)
                    key = "7";
                else if (e.KeyCode == Keys.D8)
                    key = "8";
                else if (e.KeyCode == Keys.D9)
                    key = "9";
                else if (e.KeyCode == Keys.Oemcomma)
                    key = ",";
                else if (e.KeyCode == Keys.Oem7)
                    key = "'";
                else if (e.KeyCode == Keys.Oem5)
                    key = "\\";
                else if (e.KeyCode == Keys.Oem1)
                    key = ";";
                else if (e.KeyCode == Keys.Oem6)
                    key = "[";
                else if (e.KeyCode == Keys.OemOpenBrackets)
                    key = "]";

                else if (e.KeyCode == Keys.OemPeriod)
                    key = ".";
                else if (e.KeyCode == Keys.Oemplus)
                    key = "=";
                else if (e.KeyCode == Keys.OemMinus)
                    key = "-";
                else if (e.KeyCode == Keys.Oemtilde)
                    key = "`";
                else if (e.KeyCode == Keys.OemQuestion)
                    key = "/";

            }

            if (key == "ShiftKey")
                return;
            if (richTextBox1.SelectedText == key )
            {

                richTextBox1.SelectedText = "";
                iswrong = false;
            }
            else if (e.KeyCode == Keys.Enter && richTextBox1.SelectedText=="\n")
            {
                richTextBox1.SelectedText = "";
                iswrong = false;
            }
            else if (e.KeyCode == Keys.Space && richTextBox1.SelectedText == " ")
            {
                richTextBox1.SelectedText = "";
                iswrong = false;
            }
            
            else
            {
                richTextBox1.SelectionColor = Color.Red;
                Console.Beep(2500, 500); 
                richTextBox1.SelectionLength = 0;
                wrong++;
                lblwrong.Text = wrong.ToString();
                iswrong=true;


            }
            if (!iswrong)
            {
                for (int i = 1; i < 59; i++)
                if (e.KeyCode == b[i])
                {
                    a[i].FlatStyle = FlatStyle.Flat;
                    a[i].BackColor = Color.Blue;
                }
            }
            else
               for (int i = 1; i < 59; i++)
                if (e.KeyCode == b[i])
                {
                    a[i].FlatStyle = FlatStyle.Flat;
                    a[i].BackColor = Color.Red;
                }
            lblpased.Text = ((int)(((length - richTextBox1.Text.Length) / (float)length) * 100)).ToString() + "%"; 
            if (richTextBox1.Text == "")
            {
                string str= (((length - wrong) / (float)length) * 100).ToString() + "%";
                listBox1.Items[selected] ="Level "+(selected+1).ToString()+" -  " + str + "  -  "+lblTimer.Text;
                richTextBox1.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show("You pass Level "+ (selected+1).ToString() + " at " +lblTimer.Text+ "  "+ str,"Result");
                listBox1.SelectedIndex=selected + 1;
                listBox1.Focus();
            }

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!iswrong)
            for (int i = 1; i < 59; i++)
                if (e.KeyCode == b[i])
                {
                    a[i].BackColor = Color.Black;
                    a[i].FlatStyle = FlatStyle.Flat;
                }
        }

        private void richTextBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button59_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        static int d5, d6, d3, d4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = d6.ToString() + d5.ToString() + ":" + d4.ToString() + d3.ToString();
            d3++;
            if (d3 == 10)
            {
                d3 = 0;
                d4++;
            }
            if (d4 == 6)
            {
                d4 = 0;
                d5++;
            }
            if (d5 == 10)
            {
                d5 = 0;
                d6++;
            }
            if (d6 == 6)
            {
                d6 = 0;
                timer1.Enabled = false;
            }
            

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            wrong = 0;
            lblwrong.Text = "0";
            timer1.Enabled = true;
            d3 = 1;
            d4 = 0;
            d5 = 0;
            d6 = 0;
            lblTimer.Text = d6.ToString() + d5.ToString() + ":" + d4.ToString() + d3.ToString();
            richTextBox1.Enabled = true;
            richTextBox1.Focus();
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                listBox1_SelectedIndexChanged(null, null);
                btnStart.Focus();
            }

        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button59_Click_1(object sender, EventArgs e)
        {
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            btnStart.Focus();
        }

        private void lblpased_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }
    }
}
