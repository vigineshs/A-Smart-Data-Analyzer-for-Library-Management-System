using System;
using System.Collections.Generic;
using System.Text;

//Import RFID namespace
using CSLibrary;
using CSLibrary.Constants;
using CSLibrary.Structures;


namespace CS203_Example_Code
{
    class RegisterEvent
    {
        public static void RegisterCallbackEvent()
        {
            //RFID related event
            Program.RFID.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);
            Program.RFID.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);
            Program.RFID.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(RFID_OnChanged);
        }

        public static void UnRegisterCallbackEvent()
        {
            Program.RFID.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(RFID_OnAsyncCall);
            Program.RFID.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(RFID_OnCompleted);
            Program.RFID.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(RFID_OnChanged);
        }

        static void RFID_OnChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {

        }

        static void RFID_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        static void RFID_OnAsyncCall(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
