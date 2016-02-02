using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_Example_Code
{
    class TagKill
    {
        public static Result RunSyncKillAccPwd()
        {
            Result rc = Result.OK;

            //Set access password
            Program.RFID.Options.TagKill.accessPassword = 0x00000000;

            //Set kill password
            Program.RFID.Options.TagKill.killPassword = 0x11111111;

            //total retry count when failed
            Program.RFID.Options.TagKill.retryCount = 7;

            //Use Select flag
            Program.RFID.Options.TagKill.flags = SelectFlags.SELECT;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with sync.
            rc = Program.RFID.StartOperation(Operation.TAG_KILL, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        static void RFID_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            switch (e.access)
            {
                case TagAccess.READ:
                case TagAccess.WRITE:
#if CSV
                    Logger.WriteLine(string.Format("{0},{1},{2},{3}",
                                           e.access,
                                           e.bank,
                                           e.success ? "OK" : "FAILED",
                                           e.data.ToString()
                                           ));
#else
                    Logger.WriteLine(string.Format("{0} {1} bank, Result = {2}, Data = {3}",
                       e.access,
                       e.bank,
                       e.success ? "OK" : "FAILED",
                       e.data.ToString()
                       ));
#endif
                    break;
                case TagAccess.LOCK:
                case TagAccess.KILL:
                case TagAccess.ERASE:
#if CSV
                    Logger.WriteLine(string.Format("{0},{1},{2}",
                                e.access,
                                e.bank,
                                e.success ? "OK" : "FAILED"
                                ));
#else
                    Logger.WriteLine(string.Format("{0} {1} bank, Result = {2}",
                                e.access,
                                e.bank,
                                e.success ? "OK" : "FAILED"
                                ));
#endif
                    break;
            }
        }
    }
}
