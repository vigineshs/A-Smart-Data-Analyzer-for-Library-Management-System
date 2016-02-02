using System;
using System.Collections.Generic;
using System.Text;
using CSLibrary.Windows.UI;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO_CE
{
    class DeviceFinderList : INTableModel
    {
        private object myLock = new object();

        private String[] m_displayColumnName = new string[] { "Name", "IP Address", "MAC Address", "Version" };

        #region ITableModel Members
        private List<CSLibrary.Net.DeviceInfomation> m_items = new List<CSLibrary.Net.DeviceInfomation>();

        public DeviceFinderList()
        {
        }

        public DeviceFinderList(List<CSLibrary.Net.DeviceInfomation> data)
        {
            m_items = data;
        }
 

        public int GetRowCount()
        {
            lock (myLock)
            {
                return m_items.Count;
            }
        }

        public int GetColumnCount()
        {
            return 4;
        }

        public string GetColumnName(int columnIndex)
        {
            return m_displayColumnName[columnIndex];
        }

        public Type GetColumnClass(int columnIndex)
        {
            return typeof(string);
        }

        public bool IsCellEditable(int rowIndex, int columnIndex)
        {
            return false;
        }

        public object GetValueAt(int rowIndex, int columnIndex)
        {
            lock (myLock)
            {
                switch (columnIndex)
                {
                    case 0: return m_items[rowIndex].device_name;
                    case 1: return m_items[rowIndex].ip.ToString();
                    case 2: return m_items[rowIndex].mac.ToString();
                    case 3: return m_items[rowIndex].description;
                    default: return String.Empty;
                }
            }
        }

        public void SetValueAt(object aValue, int rowIndex, int columnIndex)
        {
        }
        public object GetObjectAt(int rowIndex, int columnIndex)
        {
            return null;
        }

        public event TableModelChangeHandler Change;
        #endregion

        public List<CSLibrary.Net.DeviceInfomation> Items
        {
            get { return m_items; }
            set { m_items = value; }
        }

        public void UpdateItem(CSLibrary.Net.DeviceInfomation info, int index)
        {
            m_items[index] = info;
            if (Change != null)
            {
                Change.Invoke();
            }
        }

        public void RefreshItemList()
        {
            if (Change != null)
            {
                Change.Invoke();
            }
        }

        public void AddItem(CSLibrary.Net.DeviceInfomation info)
        {
            lock (myLock)
            {
                m_items.Add(info);
            }
            if (Change != null)
            {
                Change.Invoke();
            }
        }

        public void Clear()
        {
            lock (myLock)
            {
                m_items.Clear();
            }
            if (Change != null)
                Change.Invoke();
        }

        /*public void Sort(SortIndex SortBy, bool ascending)
        {
            switch (SortBy)
            {
                case SortIndex.EPC:
                    m_items.Sort(new LvEpcSorter(ascending));
                    break;
            }
        }

        private class LvEpcSorter : IComparer<TagCallbackInfo>
        {
            private bool Ascending = false;
            public LvEpcSorter(bool ascending)
            {
                Ascending = ascending;
            }

            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                int nResult = obj2.epc.CompareTo(obj1.epc);
                if (nResult != 0)
                {
                    nResult = Ascending ? nResult : -nResult;
                }
                return nResult;
            }
        }
        private class LvCntSorter : IComparer<TagCallbackInfo>
        {
            private bool Ascending = false;
            public LvCntSorter(bool ascending)
            {
                Ascending = ascending;
            }
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                int nResult = ((TagCallbackInfo)obj2).count.CompareTo(((TagCallbackInfo)obj1).count);
                if (nResult != 0)
                {
                    nResult = Ascending ? -nResult : nResult;
                }
                return nResult;
            }
        }
        private class LvRssiSorter : IComparer<TagCallbackInfo>
        {
            private bool Ascending = false;
            public LvRssiSorter(bool ascending)
            {
                Ascending = ascending;
            }
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                int nResult = ((TagCallbackInfo)obj2).rssi.CompareTo(((TagCallbackInfo)obj1).rssi);
                if (nResult != 0)
                {
                    nResult = Ascending ? -nResult : nResult;
                }
                return nResult;
            }
        }
        private class LvIndexSorter : IComparer<TagCallbackInfo>
        {
            private bool Ascending = false;
            public LvIndexSorter(bool ascending)
            {
                Ascending = ascending;
            }
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                int nResult = ((TagCallbackInfo)obj2).index.CompareTo(((TagCallbackInfo)obj1).index);
                if (nResult != 0)
                {
                    nResult = Ascending ? -nResult : nResult;
                }
                return nResult;
            }
        }*/

    }
}
