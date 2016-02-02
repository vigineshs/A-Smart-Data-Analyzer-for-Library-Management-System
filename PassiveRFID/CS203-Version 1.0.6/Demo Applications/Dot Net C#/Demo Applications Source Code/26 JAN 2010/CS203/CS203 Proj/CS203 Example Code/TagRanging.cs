using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using CSLibrary.Constants;

namespace CS203_Example_Code
{
    class TagRanging
    {
        public static Result Run()
        {
            Result rc = Result.OK;

            //Set Tag Interest
            Program.RFID.SetTagGroup(Selected.ALL, Session.S0, SessionTarget.A);

            //Set Dynamic-Q Algorithm
            Program.RFID.SetDynamicQParms(7, 0, 15, 3, 0, 1);

            //Set non-continuous inventory
            Program.RFID.SetOperationMode(RadioOperationMode.NONCONTINUOUS);

            //Set flag to zero, because no specific tag applied
            Program.RFID.Options.TagRanging.flags = SelectFlags.ZERO;

            //Registry callback event
            Program.RFID.OnAsyncCallback += new EventHandler
                <CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);

            //Start Operation with sync.
            rc = Program.RFID.StartOperation(Operation.TAG_RANGING, true);

            //Un-registry callback event
            Program.RFID.OnAsyncCallback -= new EventHandler
                <CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);

            return rc;
        }

        static void RFID_OnAsyncCall(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            switch (e.type)
            {
                case CallbackType.TAG_RANGING:
                    Logger.WriteLine(String.Format("PC-EPC = {0}, {1}", e.info.epc, e.info.pc));
                    break;
            }
        }

    }
}
