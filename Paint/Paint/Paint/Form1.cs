using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        int InitialX, InitialY;
        bool CheckPaint = false;
        Color c = Color.Black;

     
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 30; ++i)
            {
                comboBox1.Items.Add(i);

            }
            comboBox1.Text = "1";

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (CheckPaint)
            {
                Graphics g = panel1.CreateGraphics();
                Pen p = new Pen(c, int.Parse(comboBox1.Text));
                g.DrawLine(p, InitialX, InitialY, e.X, e.Y);
                
                InitialX = e.X;
                InitialY = e.Y;
            }


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            InitialX = e.X;
            InitialY = e.Y;
            CheckPaint = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            CheckPaint = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            c = lbl.BackColor;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            c = panel1.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
