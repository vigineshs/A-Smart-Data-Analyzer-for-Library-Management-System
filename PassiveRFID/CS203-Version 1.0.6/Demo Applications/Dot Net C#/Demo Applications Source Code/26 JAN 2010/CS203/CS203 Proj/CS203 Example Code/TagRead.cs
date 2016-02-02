using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_Example_Code
{
    class TagRead
    {
        private static ushort offset = 0;
        private static ushort count = 0;
        public static Result RunSyncReadAccPwd()
        {
            Result rc = Result.OK;

            TagRead.offset = 0;
            TagRead.count = 2;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadAccPwd.retryCount = 7;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncReadKillPwd()
        {
            Result rc = Result.OK;

            TagRead.offset = 0;
            TagRead.count = 2;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadKillPwd.retryCount = 7;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        
        public static Result RunSyncReadPC()
        {
            Result rc = Result.OK;

            TagRead.offset = 0;
            TagRead.count = 1;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadPC.retryCount = 7;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncReadEPC(string TagID, ushort offset, ushort count)
        {
            Result rc = Result.OK;

            TagRead.offset = offset;
            TagRead.count = count;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadEPC.retryCount = 7;

            //96-bit EPC length
            Program.RFID.Options.TagReadEPC.count = count;

            Program.RFID.Options.TagReadEPC.offset = offset;


            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncReadUser(ushort offset, ushort count)
        {
            Result rc = Result.OK;

            TagRead.offset = offset;
            TagRead.count = count;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadUser.retryCount = 7;
            Program.RFID.Options.TagReadUser.offset = offset;
            Program.RFID.Options.TagReadUser.count = count;//read 8 word

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncReadTid(ushort offset, ushort count)
        {
            Result rc = Result.OK;

            TagRead.offset = offset;
            TagRead.count = count;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagReadTid.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadTid.retryCount = 7;
            Program.RFID.Options.TagReadTid.offset = offset;
            Program.RFID.Options.TagReadTid.count = count; //read 2 word

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_TID, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunAsyncReadAccPwd()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            //Program.RFID.Options.TagReadAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagReadAccPwd.retryCount = 7;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with asynchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_READ_ACC_PWD, false);

            //wait here until read done
            while (Program.RFID.State != RFState.IDLE)
            {
                System.Threading.Thread.Sleep(100);
            }

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
                    switch (e.bank)
                    {
                        case Bank.EPC:
                        case Bank.TID:
                        case Bank.USER:
                            Logger.WriteLine(string.Format("{0},{1},{2},{3},{4},0x{5}",
                               e.access,
                               e.bank,
                               e.success ? "OK" : "FAILED",
                               TagRead.offset,
                               TagRead.count,
                               e.data.ToString()
                               ));
                            break;
                        case Bank.ACC_PWD:
                        case Bank.KILL_PWD:
                        case Bank.PC:
                            Logger.WriteLine(string.Format("{0},{1},{2},0x{3}",
                               e.access,
                               e.bank,
                               e.success ? "OK" : "FAILED",
                               e.data.ToString()
                               ));
                            break;
                    }
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
