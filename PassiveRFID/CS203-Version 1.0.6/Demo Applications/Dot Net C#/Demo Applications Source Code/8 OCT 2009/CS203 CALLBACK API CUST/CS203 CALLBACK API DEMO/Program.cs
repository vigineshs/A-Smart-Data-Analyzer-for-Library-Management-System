using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
namespace CS203DEMO
{
    using Reader;
    //using Reader.Device;
    using Reader.Utility;
    static class Program
    {
        public static string Version = "1.0.23";
        public static int hours = 0;
        public static PowerForm Power = new PowerForm();
        public static ProfileForm Profile = new ProfileForm();

        public static string IP;
        public static string MAC;

        public static HighLevelInterface ReaderCE
        {
            get { return HighLevelInterface.Instance; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            //Add firewall exception otherwise, will cause update image failed in windows vista

            string name = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;

            if (!Reader.Net.Firewall.AddAplication(name, "CS203 CALLBACK API DEMO"))
            {
                MessageBox.Show("Add firewall exception fail");
            }
            //First Step
            while (true)
            {
                using (NetFinderForm finder = new NetFinderForm())
                {
                    if (finder.ShowDialog() == DialogResult.OK)
                    {
                        IP = finder.ConnectIP;
                        MAC = finder.MAC;
                    }
                    else
                    {
                        return;
                    }
                }

                using (WaitingForm waiting = new WaitingForm())
                {
                    rfid.Constants.Result ret = rfid.Constants.Result.OK;
                    waiting.Show();
                    Application.DoEvents();

                    if ((ret = ReaderCE.StartupReader(IP, 0)) != rfid.Constants.Result.OK)
                    {
                        ReaderCE.ShutdownReader();
                        MessageBox.Show(String.Format("StartupReader Failed{0}", ret));
                        return;//exit
                    }
                }

                //Load settings
                string path = Application.StartupPath;//Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                if (File.Exists(path + @"\settings.txt"))
                {
                    using (FileStream file = new FileStream(path + @"\settings.txt", FileMode.Open))
                    using (StreamReader sr = new StreamReader(file))
                    {
                        LocalSettings.ServerIP = sr.ReadLine();
                        LocalSettings.ServerName = sr.ReadLine();
                        LocalSettings.DBName = sr.ReadLine();
                        LocalSettings.UserID = sr.ReadLine();
                        LocalSettings.Password = sr.ReadLine();
                    }
                }
                else
                {
                    //Set to default
                    LocalSettings.ServerName = "SQLEXPRESS";
                }

                //Open MainForm and EnableVisualStyles
                Application.Run(new MenuForm());

                //Save settings
                using (FileStream file = new FileStream(path + @"\settings.txt", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(LocalSettings.ServerIP);
                    sw.WriteLine(LocalSettings.ServerName);
                    sw.WriteLine(LocalSettings.DBName);
                    sw.WriteLine(LocalSettings.UserID);
                    sw.WriteLine(LocalSettings.Password);
                }

                ReaderCE.ShutdownReader();

                ReaderCE.Dispose();
                Reader.Net.Firewall.Close();
            }

           // Reader.Net.Firewall.Close();
        }
    }
}