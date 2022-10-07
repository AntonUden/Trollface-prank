using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Trollface
{
    public partial class TrollForm : Form
    {
        public bool AllowClose = false;

        private System.Timers.Timer timer;

        public TrollForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
            BackColor = Color.Fuchsia;
            TransparencyKey = BackColor;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;

            timer = new System.Timers.Timer();
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Interval = 10;
            timer.Start();

#if DEBUG
            AllowClose = true;
#endif
        }

        public void TeleportWindow()
		{
            if (Visible)
            {
                Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height / 2);
                Focus();
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() => { TeleportWindow(); }));
            }
            catch (Exception ex) { }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            if(AllowClose)
			{
                timer.Dispose();
                return;
			}
            e.Cancel = true;
        }

        
    }
}