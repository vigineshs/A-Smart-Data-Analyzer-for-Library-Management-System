using System;
using System.Collections.Generic;
using System.Text;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_Example_Code
{
    class TagSelected
    {
        public static Result Run(String epc, bool toggleTarget)
        {
            //Disable all parameters for selection
            Program.RFID.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.RFID.Options.TagSelected.epcMask = new S_MASK(epc);
            Program.RFID.Options.TagSelected.epcMaskLength = Hex.GetBitCount(epc);
            //Start Operation with synchronuous.
            return Program.RFID.StartOperation(Operation.TAG_SELECTED, true);
        }

        public static Result CustRun(String epc, bool toggleTarget)
        {
            Result rc = Result.OK;
            if((rc = Program.RFID.SetTagGroup(Selected.ON, Session.S0, SessionTarget.A))!= Result.OK)
            {
                return rc;
            }
            if ((rc = Program.RFID.SetFixedQParms(0, 3, (uint)(toggleTarget ? 1 : 0), 0)) != Result.OK)
            {
                return rc;
            }

            SelectCriterion[] sel = new SelectCriterion[1];
            sel[0] = new SelectCriterion();
            sel[0].action = new SelectAction(Target.SELECTED, CSLibrary.Constants.Action.ASLINVA_DSLINVB, 0);
            sel[0].mask = new SelectMask(MemoryBank.EPC, 32, 96, Hex.ToBytes(epc));
            return Program.RFID.SetSelectCriteria(sel);
        }
    }
}