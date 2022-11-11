using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        Point p;
        int num = -1;        
        public string Str { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(int n)
        {
            InitializeComponent();
            num = n;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (num == 0)
            {
                try
                {
                    using (StreamWriter F = new StreamWriter(textBox1.Text))
                    {
                        await F.WriteLineAsync(Str);
                    }
                }
                catch (Exception E) { MessageBox.Show(E.Message); }
            }
            else if(num == 1)
            {
                if (System.IO.File.Exists(textBox1.Text))
                {
                    using (StreamReader F = new StreamReader(textBox1.Text))
                    {
                        Str = F.ReadToEnd();
                    }
                }
                else
                    MessageBox.Show("Не найдено");
            }
            
            Close();
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
            Close();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }
    }
}
