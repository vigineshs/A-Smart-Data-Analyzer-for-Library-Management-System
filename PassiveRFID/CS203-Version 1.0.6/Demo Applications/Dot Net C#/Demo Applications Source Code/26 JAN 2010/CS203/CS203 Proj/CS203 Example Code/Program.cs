using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace CS203_Example_Code
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;

    class Program
    {
        public static HighLevelInterface RFID = new HighLevelInterface();

        public static string TagID = "900000000000000000000000";

        public static string TagID_Sample_Clear = "000000000000000000000000";
        public static string TagID_Sample_0 = "900000000000000000000000";
        public static string TagID_Sample_1 = "900000000000000000000001";
        public static string TagID_Sample_2 = "900000000000000000000002";
        public static string TagID_Sample_3 = "900000000000000000000003";
        public static string TagID_Sample_4 = "900000000000000000000004";
        public static string TagID_Sample_5 = "900000000000000000000005";
        public static string TagID_Sample_6 = "900000000000000000000006";
        public static string TagID_Sample_7 = "900000000000000000000007";
        public static string TagID_Sample_8 = "900000000000000000000008";
        public static string TagID_Sample_9 = "900000000000000000000009";

        public static string TagID_Sample_10 = TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2;
        public static string TagID_Sample_11 = TagID_Sample_0 + TagID_Sample_7 + TagID_Sample_9;
        public static string TagID_Sample_12 = TagID_Sample_Clear + TagID_Sample_Clear + TagID_Sample_Clear;

        static void Main(string[] args)
        {
            //Result rc = Result.OK;
            //TestStartupShutdown(1000);
            //Led Demo
            //Led_Example.StartDemoLed();

            //Keyboard Demo
            //Keyboard_Example.StartKeyDemo();

            Logger.WriteLine("StartUp Library");
            //Startup RFID and Barcode 
            if (!Initial.StartUp("192.168.25.203"))
                goto RADIO_CLOSE;

            Application.Run(new SelfTestForm());

            /*Logger.WriteLine("TagInventory START");
            //Start Tag Inventory
            rc = TagInventory.Run();
            Logger.WriteLine(string.Format("TagInventory END", rc));

            Logger.WriteLine("TagRanging START");
            //Start Tag Inventory
            rc = TagInventory.Ranging();
            Logger.WriteLine(string.Format("TagRanging END", rc));

            Logger.WriteLine("TagSearchAny START");
            //Start Tag Search
            rc = TagSearchAny.Run();
            Logger.WriteLine(string.Format("TagSearchAny END",rc));

            Logger.WriteLine("Geiger Search START");
            //Start Geiger Search
            rc = TagSearchOne.Run();
            Logger.WriteLine(string.Format("Geiger Search END return {0}", rc));

            Logger.WriteLine("Customized Geiger Search START");
            //Start Geiger Search
            rc = TagSearchOne.CustRun();
            Logger.WriteLine(string.Format("Customized Geiger Search END return {0}", rc));
            */

RADIO_CLOSE:
            //Shutdown RFID and Barcode
            Initial.Shutdown();
            Logger.WriteLine("Shutdown Library");

        }

        public static void TestStartupShutdown(int retryCount)
        {
            int total = 0;
            Logger.WriteLine("TestStartupShutdown start");

            while (true)
            {
                if (!Initial.StartUp("192.168.25.212"))
                    Logger.WriteLine("StartUp failed");
                else
                    Logger.WriteLine(string.Format("StartUp success {0}", total + 1));
                if (!Initial.Shutdown())
                    Logger.WriteLine("Shutdown failed");
                else
                    Logger.WriteLine(string.Format("Shutdown success {0}", total + 1));
                if (total++ >= retryCount)
                    break;
            }

            Logger.WriteLine("TestStartupShutdown end");
        }

        public static void TestWriteAcc()
        {
            Logger.WriteLine("======== Test Write Access Password START ========");

            TagWrite.RunSyncWriteAccPwd0();
            TagRead.RunSyncReadAccPwd();

            TagWrite.RunSyncWriteAccPwd1();
            TagRead.RunSyncReadAccPwd();

            TagWrite.RunSyncWriteAccPwd2();
            TagRead.RunSyncReadAccPwd();

            TagWrite.RunSyncWriteAccPwd3();
            TagRead.RunSyncReadAccPwd();

            Logger.WriteLine("======== Test Write Access Password END ========");
        }

        public static void TestWriteKill()
        {
            Logger.WriteLine("======== Test Write Kill Password START ========");

            TagWrite.RunSyncWriteKillPwd0();
            TagRead.RunSyncReadKillPwd();

            TagWrite.RunSyncWriteKillPwd1();
            TagRead.RunSyncReadKillPwd();

            TagWrite.RunSyncWriteKillPwd2();
            TagRead.RunSyncReadKillPwd();

            TagWrite.RunSyncWriteKillPwd3();
            TagRead.RunSyncReadKillPwd();

            Logger.WriteLine("======== Test Write Kill Password END ========");
        }

        public static void TestWritePC()
        {
            Logger.WriteLine("======== Test Write PC START ========");

            TagWrite.RunSyncWritePC0();
            TagRead.RunSyncReadPC();

            TagWrite.RunSyncWritePC1();
            TagRead.RunSyncReadPC();

            TagWrite.RunSyncWritePC2();
            TagRead.RunSyncReadPC();

            TagWrite.RunSyncWritePC3();
            TagRead.RunSyncReadPC();

            Logger.WriteLine("======== Test Write PC END ========");
        }

        public static void TestWriteUser(int loop)
        {
            for (int l = 0; l < loop; l++)
            {
                Logger.WriteLine(string.Format("======== Test Write User Memory START {0} ========", l + 1));

                TagWrite.RunSyncWriteUser_Test_0();
                TagRead.RunSyncReadUser(0, 32);

                TagWrite.RunSyncWriteUser_Test_1();
                TagRead.RunSyncReadUser(0, 32);

                TagWrite.RunSyncWriteUser_Test_2();
                TagRead.RunSyncReadUser(0, 32);

                TagWrite.RunSyncWriteUser_Test_3();
                TagRead.RunSyncReadUser(0, 32);

                for(ushort offset = 0; offset <= 24; offset++)
                {
                    TagWrite.RunSyncWriteUser_Test_Clear();
                    TagWrite.RunSyncWriteUser_Test_4(offset);
                    TagRead.RunSyncReadUser(0, 32);
                }

                for (ushort offset = 0; offset <= 21; offset++)
                {
                    TagWrite.RunSyncWriteUser_Test_Clear();
                    TagWrite.RunSyncWriteUser_Test_5(offset);
                    TagRead.RunSyncReadUser(0, 32);
                }

                Logger.WriteLine(string.Format("======== Test Write User Memory END {0} ========", l + 1));
            }
        }

        public static void TestWriteEPC()
        {
            Logger.WriteLine("======== Test Write EPC START ========");

            if (TagWrite.RunSyncWriteEPC_Test_0(TagID) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_0, 0 , 6);

            if (TagWrite.RunSyncWriteEPC_Test_1(TagID_Sample_0) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_1, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_2(TagID_Sample_1) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_2, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_3(TagID_Sample_2) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_3, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_4(TagID_Sample_3) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_4, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_5(TagID_Sample_4) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_5, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_6(TagID_Sample_5) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_6, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_7(TagID_Sample_6) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_7, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_8(TagID_Sample_7) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_8, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_9(TagID_Sample_8) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_9, 0, 6);

            if (TagWrite.RunSyncWriteEPC_Test_0(TagID_Sample_9) != Result.OK)
                goto TEST_ERR;
            TagRead.RunSyncReadEPC(TagID_Sample_0, 0, 6);

            if (TagWrite.RunSyncWritePC(0xF000) != Result.OK)
                goto TEST_ERR;

            if (TagWrite.RunSyncWriteEPC(TagID, TagID_Sample_0 + TagID_Sample_1, 0, 12) != Result.OK)
                goto TEST_ERR;

            if (TagWrite.RunSyncWriteEPC(TagID_Sample_0 + TagID_Sample_1, TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2, 0, 18) != Result.OK)
                goto TEST_ERR;

            if (TagWrite.RunSyncWriteEPC(TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2, TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2 + TagID_Sample_3, 0, 24) != Result.OK)
                goto TEST_ERR;

            if (TagWrite.RunSyncWriteEPC(TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2 + TagID_Sample_3, TagID_Sample_0 + TagID_Sample_1 + TagID_Sample_2 + TagID_Sample_3 + TagID_Sample_4, 0, 30) != Result.OK)
                goto TEST_ERR;

            if (TagWrite.RunSyncWritePC(0x3000) != Result.OK)
                goto TEST_ERR;

            goto TEST_END;

            TEST_ERR:
            Logger.WriteLine("ERR:TestWriteEPC failed");
            TEST_END:
            Logger.WriteLine("======== Test Write EPC END ========");
        }

        public static void TestReadTid()
        {
            Logger.WriteLine("======== Test Write TID START ========");
            TagRead.RunSyncReadTid(0, 2);
            Logger.WriteLine("======== Test Write TID END ========");
        }
    }
}
