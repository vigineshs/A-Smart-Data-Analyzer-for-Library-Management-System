using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_Example_Code
{
    class TagSearchOne
    {
        public static Result Run()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.Run(Program.TagID, true)) != Result.OK)
                return rc;

            //Set non-continuous inventory
            Program.RFID.SetOperationMode(RadioOperationMode.NONCONTINUOUS);

            //Set Average RSSI to false
            Program.RFID.Options.TagSearchOne.avgRssi = false;

            //Registry callback event
            Program.RFID.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);

            //Start Operation with synchronuous.
            rc = Program.RFID.StartOperation(Operation.TAG_SEARCHING, true);

            //Un-registry callback event
            Program.RFID.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);

            return rc;
        }


        public static Result CustRun()
        {
            Result rc = Result.OK;

            //Select a tag
            if ((rc = TagSelected.CustRun(Program.TagID, true)) != Result.OK)
                return rc;

            //Set continuous inventory
            Program.RFID.SetOperationMode(RadioOperationMode.NONCONTINUOUS);
            
            //Enable select flag to lock a tag
            Program.RFID.Options.TagInventory.flags = SelectFlags.SELECT;
            
            //Registry callback event
            Program.RFID.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);
           
            //Start Operation with synchronuous. 
            rc = Program.RFID.StartOperation(Operation.TAG_INVENTORY, true);

            //Un-registry callback event
            Program.RFID.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);

            return rc;
        }

        static void RFID_OnAsyncCall(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            switch (e.type)
            {
                case CallbackType.TAG_INVENTORY:
                case CallbackType.TAG_SEARCHING:
                    Logger.WriteLine(string.Format("PC-EPC = {0}-{1}", e.info.pc.ToString(), e.info.epc.ToString()));
                    break;
            }
        }


    }
}