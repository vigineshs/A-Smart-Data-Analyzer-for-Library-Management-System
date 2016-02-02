using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace CS203_CALLBACK_API_DEMO
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Tools;
    static class Program
    {
        public static int hours = 0;
        public static PowerForm Power = new PowerForm();
        public static ProfileForm Profile = new ProfileForm();

        public static string applicationSettings = "application.config";
        public static appSettings appSetting = new appSettings();
        public static string IP = String.Empty;
        public static string MAC = String.Empty;

        public static HighLevelInterface ReaderXP = new HighLevelInterface();
        public static HighLevelInterface ReaderXP1 = new HighLevelInterface();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CSLibrary.Constants.Result ret = CSLibrary.Constants.Result.OK;
            Application.EnableVisualStyles();

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
                        goto DEINIT;
                    }
                }

                CSLibrary.Windows.UI.SplashScreen.Show(CSLibrary.Windows.UI.SplashScreen.CSL.CS203);
                {
                    Application.DoEvents();
                    uint time = GetTickCount();
                    if ((ret = ReaderXP.Connect(IP, 30000)) != CSLibrary.Constants.Result.OK)
                    {
                        ReaderXP.Disconnect();
                        MessageBox.Show(String.Format("StartupReader Failed{0}", ret));
                        goto DEINIT;
                    }
                    System.Diagnostics.Trace.WriteLine(string.Format("Connect time = {0}", GetTickCount() - time));
                }
                //Load settings
                /*string path = Application.StartupPath;
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
                }*/
                if (!System.IO.File.Exists(MAC.Replace(':','.')))
                {
                    LoadDefaultSettings();
                }
                else
                {
                    LoadSettings();
                }

                //Open MainForm and EnableVisualStyles
                Application.Run(new MenuForm());

                /*//Save settings
                using (FileStream file = new FileStream(path + @"\settings.txt", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(LocalSettings.ServerIP);
                    sw.WriteLine(LocalSettings.ServerName);
                    sw.WriteLine(LocalSettings.DBName);
                    sw.WriteLine(LocalSettings.UserID);
                    sw.WriteLine(LocalSettings.Password);
                }*/

                ReaderXP.Disconnect();
           }
DEINIT:
             CSLibrary.Windows.UI.SplashScreen.Stop();

        }

        public static CSLibrary.Structures.Version GetDemoVersion()
        {
            System.Version sver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            CSLibrary.Structures.Version ver = new CSLibrary.Structures.Version();
            ver.major = (uint)sver.Major;
            ver.minor = (uint)sver.Minor;
            ver.patch = (uint)sver.Build;
            return ver;
        }

        #region Setting

        private static bool LoadDefaultSettings()
        {
            uint power = 0, linkProfile = 0;
            SingulationAlgorithm sing = SingulationAlgorithm.UNKNOWN;
            appSetting.MAC_ADDRESS = MAC;

            if (ReaderXP.GetPowerLevel(ref power) != Result.OK)
            {
                MessageBox.Show(String.Format("SetPowerLevel rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Power = power;

            if (ReaderXP.GetCurrentLinkProfile(ref linkProfile) != Result.OK)
            {
                MessageBox.Show(String.Format("SetCurrentLinkProfile rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Link_profile = linkProfile;
            if (appSetting.FixedChannel = ReaderXP.IsFixedChannel)
            {
                appSetting.Region = ReaderXP.SelectedRegionCode;
                appSetting.Channel_number = ReaderXP.SelectedChannel;
                appSetting.Lbt = ReaderXP.LBT_ON == LBT.ON;
            }
            else
            {
                appSetting.Region = ReaderXP.SelectedRegionCode;
            }

            if (ReaderXP.GetCurrentSingulationAlgorithm(ref sing) != Result.OK)
            {
                MessageBox.Show(String.Format("GetCurrentSingulationAlgorithm rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Singulation = sing;

            if (ReaderXP.GetSingulationAlgorithmParms(appSetting.Singulation, appSetting.SingulationAlg) != Result.OK)
            {
                MessageBox.Show(String.Format("GetCurrentSingulationAlgorithm rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return false;
            }
            return true;
        }

        public static void LoadSettings()
        {
            appSetting = appSetting.Load();

            //Previous save config not match
            if (appSetting.MAC_ADDRESS != MAC)
                return;

            //Apply previous configuration
            if (ReaderXP.SetPowerLevel(appSetting.Power) != Result.OK)
            {
                MessageBox.Show(String.Format("SetPowerLevel rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return;
            }
            if (ReaderXP.SetCurrentLinkProfile(appSetting.Link_profile) != Result.OK)
            {
                MessageBox.Show(String.Format("SetCurrentLinkProfile rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return;
            }
            if (appSetting.FixedChannel)
            {
                if (ReaderXP.SetFixedChannel(appSetting.Region, appSetting.Channel_number, appSetting.Lbt ? LBT.ON : LBT.OFF) != Result.OK)
                {
                    MessageBox.Show(String.Format("SetFixedChannel rc = {0}", ReaderXP.LastResultCode));
                    Application.Exit();
                    return;
                }
            }
            else
            {
                if (ReaderXP.SetHoppingChannels(appSetting.Region) != Result.OK)
                {
                    MessageBox.Show(String.Format("SetHoppingChannels rc = {0}", ReaderXP.LastResultCode));
                    Application.Exit();
                    return;
                }
            }
            if (ReaderXP.SetSingulationAlgorithmParms(appSetting.Singulation, appSetting.SingulationAlg) != Result.OK)
            {
                MessageBox.Show(String.Format("SetSingulationAlgorithmParms rc = {0}", ReaderXP.LastResultCode));
                Application.Exit();
                return;
            }
        }

        public static bool SaveSettings()
        {
            appSetting.Channel_number = ReaderXP.SelectedChannel;
            appSetting.Lbt = ReaderXP.LBT_ON == LBT.ON;
            appSetting.Link_profile = ReaderXP.SelectedLinkProfile;
            appSetting.Power = ReaderXP.SelectedPowerLevel;
            appSetting.Region = ReaderXP.SelectedRegionCode;
            appSetting.FixedChannel = ReaderXP.IsFixedChannel;
            appSetting.MAC_ADDRESS = MAC;
            return appSetting.Save();
        }
        #endregion

        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();

    }
}