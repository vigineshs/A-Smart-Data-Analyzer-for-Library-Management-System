using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Reader;

namespace CS203_Start_Stop_Debug
{
    static class Program
    {
        public static HighLevelInterface ReaderXP = new HighLevelInterface();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}