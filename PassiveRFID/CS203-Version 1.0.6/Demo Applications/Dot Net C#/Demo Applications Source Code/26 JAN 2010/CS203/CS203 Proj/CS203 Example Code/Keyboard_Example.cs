using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using CSLibrary.HotKeys;


namespace CS101_Example_Code
{
    class Keyboard_Example
    {
        static bool bStop = false;

        public static void StartKeyDemo()
        {
            RegisterKeyEvt();

            while (!bStop)
            {
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(100);
            }

            UnRegisterKeyEvt();
        }


        public static void RegisterKeyEvt()
        {
            HotKeys.OnKeyEvent += new EventHandler<HotKeyEventArgs>(HotKey_OnKeyEvent);
        }

        public static void UnRegisterKeyEvt()
        {
            HotKeys.OnKeyEvent -= new EventHandler<HotKeyEventArgs>(HotKey_OnKeyEvent);
        }

        static void HotKey_OnKeyEvent(object sender, HotKeyEventArgs e)
        {
            Logger.WriteLine(string.Format("KeyDown {0}", e.KeyCode));
            switch(e.KeyCode)

            {
                case Key.F1:
                case Key.F2:
                case Key.F3:
                case Key.F4:
                case Key.F5:
                case Key.F11:
                    bStop = true;
                    break;
            }
        }

    }
}
