using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp8
{
    public partial class Basic_Window : Form
    {
        Point p;
        Thread thread;
        string buffer;
        List<string> back_buffer = new List<string>();
        bool changes = false;
        public Basic_Window()
        {
            InitializeComponent();
            ToolStripMenuItem file = new ToolStripMenuItem("Файл");
            ToolStripMenuItem pravka = new ToolStripMenuItem("Правка");

            file.DropDownItems.Add(new ToolStripMenuItem("Создать"));
            file.DropDownItems.Add(new ToolStripMenuItem("Новое окно"));
            file.DropDownItems.Add(new ToolStripMenuItem("Открыть..."));
            file.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));
            file.DropDownItems.Add(new ToolStripMenuItem("Сохранить как..."));

            pravka.DropDownItems.Add("Отменить");
            pravka.DropDownItems.Add("Вырезать");
            pravka.DropDownItems.Add("Копировать");
            pravka.DropDownItems.Add("Вставить");
            pravka.DropDownItems.Add("Удалить");
            pravka.DropDownItems.Add("Найти");

            menuStrip1.Items.Add(file);
            menuStrip1.Items.Add(pravka);
            menuStrip1.ForeColor = textBox1.ForeColor;

            file.DropDownItems[0].Click += File_Create;
            file.DropDownItems[1].Click += open;
            file.DropDownItems[2].Click += File_Open;
            file.DropDownItems[3].Click += Save_File;
            file.DropDownItems[4].Click += SaveAS_File;
            pravka.DropDownItems[0].Click += Pravka_back_edit;
            pravka.DropDownItems[1].Click += Pravka_edit;
            pravka.DropDownItems[2].Click += Pravka_copy;
            pravka.DropDownItems[3].Click += Pravka_paste;
            pravka.DropDownItems[4].Click += Pravka_delete;
            pravka.DropDownItems[5].Click += Pravka_Search;
        }

        //Basic_Window
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }
        private void Basic_Window_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void Basic_Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }

        //Basic_buttons
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Minimize_Button.BorderStyle = BorderStyle.Fixed3D;
            Minimize_Button.BackColor = Color.Khaki;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Minimize_Button.BorderStyle = BorderStyle.FixedSingle;
            Minimize_Button.BackColor = Color.WhiteSmoke;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
            try
            {
                thread.Abort();
            }
            catch (Exception) { }
            Close();
        }

        //My funcs
        public void Pravka_Search(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                thread = new Thread(() =>
                {
                    Form3 form = new Form3(new Point(Right, Top),this);
                    System.Windows.Forms.Application.Run(form);
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                //thread.Join();
            }
            else
                MessageBox.Show("Текст пуст");
        }
        public void Pravka_back_edit(object sender, EventArgs e)
        {
            if (back_buffer.Count > 0)
            {
                textBox1.Text = back_buffer[back_buffer.Count - 1];
                back_buffer.RemoveAt(back_buffer.Count - 1);
            }
        }
        public void Pravka_edit(object sender, EventArgs e)
        {
            back_buffer.Add(textBox1.Text);
            buffer = textBox1.SelectedText;         
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart,textBox1.SelectionLength);
        }
        public void Pravka_delete(object sender, EventArgs e)
        {
            back_buffer.Add(textBox1.Text);
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, textBox1.SelectionLength);
        }
        private void open(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                Basic_Window form = new Basic_Window();

                System.Windows.Forms.Application.Run(form);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void Read_File(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists("test.txt"))
                    using (StreamReader F = new StreamReader("test.txt"))
                    {
                        textBox1.Text = F.ReadToEnd();
                    }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }
        private async void Save_File(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter F = new StreamWriter("Note.txt"))
                { 
                    await F.WriteLineAsync(textBox1.Text);
                }
                MessageBox.Show("Сохранено");
                changes = false;
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }
        private void SaveAS_File(object sender, EventArgs e)
        {
            Form2 tmpForm = new Form2(0);
            tmpForm.Str = textBox1.Text;
            tmpForm.Show();
            changes = false;
        }
        private void File_Create(object sender, EventArgs e)
        {
            if(changes)
            {
                Save_File(sender, e);
            }

            open(sender, e);
            Close();
        }
        private void Pravka_copy(object sender, EventArgs e)
        {
            buffer = textBox1.SelectedText;
        }
        private void Pravka_paste(object sender, EventArgs e)
        {
            textBox1.SelectedText = buffer;
        }
        private void File_Open(object sender, EventArgs e)
        {
            Form2 form = new Form2(1);
            form.Str = textBox1.Text;
            form.ShowDialog();
            textBox1.Text = form.Str;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }       
    }
}
