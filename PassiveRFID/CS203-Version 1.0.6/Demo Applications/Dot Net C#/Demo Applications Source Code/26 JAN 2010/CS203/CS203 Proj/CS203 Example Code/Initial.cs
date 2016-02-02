using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

//Import RFID Library
using CSLibrary;
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_Example_Code
{
    class Initial
    {
        public static bool StartUp(string ip)
        {
            //Startup RFID device and get radio handle
            if (Program.RFID.Connect(ip, 30000) != CSLibrary.Constants.Result.OK)
            {
                Logger.WriteLine("RFID connect failed");
                return false;
            }

            return true;
        }

        public static bool Shutdown()
        {
            //Disconnect and free resources use by RFID
            if (Program.RFID.Disconnect() != CSLibrary.Constants.Result.OK)
            {
                Logger.WriteLine("RFID disconnect failed");
            }

            return true;
        }
    }
}
