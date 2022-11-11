namespace WindowsFormsApp8
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.X_Button = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // X_Button
            // 
            this.X_Button.AutoSize = true;
            this.X_Button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.X_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.X_Button.Location = new System.Drawing.Point(184, 0);
            this.X_Button.Name = "X_Button";
            this.X_Button.Size = new System.Drawing.Size(20, 19);
            this.X_Button.TabIndex = 0;
            this.X_Button.Text = "X";
            this.X_Button.Click += new System.EventHandler(this.X_Button_Click);
            this.X_Button.MouseEnter += new System.EventHandler(this.X_Button_MouseEnter);
            this.X_Button.MouseLeave += new System.EventHandler(this.X_Button_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.BorderTemplate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(213, 59);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.X_Button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form3";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label X_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}