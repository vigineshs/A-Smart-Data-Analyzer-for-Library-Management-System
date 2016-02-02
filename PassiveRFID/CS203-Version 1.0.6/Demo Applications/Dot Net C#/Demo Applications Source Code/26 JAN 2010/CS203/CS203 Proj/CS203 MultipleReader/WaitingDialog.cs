using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203_MultipleReader
{
    public partial class WaitingDialog : Form
    {
        // Threading
        static WaitingDialog ms_frmSplash = null;
        static Thread ms_oThread = null;

        public WaitingDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A static method to create the thread and 
        /// launch the SplashScreen.
        /// </summary>
        /// <param name="type">Device type</param>
        static public void Show()
        {
            // Make sure it's only launched once.
            if (ms_frmSplash != null)
                return;
            ms_oThread = new Thread(new ThreadStart(WaitingDialog.ShowForm));
            ms_oThread.IsBackground = true;
            ms_oThread.Start();
        }

        // A private entry point for the thread.
        static private void ShowForm()
        {
            ms_frmSplash = new WaitingDialog();
            Application.Run(ms_frmSplash);
        }

        private delegate void CloseWaitingDialogDel();
        /// <summary>
        /// A static method to close the SplashScreen
        /// </summary>
        static public void Stop()
        {
            if (ms_frmSplash == null || ms_frmSplash.IsDisposed)
            {
                return;
            }

            if (ms_frmSplash.InvokeRequired)
            {
                ms_frmSplash.BeginInvoke(new CloseWaitingDialogDel(Stop), new object[] { });
                return;
            }

            ms_frmSplash.Close();
            ms_oThread = null;	// we don't need these any more.
            ms_frmSplash = null;
        }
    }
}