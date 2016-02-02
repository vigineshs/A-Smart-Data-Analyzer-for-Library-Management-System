using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Net;

namespace CS203_CALLBACK_API_DEMO_CE
{

    using CSLibrary;
    using CSLibrary.Events;
    using CSLibrary.Constants;
    using CSLibrary.Structures;

    using CSLibrary.Text;
    using CSLibrary.Tools;

    static class Program
    {
        public static string Version = "2.0.7";
        public static HighLevelInterface ReaderCE = new HighLevelInterface();
        public static PowerForm Power = null;
        public static ProfileForm Profile = null;
        public static string applicationSettings = "application.config";
        public static appSettings appSetting = new appSettings();

        //GetVersion
        public static CSLibrary.Structures.Version rfidLibraryVersion = null;
        public static CSLibrary.Structures.Version driverVersion = null;
        public static CSLibrary.Structures.Version firmwareVersion = null;
        public static CSLibrary.Structures.Version cslibraryVersion = null;
        public static CSLibrary.Structures.Version hardwareVersion = null;
        public static string pcbAssemblyCode = null;
        public static string manufactureDate = null;
        public static string deviceName = null;
        public static string serialNumber = null;
        public static string macAddress = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            string ip;
            string AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            //MessageBox.Show(LocalIPAddress());

            //First Step
            FullScreen.Start();

            //turn on debug logging for debug purpose
            ReaderCE.WriteToLog = true;
            //First Step
            {
                using (NetFinderForm finder = new NetFinderForm())
                {
                    if (finder.ShowDialog() == DialogResult.OK)
                    {
                        ip = finder.ConnectIP;
                        macAddress = finder.MAC;
                        applicationSettings = System.IO.Path.Combine(AppPath, macAddress);
                    }
                    else
                    {
                        goto EXIT;
                    }
                }

                CSLibrary.Windows.UI.SplashScreen.Show(CSLibrary.Windows.UI.SplashScreen.CSL.CS203);
                if (ReaderCE.Connect(ip, 30000) != CSLibrary.Constants.Result.OK)
                {
                    ReaderCE.Disconnect();
                    CSLibrary.Windows.UI.SplashScreen.Stop();
                    MessageBox.Show("RFID Connect Fail.");
                    goto EXIT;
                }
                //Get All Reader information and Versions
                driverVersion = Program.ReaderCE.GetDriverVersion();
                firmwareVersion = Program.ReaderCE.GetFirmwareVersion();
                cslibraryVersion = Program.ReaderCE.GetCSLibraryVersion();
                rfidLibraryVersion = Program.ReaderCE.GetRfidLibraryVersion();
                hardwareVersion = Program.ReaderCE.GetHardwareVersion();
                pcbAssemblyCode = Program.ReaderCE.GetPCBAssemblyCode();
                manufactureDate = Program.ReaderCE.GetManufactureDate();

                //Load Setting
                if (!System.IO.File.Exists(macAddress.Replace(':', '.')))
                {
                    LoadDefaultSettings();
                }
                else
                {
                    LoadSettings();
                }

                Power = new PowerForm();

                Profile = new ProfileForm();

                Application.Run(new MenuForm());


            }
EXIT:
            ReaderCE.Disconnect();
            FullScreen.Stop();
            CSLibrary.Windows.UI.SplashScreen.Stop();
        }

        #region Setting

        private static bool LoadDefaultSettings()
        {
            uint power = 0, linkProfile = 0;
            SingulationAlgorithm sing = SingulationAlgorithm.UNKNOWN;
            appSetting.MacAddress = macAddress;

            if (ReaderCE.GetPowerLevel(ref power) != Result.OK)
            {
                MessageBox.Show(String.Format("SetPowerLevel rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Power = power;

            if (ReaderCE.GetCurrentLinkProfile(ref linkProfile) != Result.OK)
            {
                MessageBox.Show(String.Format("SetCurrentLinkProfile rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Link_profile = linkProfile;
            if (appSetting.FixedChannel = ReaderCE.IsFixedChannel)
            {
                appSetting.Region = ReaderCE.SelectedRegionCode;
                appSetting.Channel_number = ReaderCE.SelectedChannel;
                appSetting.Lbt = ReaderCE.LBT_ON == LBT.ON;
            }
            else
            {
                appSetting.Region = ReaderCE.SelectedRegionCode;
            }

            if (ReaderCE.GetCurrentSingulationAlgorithm(ref sing) != Result.OK)
            {
                MessageBox.Show(String.Format("GetCurrentSingulationAlgorithm rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return false;
            }
            appSetting.Singulation = sing;

            if (ReaderCE.GetSingulationAlgorithmParms(appSetting.Singulation, appSetting.SingulationAlg) != Result.OK)
            {
                MessageBox.Show(String.Format("GetCurrentSingulationAlgorithm rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return false;
            }
            return true;
        }

        public static void LoadSettings()
        {
            appSetting = appSetting.Load();

            //Previous save config not match
            if (appSetting.MacAddress != macAddress)
                return;

            //Apply previous configuration
            if (ReaderCE.SetPowerLevel(appSetting.Power) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show(String.Format("SetPowerLevel rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return;
            }
            if (ReaderCE.SetCurrentLinkProfile(appSetting.Link_profile) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show(String.Format("SetCurrentLinkProfile rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return;
            }
            if (appSetting.FixedChannel)
            {
                if (ReaderCE.SetFixedChannel(appSetting.Region, appSetting.Channel_number, appSetting.Lbt ? LBT.ON : LBT.OFF) != CSLibrary.Constants.Result.OK)
                {
                    MessageBox.Show(String.Format("SetFixedChannel rc = {0}", ReaderCE.LastResultCode));
                    Application.Exit();
                    return;
                }
            }
            else
            {
                if (ReaderCE.SetHoppingChannels(appSetting.Region) != CSLibrary.Constants.Result.OK)
                {
                    MessageBox.Show(String.Format("SetHoppingChannels rc = {0}", ReaderCE.LastResultCode));
                    Application.Exit();
                    return;
                }
            }
            if (ReaderCE.SetSingulationAlgorithmParms(appSetting.Singulation, appSetting.SingulationAlg) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.Show(String.Format("SetSingulationAlgorithmParms rc = {0}", ReaderCE.LastResultCode));
                Application.Exit();
                return;
            }
        }

        public static bool SaveSettings()
        {
            appSetting.Channel_number = ReaderCE.SelectedChannel;
            appSetting.Lbt = ReaderCE.LBT_ON == LBT.ON;
            appSetting.Link_profile = ReaderCE.SelectedLinkProfile;
            appSetting.Power = ReaderCE.SelectedPowerLevel;
            appSetting.Region = ReaderCE.SelectedRegionCode;
            appSetting.FixedChannel = ReaderCE.IsFixedChannel;
            return appSetting.Save();
        }
        #endregion

        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

    }
}