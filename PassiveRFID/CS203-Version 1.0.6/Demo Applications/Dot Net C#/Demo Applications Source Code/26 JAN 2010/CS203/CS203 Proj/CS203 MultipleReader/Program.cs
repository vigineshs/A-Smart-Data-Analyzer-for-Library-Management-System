using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CSLibrary;

namespace CS203_MultipleReader
{
    static class Program
    {
        public static List<string> ConnectIPList = new List<string>();
        public static List<HighLevelInterface> ReaderList = new List<HighLevelInterface>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                /*****************  Connection START  *****************/

                if (new SearchReaderForm().ShowDialog() == DialogResult.OK)
                {
                    foreach (string ip in ConnectIPList)
                    {
                        CSLibrary.Windows.UI.SplashScreen.Show(CSLibrary.Windows.UI.SplashScreen.CSL.CS203);

                        /* You can start separate thread to speed up connection time */
                        /* TODO : */

                        HighLevelInterface localReader = new HighLevelInterface();
                        if (localReader.Connect(ip, 60 * 1000) == CSLibrary.Constants.Result.OK)
                        {
                            localReader.Name = ip;
                            ReaderList.Add(localReader);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Error::Connect Reader <{0}> failed", ip));
                        }
                    }

                    /*****************  Application START  *****************/

                    Application.Run(new ReadTagForm());

                    /*****************  Application END  *****************/

                }
                else
                {
                    return;
                }


                /*****************  Dispose START  *****************/

                foreach (HighLevelInterface reader in ReaderList)
                {
                    reader.Disconnect();
                    reader.Dispose();
                }

                ReaderList.Clear();

                CSLibrary.Windows.UI.SplashScreen.Stop();
                /*****************  Dispose END  *****************/

                /*****************  Connection END  *****************/

            }
        }
    }
}