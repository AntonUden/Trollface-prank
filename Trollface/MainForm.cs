using System;
using System.Drawing;
using System.Timers;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Trollface
{
	public partial class MainForm : Form
	{
		public TrollForm TrollForm;

		public MainForm()
		{
			InitializeComponent();
		}

		public void StartTrollForm()
		{
			if(TrollForm != null)
			{
				TrollForm.AllowClose = true;
				TrollForm.Close();
				TrollForm = null;
			}

			TrollForm = new TrollForm();
			TrollForm.Show();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SoundPlayer sndplayr = new SoundPlayer(Properties.Resources.trololo);
			sndplayr.PlayLooping();
			StartTrollForm();

			FormBorderStyle = FormBorderStyle.None;
			ShowInTaskbar = false;
			this.Size = new Size(0,0);

			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Elapsed += ReTrollCheck;
			timer.AutoReset = true;
			timer.Interval = 100;
			timer.Start();
		}

		private void ReTrollCheck(Object source, ElapsedEventArgs e)
		{
			Invoke(new MethodInvoker(() => {
				if(TrollForm != null)
				{
					if(TrollForm.Visible)
					{
						if(TrollForm.Location.X == 0 && TrollForm.Location.Y == 0)
						{
							Point cursor = GetCursorPosition();

							if (!(cursor.X == 0 && cursor.Y == 0))
							{
								StartTrollForm();
							}
						}
					}
				}
			}));
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		/// Struct representing a point.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public static implicit operator Point(POINT point)
			{
				return new Point(point.X, point.Y);
			}
		}

		/// <summary>
		/// Retrieves the cursor's position, in screen coordinates.
		/// </summary>
		/// <see>See MSDN documentation for further information.</see>
		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out POINT lpPoint);

		public static Point GetCursorPosition()
		{
			POINT lpPoint;
			GetCursorPos(out lpPoint);
			// NOTE: If you need error handling
			// bool success = GetCursorPos(out lpPoint);
			// if (!success)

			return lpPoint;
		}
	}
}