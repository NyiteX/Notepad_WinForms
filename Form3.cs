using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form3 : Form
    {
        public Point p;
        string buffer ="";
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Point pe,Basic_Window B)
        {
            InitializeComponent();
            Left = pe.X-220;
            Top = pe.Y+50;
            B2 = B;
        }
        Basic_Window B2;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }
        private void X_Button_MouseEnter(object sender, EventArgs e)
        {
            X_Button.BorderStyle = BorderStyle.Fixed3D;
            X_Button.BackColor = Color.Thistle;
        }
        private void X_Button_MouseLeave(object sender, EventArgs e)
        {
            X_Button.BorderStyle = BorderStyle.FixedSingle;
            X_Button.BackColor = Color.WhiteSmoke;
        }
        private void X_Button_Click(object sender, EventArgs e)
        {
            if (buffer.Length == 0)
                buffer = B2.textBox1.Text;
            else
            {
                B2.textBox1.Text = buffer;
                buffer = "";
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                if(B2.textBox1.Text.Contains(textBox1.Text))
                {
                    if (buffer.Length == 0)
                        buffer = B2.textBox1.Text;
                    else
                    {
                        B2.textBox1.Text = buffer;
                        buffer = "";
                    }
                    B2.textBox1.Text = B2.textBox1.Text.Replace(textBox1.Text, textBox1.Text.ToUpper());

                }
            }
        }
    }
}
