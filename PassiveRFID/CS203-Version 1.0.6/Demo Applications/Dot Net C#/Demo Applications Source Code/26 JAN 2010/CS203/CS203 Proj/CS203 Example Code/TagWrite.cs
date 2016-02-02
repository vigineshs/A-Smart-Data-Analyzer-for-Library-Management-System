using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using CSLibrary.Constants;
using CSLibrary.Text;

namespace CS203_Example_Code
{
    class TagWrite
    {
        private static ushort offset = 0;
        private static ushort count = 0;

        #region Access Password Bank
        public static Result RunSyncWriteAccPwd()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0x11111111;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);


            return rc;
        }

        public static Result RunSyncWriteAccPwd0()
        {
            Result rc = Result.OK;
            
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0xFFFFFFFF;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteAccPwd1()
        {
            Result rc = Result.OK;

            
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0xFFFF0000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteAccPwd2()
        {
            Result rc = Result.OK;
            
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0x0000FFFF;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteAccPwd3()
        {
            Result rc = Result.OK;

           
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0x00000000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunAsyncWriteAccPwd()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteAccPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteAccPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteAccPwd.password = 0x00000000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler
                <CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with asynchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_ACC_PWD, false);

            //wait here until read done
            while (Program.RFID.State != RFState.IDLE)
            {
                System.Threading.Thread.Sleep(100);
            }

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler
                <CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        #endregion

        #region Kill Password Bank
        public static Result RunSyncWriteKillPwd()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteKillPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteKillPwd.password = 0x11111111;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteKillPwd0()
        {
            Result rc = Result.OK;

            
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteKillPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteKillPwd.password = 0xFFFFFFFF;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteKillPwd1()
        {
            Result rc = Result.OK;

         
            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteKillPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteKillPwd.password = 0xFFFF0000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteKillPwd2()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteKillPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteKillPwd.password = 0x0000FFFF;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteKillPwd3()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteKillPwd.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteKillPwd.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteKillPwd.password = 0x00000000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_KILL_PWD, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        #endregion

        #region User Memory Bank
        public static Result RunSyncWriteUser()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 4; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x1111, 0x1111, 0x1111, 0x1111
                                                        };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_Clear()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 32; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000
            };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_0()
        {
            Result rc = Result.OK;

            TagWrite.count = 32;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 32; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111 ,
                0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111,
                0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111,
                0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111, 0x1111
                                                        };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);


            return rc;
        }

        public static Result RunSyncWriteUser_Test_1()
        {
            Result rc = Result.OK;

            TagWrite.count = 32;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 32; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x0011, 0x0011, 0x0011, 0x0011, 0x1100, 0x1100, 0x1100, 0x1100,
                0x0011, 0x0011, 0x0011, 0x0011, 0x1100, 0x1100, 0x1100, 0x1100,
                0x0011, 0x0011, 0x0011, 0x0011, 0x1100, 0x1100, 0x1100, 0x1100,
                0x0011, 0x0011, 0x0011, 0x0011, 0x1100, 0x1100, 0x1100, 0x1100,};

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_2()
        {
            Result rc = Result.OK;

            TagWrite.count = 32;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 32; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x0001, 0x0001, 0x0001, 0x0001, 0x1000, 0x1000, 0x1000, 0x1000,
            0x0001, 0x0001, 0x0001, 0x0001, 0x1000, 0x1000, 0x1000, 0x1000,
            0x0001, 0x0001, 0x0001, 0x0001, 0x1000, 0x1000, 0x1000, 0x1000,
            0x0001, 0x0001, 0x0001, 0x0001, 0x1000, 0x1000, 0x1000, 0x1000};

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_3()
        {
            Result rc = Result.OK;

            TagWrite.count = 32;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = 0;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 32; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000
            };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_4(ushort offset)
        {
            Result rc = Result.OK;

            TagWrite.count = 8;
            TagWrite.offset = offset;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = offset;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 8; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF
            };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteUser_Test_5(ushort offset)
        {
            Result rc = Result.OK;

            TagWrite.count = 11;
            TagWrite.offset = offset;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteUser.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteUser.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWriteUser.offset = offset;// Start from 0
            Program.RFID.Options.TagWriteUser.count = 11; // 8 Word
            Program.RFID.Options.TagWriteUser.pData = new ushort[] { 
                0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF,
                0xFFFF, 0xFFFF, 0xFFFF
            };

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_USER, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        #endregion

        #region PC
        public static Result RunSyncWritePC(ushort PC)
        {
            Result rc = Result.OK;

            TagWrite.count = 1;
            TagWrite.offset = 0;


            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWritePC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWritePC.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWritePC.pc = PC;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWritePC0()
        {
            Result rc = Result.OK;

            TagWrite.count = 1;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWritePC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWritePC.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWritePC.pc = 0x7800;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWritePC1()
        {
            Result rc = Result.OK;

            TagWrite.count = 1;
            TagWrite.offset = 0;


            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWritePC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWritePC.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWritePC.pc = 0x6000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWritePC2()
        {
            Result rc = Result.OK;

            TagWrite.count = 1;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWritePC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWritePC.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWritePC.pc = 0x5000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWritePC3()
        {
            Result rc = Result.OK;

            TagWrite.count = 1;
            TagWrite.offset = 0;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWritePC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWritePC.retryCount = 7;

            //New access password
            Program.RFID.Options.TagWritePC.pc = 0x3000;

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_PC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        #endregion

        #region EPC
        public static Result RunSyncWriteEPC(string source, string target, ushort offset, ushort count)
        {
            Result rc = Result.OK;

            TagWrite.offset = offset;
            TagWrite.count = count;

            //Select a tag
            if ((rc = TagSelected.Run(source, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = offset;
            Program.RFID.Options.TagWriteEPC.count = count;
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(target);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteEPC_Test_0(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;
            
            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_0);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_0);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteEPC_Test_1(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_1);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_1);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteEPC_Test_2(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;
            
            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_2);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_2);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }

        public static Result RunSyncWriteEPC_Test_3(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;
            
            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_3);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_3);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_4(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;
            
            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_4);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_4);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_5(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_5);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_5);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_6(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_6);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_6);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_7(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_7);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_7);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_8(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_8);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_8);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        public static Result RunSyncWriteEPC_Test_9(String TagID)
        {
            Result rc = Result.OK;

            TagWrite.offset = 0;
            TagWrite.count = 6;

            //Select a tag
            if ((rc = TagSelected.Run(TagID, false)) != Result.OK)
                return rc;

            //Set Access password
            Program.RFID.Options.TagWriteEPC.accessPassword = 0x0;

            //Set retial count
            Program.RFID.Options.TagWriteEPC.retryCount = 7;

            //New EPC
            Program.RFID.Options.TagWriteEPC.offset = 0;
            Program.RFID.Options.TagWriteEPC.count = Hex.GetWordCount(Program.TagID_Sample_9);
            Program.RFID.Options.TagWriteEPC.epc = new CSLibrary.Structures.S_EPC(Program.TagID_Sample_9);

            //Registry callback event
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_WRITE_EPC, true);

            //Un-registry callback event
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);

            return rc;
        }
        #endregion

        static void RFID_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            
            switch(e.access)
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
                               TagWrite.offset,
                               TagWrite.count,
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
