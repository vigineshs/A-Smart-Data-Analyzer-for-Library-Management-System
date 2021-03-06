using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

using Reader.Net;

namespace CS203DEMO.ListBoxEx
{
    class ListBoxEx : System.Windows.Forms.ListBox
    {
        private const int TOP_SCROLLOFFSET = 25;
        private const int TOP_OFFSET = 0;
        private const int CELL_HEIGHT = 65;

        // Absolute Location Of Text Boxes
        private const int TEXT1_TOP = 10;
        private const int TEXT1_LEFT = 10;

        private const int TEXT2_TOP = 10;
        private const int TEXT2_LEFT = 300;

        private const int TEXT3_TOP = 27;
        private const int TEXT3_LEFT = 10;

        private const int TEXT4_TOP = 28;
        private const int TEXT4_LEFT = 300;

        private const int TEXT5_TOP = 43;
        private const int TEXT5_LEFT = 10;

        private const int TEXT6_TOP = 43;
        private const int TEXT6_LEFT = 300;
        /* 3D border styles */
        private const int BDR_RAISEDOUTER = 0x0001;
        private const int BDR_SUNKENOUTER = 0x0002;
        private const int BDR_RAISEDINNER = 0x0004;
        private const int BDR_SUNKENINNER = 0x0008;
        private const int BDR_OUTER = (BDR_RAISEDOUTER | BDR_SUNKENOUTER);
        private const int BDR_INNER = (BDR_RAISEDINNER | BDR_SUNKENINNER);
        private const int BDR_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER);
        private const int BDR_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER);
        private const int EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER);
        private const int EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER);
        private const int EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER);
        private const int EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER);
        /* Border flags */
        private const int BF_LEFT = 0x0001;
        private const int BF_TOP = 0x0002;
        private const int BF_RIGHT = 0x0004;
        private const int BF_BOTTOM = 0x0008;

        private const int BF_TOPLEFT = (BF_TOP | BF_LEFT);
        private const int BF_TOPRIGHT = (BF_TOP | BF_RIGHT);
        private const int BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT);
        private const int BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT);
        private const int BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM);
        /* Background Modes */
        private const int TRANSPARENT = 1;
        private const int OPAQUE = 2;
        private const int BKMODE_LAST = 2;
        private Color BLUE = Color.FromArgb(0, 0, 255);
        private Color WHITE = Color.FromArgb(255, 255, 255);
        private Color BLACK = Color.FromArgb(0, 0, 0);
        private Color YELLOW = Color.FromArgb(255, 255, 0);

        private Color TextColor = Color.Black;


        const uint MAX_ENTRIES = 256;
        uint m_numcells = 0;
        public NETDISPLAY_ENTRY[] devicelist = new NETDISPLAY_ENTRY[MAX_ENTRIES];
        private Bitmap buffering;


        public ListBoxEx() : base()
        {
            this.ItemHeight = CELL_HEIGHT;
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        /// <summary>
        /// Flicker Free Handle
        /// </summary>
        /// <param name="m"></param>
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        public void RemoveAllEntries()
        {
            int i;

            // Delete all entries 
            for (i = 0; i < MAX_ENTRIES; i++)
            {
                if (devicelist[i] != null)
                {
                    devicelist[i] = null;
                }
            }

            // Update number of cells
            m_numcells = 0;
            //m_selectedcell = -1;

            // Update the scroll bar and redraw window
            this.Items.Clear();
        }

        public bool AddEntry(NETDISPLAY_ENTRY pEntry)
        {
            int i;
            NETDISPLAY_ENTRY pNewEntry;

            // Find the next available entry
            for (i = 0; i < MAX_ENTRIES; i++)
            {
                if (devicelist[i] == null)
                {
                    break;
                }
            }

            // If no entries could be found
            if (i == MAX_ENTRIES)
            {
                return false;
            }

            //-----------------------------
            // Add the entry at location i
            //-----------------------------

            // Create new entry
            pNewEntry = new NETDISPLAY_ENTRY();

            // Copy the entry data
            pNewEntry.mode = pEntry.mode;

            pNewEntry.time_on_powered = pEntry.time_on_powered;

            pNewEntry.time_on_network = pEntry.time_on_network;

            pNewEntry.mac = (byte[])pEntry.mac.Clone();
            pNewEntry.ip = (byte[])pEntry.ip.Clone();

            pNewEntry.port = pEntry.port;

            pNewEntry.DHCP = pEntry.DHCP;
            pNewEntry.serverport = pEntry.serverport;
            pNewEntry.tcptimeout = pEntry.tcptimeout;

            pNewEntry.device_name = pEntry.device_name;
            pNewEntry.description = pEntry.description;

            // Store address in global array
            devicelist[i] = pNewEntry;

            // Increment valid cell count
            m_numcells++;

            this.Items.Add(" ");
            // Update the scroll bar, sort, and redraw window

            return true;
        }

        public bool IsCellSelected()
        {
            return (SelectedIndex != -1);
        }

        #region Protected Function

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            //If not a valid index just ignore
            if ((e.Index < 0) || (e.Index >= devicelist.Length))
                return;
            DrawCell(e.Graphics);

        }

        protected void DrawCell(Graphics e)
        {
            Debug.WriteLine("DrawCell");
            if (buffering == null)
                buffering = new Bitmap(this.Bounds.Width, this.Bounds.Height);
            using (Graphics gx = Graphics.FromImage(buffering))
            {
                gx.Clear(this.BackColor);
                // Obtain a rectangle containing the canvas coordinates
                RECT canvas_rect;
                GetClientRect(this.Handle, out canvas_rect);

                //------------------------------------------------------
                // Draw each of the cells
                //------------------------------------------------------

                // Create a rectangle containing the first cell coordinates
                RECT cell_rect;
                cell_rect.left = (canvas_rect.left + 2);
                cell_rect.right = (canvas_rect.right - 1);
                cell_rect.top = (canvas_rect.top + TOP_OFFSET + 2 - (CELL_HEIGHT * GetScrollPos(this.Handle, ScrollBar.SB_VERT)));
                cell_rect.bottom = (cell_rect.top + CELL_HEIGHT);

                // Paint each of the individual cells from first to last
                for (uint i = 0; i < Items.Count; i++)
                {

                    if (devicelist[i] != null && devicelist.Length > 0)
                    {

                        // Paint first cell + remaining cells
                        PaintCell(gx, ref cell_rect, devicelist[i], i);

                        // Add an offset to the next cell's coordinates
                        cell_rect.top += CELL_HEIGHT;
                        cell_rect.bottom += CELL_HEIGHT;
                    }
                    /*else
                    {
                        MessageBox.Show("null pointer");
                    }*/
                }


                //------------------------------------------------------
                // Draw a border around the canvas
                //------------------------------------------------------
                IntPtr hdc = gx.GetHdc();
                DrawEdge(hdc, ref canvas_rect, BDR_SUNKENINNER | BDR_SUNKENOUTER, BF_RECT);
                gx.ReleaseHdc(hdc);
                e.DrawImage(buffering, new Point(0, 0));
                System.Threading.Thread.Sleep(1);
            }
        }

        protected void PaintCell(Graphics gx, ref RECT pCell_Rect, Reader.Net.NETDISPLAY_ENTRY pEntry, uint entry_number)
        {
            // Make a copy of the passed cell rectangle
            RECT cell_rect = pCell_Rect;

            // Draw the cell border on top and bottom
            IntPtr hdc = gx.GetHdc();
            DrawEdge(hdc, ref cell_rect, EDGE_ETCHED, BF_TOP | BF_BOTTOM);
            gx.ReleaseHdc(hdc);
            //-----------------------
            // Set Background Color
            //-----------------------

            bool white_text = true;

            int r1 = 0xff, g1 = 0xFF, b1 = 0xFF; // Initialize to white 
            int r2 = 0xff, g2 = 0xff, b2 = 0xff; // Initial values should never be seen

            // Specify the Start and Stop color 
            switch (pEntry.mode)
            {

                case Reader.Net.Mode.Bootloader: // Select Gold

                    r1 = 0xff; g1 = 0xff; b1 = 0x00;  // Start color
                    r2 = 0xff; g2 = 0xcc; b2 = 0x00;	// Stop color
                    white_text = false;
                    break;


                case Reader.Net.Mode.Unknown: // Select Red
                    r1 = 0xfc; g1 = 0xc6; b1 = 0x0a;  // Start color
                    r2 = 0xff; g2 = 0x00; b2 = 0x00;	// Stop color
                    white_text = false;
                    break;


                case Reader.Net.Mode.Normal: // Select Green 
                    r1 = 0x66; g1 = 0xff; b1 = 0x66;  // Start color 
                    r2 = 0x00; g2 = 0xcc; b2 = 0x00;	// Stop color 
                    white_text = false;
                    break;

            }


            // Color the cell
            for (int i = 0; i < Math.Abs(cell_rect.top - cell_rect.bottom); i++)
            {
                int r, g, b;
                r = r1 + (i * (r2 - r1) / Math.Abs(cell_rect.top - cell_rect.bottom));
                g = g1 + (i * (g2 - g1) / Math.Abs(cell_rect.top - cell_rect.bottom));
                b = b1 + (i * (b2 - b1) / Math.Abs(cell_rect.top - cell_rect.bottom));

                gx.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)),
                    new Rectangle(cell_rect.left, cell_rect.top + i, Math.Abs(cell_rect.right - cell_rect.left), 1));
            }

            //-----------------------
            // Create Fonts + Colors
            //-----------------------
            Font large_bold_font = new Font("Arial", 12, FontStyle.Bold);
            Font mid_font = new Font("Arial", 12, FontStyle.Regular);
            Font mid_bold_font = new Font("Arial", 14, FontStyle.Bold);

            //-----------------------
            // Write the text
            //-----------------------

            Color org_color;								// Temporary Variable
            string temp_str;					// Temporary Strings


            // Do not overwrite the background -- FILL OFF
            hdc = gx.GetHdc();
            SetBkMode(hdc, TRANSPARENT);
            gx.ReleaseHdc(hdc);
            // Set the default color
            if (white_text)
                TextColor = Color.Black;
            else
                TextColor = Color.Black;


            //-------------------------------------------------------
            // Write the first label <TEXT1> -- Device Name/Type
            //-------------------------------------------------------

            gx.DrawString(pEntry.device_name, large_bold_font, new SolidBrush(TextColor),
                new PointF(cell_rect.left + TEXT1_LEFT,
                    cell_rect.top + TEXT1_TOP));

            //-------------------------------------------------------
            // Write the second label <TEXT2> -- IP Address
            //-------------------------------------------------------

            // If sorted by this method
            if (true)
            {

                // Set Color
                if (white_text)
                {
                    org_color = TextColor;
                    TextColor = Color.Yellow;
                }
                else
                {
                    org_color = TextColor;
                    TextColor = Color.Blue;
                }

            }
            else
            {
                // normal color
            }

            temp_str = string.Format("IP Address: {0}.{1}.{2}.{3}", pEntry.ip[0], pEntry.ip[1], pEntry.ip[2], pEntry.ip[3]);
            gx.DrawString(temp_str, large_bold_font, new SolidBrush(TextColor),
                new PointF(cell_rect.left + TEXT2_LEFT,
                    cell_rect.top + TEXT2_TOP));
            // If color changed, restore color
            if (true)
                TextColor = org_color;

            //-------------------------------------------------------
            // Write the third label <TEXT3> - Additional Description
            //-------------------------------------------------------

            gx.DrawString(pEntry.description, mid_font, new SolidBrush(TextColor),
            new PointF(cell_rect.left + TEXT3_LEFT,
                cell_rect.top + TEXT3_TOP));

            //-------------------------------------------------------
            // Write the fourth label <TEXT4> -- Mac Address
            //-------------------------------------------------------

            {
                temp_str = string.Format("MAC Address: {0:X2}-{1:X2}-{2:X2}-{3:X2}-{4:X2}-{5:X2}", pEntry.mac[0], pEntry.mac[1], pEntry.mac[2], pEntry.mac[3], pEntry.mac[4], pEntry.mac[5]);
                gx.DrawString(temp_str, mid_font, new SolidBrush(TextColor),
                new PointF(cell_rect.left + TEXT4_LEFT,
                cell_rect.top + TEXT4_TOP));

            }

            // Raised edge if selected
            if (entry_number == SelectedIndex)
            {

                IntPtr brush1 = CreateSolidBrush((uint)new RGB(Color.Black).ToInt32());
                int i;

                RECT sel;
                sel = cell_rect;
                sel.right -= 1;
                hdc = gx.GetHdc();
                FrameRect(hdc, ref sel, brush1);
                gx.ReleaseHdc(hdc);

                // Thicken Border
                for (i = 0; i < 6; i++)
                {
                    sel.left += 1;
                    sel.bottom -= 1;
                    sel.right -= 1;
                    sel.top += 1;
                    hdc = gx.GetHdc();
                    FrameRect(hdc, ref sel, brush1);
                    gx.ReleaseHdc(hdc);

                }
                DeleteObject(brush1);
            }

            //-----------------------
            // Cleanup
            //-----------------------

            // Delete Fonts
            large_bold_font.Dispose();
            mid_font.Dispose();
            mid_bold_font.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        #endregion

        #region Win32
        [StructLayout(LayoutKind.Sequential)]
        public struct RGB
        {
            byte byRed, byGreen, byBlue, RESERVED;

            public RGB(Color colorIn)
            {
                byRed = colorIn.R;
                byGreen = colorIn.G;
                byBlue = colorIn.B;
                RESERVED = 0;
            }
            public Int32 ToInt32()
            {
                byte[] RGBCOLORS = new byte[4];
                RGBCOLORS[0] = byRed;
                RGBCOLORS[1] = byGreen;
                RGBCOLORS[2] = byBlue;
                RGBCOLORS[3] = RESERVED;
                return BitConverter.ToInt32(RGBCOLORS, 0);
            }
        }

        [DllImport("user32.dll")]
        static extern bool DrawEdge(IntPtr hdc, ref RECT qrc, uint edge, uint grfFlags);
        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        enum ScrollBar : int
        {
            SB_HORZ = 0,
            SB_VERT,
            SB_CTL,
            SB_BOTH,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetScrollPos(IntPtr hWnd, ScrollBar nBar);

        [DllImport("user32.dll")]
        static extern int FrameRect(IntPtr hdc, [In] ref RECT lprc, IntPtr hbr);

        [DllImport("gdi32.dll")]
        static extern int SetBkMode(IntPtr hdc, int iBkMode);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        #endregion

    }
}
