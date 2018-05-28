using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Trollface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.BackColor = Color.Fuchsia;
            this.TransparencyKey = this.BackColor;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            while (this.Visible)
            {
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(10);
                this.Location = new Point(Cursor.Position.X - 195, Cursor.Position.Y - 160);
                this.Focus();
            }
            System.Windows.Forms.Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
