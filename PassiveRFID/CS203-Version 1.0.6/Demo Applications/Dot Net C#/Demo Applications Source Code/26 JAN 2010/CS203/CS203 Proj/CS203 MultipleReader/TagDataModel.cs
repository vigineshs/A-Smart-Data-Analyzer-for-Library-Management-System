using System;
using System.Collections.Generic;
using System.Text;
using CSLibrary.Windows.UI;
using CSLibrary.Structures;

namespace CS203_MultipleReader
{
    [Flags]
    public enum SlowFlags
    {
        INDEX = 1,
        EPC = 2,
        RSSI = 4,
        COUNT = 8,
        NAME = 16,
        ALL = INDEX | EPC | RSSI | COUNT | NAME
    }
    class TagDataModel : INTableModel
    {
        private object myLock = new object();

        private String[] m_displayColumnName;
        private Type[] m_columnType;
        private SlowFlags[] m_columnFlag;

        #region ITableModel Members
        private List<TagCallbackInfo> m_items = new List<TagCallbackInfo>();

        private SlowFlags flags = SlowFlags.ALL;

        public TagDataModel(SlowFlags flag)
        {
            SetDisplayColumnName(flags = flag);
        }

        public TagDataModel(List<TagCallbackInfo> data, SlowFlags flag)
        {
            m_items = data;
            SetDisplayColumnName(flags = flag);
        }

        private void SetDisplayColumnName(SlowFlags flag)
        {
            int index = 0;
            m_displayColumnName = new string[GetColumnCount()];
            m_columnType = new Type[GetColumnCount()];
            m_columnFlag = new SlowFlags[GetColumnCount()];
            if ((flags & SlowFlags.INDEX) == SlowFlags.INDEX)
            {
                m_displayColumnName[index] = "INDEX";
                m_columnType[index] = typeof(int);
                m_columnFlag[index] = SlowFlags.INDEX;
                index++;
            }
            if ((flags & SlowFlags.EPC) == SlowFlags.EPC)
            {
                m_displayColumnName[index] = "EPC";
                m_columnType[index] = typeof(String);
                m_columnFlag[index] = SlowFlags.EPC;
                index++;
            }
            if ((flags & SlowFlags.NAME) == SlowFlags.NAME)
            {
                m_displayColumnName[index] = "SOURCE";
                m_columnType[index] = typeof(string);
                m_columnFlag[index] = SlowFlags.NAME;
                index++;
            }
            if ((flags & SlowFlags.RSSI) == SlowFlags.RSSI)
            {
                m_displayColumnName[index] = "RSSI";
                m_columnType[index] = typeof(float);
                m_columnFlag[index] = SlowFlags.RSSI;
                index++;
            }
            if ((flags & SlowFlags.COUNT) == SlowFlags.COUNT)
            {
                m_displayColumnName[index] = "CNT";
                m_columnType[index] = typeof(int);
                m_columnFlag[index] = SlowFlags.COUNT;
            }     
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
            int Count = 0;//at least 1 Column
            if ((flags & SlowFlags.ALL) == SlowFlags.ALL)
            {
                return 5;
            }
            if ((flags & SlowFlags.INDEX) == SlowFlags.INDEX)
            {
                Count++;
            }
            if ((flags & SlowFlags.COUNT) == SlowFlags.COUNT)
            {
                Count++;
            }
            if ((flags & SlowFlags.EPC) == SlowFlags.EPC)
            {
                Count++;
            }
            if ((flags & SlowFlags.RSSI) == SlowFlags.RSSI)
            {
                Count++;
            }
            if ((flags & SlowFlags.NAME) == SlowFlags.NAME)
            {
                Count++;
            }
            return Count;/*Index-EPC-RSSI*/
        }

        public string GetColumnName(int columnIndex)
        {
            return m_displayColumnName[columnIndex];
        }

        public Type GetColumnClass(int columnIndex)
        {
            return m_columnType[columnIndex];
        }

        public bool IsCellEditable(int rowIndex, int columnIndex)
        {
            return false;
        }

        public object GetValueAt(int rowIndex, int columnIndex)
        {
            lock (myLock)
            {
                switch (m_columnFlag[columnIndex])
                {
                    case SlowFlags.COUNT: return m_items[rowIndex].count;
                    case SlowFlags.EPC: return m_items[rowIndex].epc;
                    case SlowFlags.INDEX: return rowIndex + 1;
                    case SlowFlags.RSSI: return m_items[rowIndex].rssi;
                    case SlowFlags.NAME: return m_items[rowIndex].name;
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

        public List<TagCallbackInfo> Items
        {
            get { return m_items; }
            set { m_items = value; }
        }

        public void Insert(TagCallbackInfo newElement)
        {

            lock (myLock)
            {
                TagCallbackInfo info = m_items.Find(delegate(TagCallbackInfo found) { return (found.epc.CompareTo(newElement.epc) == 0); });
                if (info != null)
                {
                    m_items[info.index].rssi = newElement.rssi;
                    m_items[info.index].count++;
                    m_items[info.index].name = newElement.name;
                }
                else
                {
                    //Finally do the insert by delegating to "InsertAt"
                    newElement.index = m_items.Count;
                    m_items.Add(newElement);
                }
            }
            if (Change != null)
            {
                Change.Invoke();
            }
        }

        public void UpdateItem(TagCallbackInfo info, int index)
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

        public void AddItem(TagCallbackInfo info)
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

        public void Sort(SortIndex SortBy, bool ascending)
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
        }

    }
}
