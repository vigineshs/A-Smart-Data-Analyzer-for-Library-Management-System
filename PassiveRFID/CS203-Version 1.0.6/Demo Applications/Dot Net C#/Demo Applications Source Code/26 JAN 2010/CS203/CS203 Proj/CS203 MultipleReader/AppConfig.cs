using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CS203_MultipleReader
{
    [Serializable]
    public class AppConfig
    {
        /*CAPTION=CS203R ReadTag Demo
        LOCATION=C:\CS203DATA\CS203R
        RUN=ReadTagTestR.exe
        POWER=19.5
        CHANNEL=5
        PROFILE=2
        EXTERNAL_LO=OFF
        LBT=ON*/
        private string m_appTitle = "ReadTag Demo";

        public string AppTitle
        {
            get { return m_appTitle; }
            set { m_appTitle = value; }
        }

        private string m_DeviceName = "CS203R";

        public string DeviceName
        {
            get { return m_DeviceName; }
            set { m_DeviceName = value; }
        }

        private string m_DataPath = @"C:\CS203DATA";

        public string DataPath
        {
            get { return m_DataPath; }
            set { m_DataPath = value; }
        }
        private uint m_power = 275;

        public uint Power
        {
            get { return m_power; }
            set { m_power = value; }
        }
        private uint m_channel = 2;

        public uint Channel
        {
            get { return m_channel; }
            set { m_channel = value; }
        }
        private uint m_profile = 2;

        public uint Profile
        {
            get { return m_profile; }
            set { m_profile = value; }
        }
        private bool m_lbt = true;

        public bool Lbt
        {
            get { return m_lbt; }
            set { m_lbt = value; }
        }

        #region Methods: Save, Load
        /// <summary>
        /// Saves this settings object to desired location
        /// </summary>
        public bool Save()
        {
            try
            {
                // Insert code to set properties and fields of the object.
                XmlSerializer mySerializer = new XmlSerializer(typeof(AppConfig));
                // To write to a file, create a StreamWriter object.
                StreamWriter myWriter = new StreamWriter("ReadTag.CFG");
                mySerializer.Serialize(myWriter, this);
                myWriter.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Returns a clsSettings object, loaded from a specific location
        /// </summary>
        public AppConfig Load()
        {
            if (!File.Exists("ReadTag.CFG"))
            {
                Save();
            }

            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(AppConfig));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream("ReadTag.CFG", FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            AppConfig pos = (AppConfig)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            return pos;
        }
        #endregion
    }
}
