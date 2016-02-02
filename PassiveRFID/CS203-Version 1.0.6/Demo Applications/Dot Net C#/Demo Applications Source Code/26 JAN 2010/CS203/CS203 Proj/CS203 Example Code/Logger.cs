using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CS203_Example_Code
{
    class Logger : IDisposable
    {
        // Track whether Dispose has been called.
        private bool disposed = false;
#if CSV
        private static string loggerFileName = "RfidFuncTest.csv";
#else
        private static string loggerFileName = "RfidFuncTest.txt";
#endif
        private static FileStream fs = null;
        private static StreamWriter logger = null;

        public Logger()
        {
            
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // Dispose managed resources.
                    if (fs != null)
                    {
                        fs.Close();
                        logger.Close();
                    }
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~Logger()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }


        public static void WriteLine(string str)
        {
            Debug.WriteLine(str);
            if (fs == null || logger == null)
            {
                fs = new FileStream(loggerFileName, FileMode.Create);
                logger = new StreamWriter(fs);
                logger.AutoFlush = true;
            }
            else
            {
                logger.WriteLine(str);
            }
        }

    }
}
