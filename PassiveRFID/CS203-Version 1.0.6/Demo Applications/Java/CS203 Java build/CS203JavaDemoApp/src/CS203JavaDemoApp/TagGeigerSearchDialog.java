package CS203JavaDemoApp;

import java.awt.*;
import java.util.*;
import javax.swing.table.*;
import CSLibrary.Events.*;
import CSLibrary.Constants.*;
import CSLibrary.Structures.*;
import CSLibrary.Text.*;
import CSLibrary.Tools.*;
import CSLibrary.Message.*;

/**
 *
 * @author gene.yeung
 */
public class TagGeigerSearchDialog extends javax.swing.JDialog implements StateChangedEventListener, AsyncCallbackEventListener {

    // <editor-fold defaultstate="collapsed" desc="Variable">
    private class Opts{
        final public static int UNKNOWN = -1;
        final public static int TAG_SEARCH = 0;
        final public static int TAG_GEIGER = 1;
    }
    private java.util.Timer zeroDetectTimer = null;
    private java.util.Timer toneTimer = null;
    private int[] ThresholdArr = new int[] { 0, 50, 65, 70};
    private boolean m_rssiTimeout = false;
    private int m_rssi = 0;
    private int m_opt = Opts.UNKNOWN;
    private DefaultTableModel searchTableModel;
    private String selectedPC = "";
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Init">
    /** Creates new form TagKillDialog */
    public TagGeigerSearchDialog(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();

        //Center the dialog
        Dimension size = getSize();
        setLocation((Main.screen.width - size.width)/2, (Main.screen.height - size.height)/2);

        searchTableModel = (DefaultTableModel)table_search.getModel();

        lbl_threshold.setText(Integer.toString(slider_threshold.getValue()));
    }
    // </editor-fold>

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jTabbedPane1 = new javax.swing.JTabbedPane();
        Panel_SelectTag = new javax.swing.JPanel();
        jScrollPane1 = new javax.swing.JScrollPane();
        table_search = new javax.swing.JTable();
        btn_search = new javax.swing.JButton();
        btn_clear = new javax.swing.JButton();
        tf_selectedEPC = new javax.swing.JTextField();
        Panel_ReadAll = new javax.swing.JPanel();
        lbl_pcepctext = new javax.swing.JLabel();
        btn_geiger = new javax.swing.JButton();
        lbl_pcepc = new javax.swing.JLabel();
        jPanel1 = new javax.swing.JPanel();
        pgb_rssi = new javax.swing.JProgressBar();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        chb_avgRSSI = new javax.swing.JCheckBox();
        slider_threshold = new javax.swing.JSlider();
        jLabel4 = new javax.swing.JLabel();
        lbl_threshold = new javax.swing.JLabel();
        lbl_rssi = new javax.swing.JLabel();
        chb_tone = new javax.swing.JCheckBox();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setTitle("Geiger Search");
        setModal(true);
        setResizable(false);
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowClosing(java.awt.event.WindowEvent evt) {
                formWindowClosing(evt);
            }
            public void windowOpened(java.awt.event.WindowEvent evt) {
                formWindowOpened(evt);
            }
        });

        jTabbedPane1.setPreferredSize(new java.awt.Dimension(318, 232));
        jTabbedPane1.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                jTabbedPane1StateChanged(evt);
            }
        });

        Panel_SelectTag.setPreferredSize(new java.awt.Dimension(308, 186));

        table_search.setAutoCreateRowSorter(true);
        table_search.setFont(new java.awt.Font("Arial", 0, 18)); // NOI18N
        table_search.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {
                "PC", "EPC"
            }
        ) {
            Class[] types = new Class [] {
                java.lang.String.class, java.lang.String.class
            };
            boolean[] canEdit = new boolean [] {
                false, false
            };

            public Class getColumnClass(int columnIndex) {
                return types [columnIndex];
            }

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        table_search.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        table_search.getTableHeader().setReorderingAllowed(false);
        table_search.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                table_searchMousePressed(evt);
            }
        });
        table_search.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyReleased(java.awt.event.KeyEvent evt) {
                table_searchKeyReleased(evt);
            }
        });
        jScrollPane1.setViewportView(table_search);
        table_search.getColumnModel().getColumn(0).setPreferredWidth(40);
        table_search.getColumnModel().getColumn(1).setPreferredWidth(280);

        btn_search.setBackground(java.awt.Color.green);
        btn_search.setFont(new java.awt.Font("Arial", 0, 18));
        btn_search.setText("Search");
        btn_search.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_searchActionPerformed(evt);
            }
        });

        btn_clear.setBackground(java.awt.Color.orange);
        btn_clear.setFont(new java.awt.Font("Arial", 0, 18));
        btn_clear.setText("Clear");
        btn_clear.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_clearActionPerformed(evt);
            }
        });

        tf_selectedEPC.setBackground(java.awt.Color.pink);
        tf_selectedEPC.setFont(new java.awt.Font("Arial", 0, 14));
        tf_selectedEPC.setText("Select or Enter EPC ID");
        tf_selectedEPC.addFocusListener(new java.awt.event.FocusAdapter() {
            public void focusGained(java.awt.event.FocusEvent evt) {
                tf_selectedEPCFocusGained(evt);
            }
        });

        org.jdesktop.layout.GroupLayout Panel_SelectTagLayout = new org.jdesktop.layout.GroupLayout(Panel_SelectTag);
        Panel_SelectTag.setLayout(Panel_SelectTagLayout);
        Panel_SelectTagLayout.setHorizontalGroup(
            Panel_SelectTagLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, jScrollPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 424, Short.MAX_VALUE)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, Panel_SelectTagLayout.createSequentialGroup()
                .addContainerGap()
                .add(btn_search)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(btn_clear)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(tf_selectedEPC, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE)
                .addContainerGap())
        );
        Panel_SelectTagLayout.setVerticalGroup(
            Panel_SelectTagLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_SelectTagLayout.createSequentialGroup()
                .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 264, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(Panel_SelectTagLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(btn_search)
                    .add(btn_clear)
                    .add(tf_selectedEPC, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jTabbedPane1.addTab("Select Tag", Panel_SelectTag);

        Panel_ReadAll.setPreferredSize(new java.awt.Dimension(308, 202));

        lbl_pcepctext.setFont(new java.awt.Font("Arial", 0, 18));
        lbl_pcepctext.setText("EPC");

        btn_geiger.setBackground(java.awt.Color.green);
        btn_geiger.setFont(new java.awt.Font("Arial", 0, 18));
        btn_geiger.setText("Geiger");
        btn_geiger.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_geigerActionPerformed(evt);
            }
        });

        lbl_pcepc.setFont(new java.awt.Font("Arial", 0, 18));
        lbl_pcepc.setForeground(java.awt.Color.blue);
        lbl_pcepc.setText("000000000000000000000000");

        jPanel1.setBackground(new java.awt.Color(153, 255, 255));

        pgb_rssi.setFont(new java.awt.Font("Arial", 0, 18));

        jLabel1.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel1.setText("0");

        jLabel2.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel2.setText("50");

        jLabel3.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel3.setText("100");

        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(pgb_rssi, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 404, Short.MAX_VALUE)
                    .add(jPanel1Layout.createSequentialGroup()
                        .add(jLabel1)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 177, Short.MAX_VALUE)
                        .add(jLabel2)
                        .add(167, 167, 167)
                        .add(jLabel3)))
                .addContainerGap())
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel1)
                    .add(jLabel3)
                    .add(jLabel2))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .add(pgb_rssi, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 33, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );

        chb_avgRSSI.setFont(new java.awt.Font("Arial", 0, 18));
        chb_avgRSSI.setSelected(true);
        chb_avgRSSI.setText("Averaging RSSI");

        slider_threshold.setMinimum(61);
        slider_threshold.setMinorTickSpacing(1);
        slider_threshold.setPaintTicks(true);
        slider_threshold.setValue(75);
        slider_threshold.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                slider_thresholdStateChanged(evt);
            }
        });

        jLabel4.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel4.setText("Threshold");

        lbl_threshold.setFont(new java.awt.Font("Arial", 0, 18));
        lbl_threshold.setText("75");

        lbl_rssi.setFont(new java.awt.Font("Arial", 0, 18));
        lbl_rssi.setForeground(java.awt.Color.red);
        lbl_rssi.setText("0");

        chb_tone.setFont(new java.awt.Font("Arial", 0, 18));
        chb_tone.setSelected(true);
        chb_tone.setText("Tone");

        org.jdesktop.layout.GroupLayout Panel_ReadAllLayout = new org.jdesktop.layout.GroupLayout(Panel_ReadAll);
        Panel_ReadAll.setLayout(Panel_ReadAllLayout);
        Panel_ReadAllLayout.setHorizontalGroup(
            Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_ReadAllLayout.createSequentialGroup()
                .addContainerGap()
                .add(lbl_pcepctext)
                .add(50, 50, 50)
                .add(lbl_pcepc, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 249, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(78, Short.MAX_VALUE))
            .add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
            .add(Panel_ReadAllLayout.createSequentialGroup()
                .addContainerGap()
                .add(btn_geiger, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 100, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(41, 41, 41)
                .add(lbl_rssi, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 110, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(163, Short.MAX_VALUE))
            .add(Panel_ReadAllLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(Panel_ReadAllLayout.createSequentialGroup()
                        .add(slider_threshold, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 404, Short.MAX_VALUE)
                        .addContainerGap())
                    .add(Panel_ReadAllLayout.createSequentialGroup()
                        .add(chb_avgRSSI)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(chb_tone)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 66, Short.MAX_VALUE)
                        .add(jLabel4)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(lbl_threshold)
                        .add(19, 19, 19))))
        );
        Panel_ReadAllLayout.setVerticalGroup(
            Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_ReadAllLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(lbl_pcepctext)
                    .add(lbl_pcepc))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(lbl_threshold)
                    .add(chb_avgRSSI)
                    .add(jLabel4)
                    .add(chb_tone))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(slider_threshold, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 42, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .add(Panel_ReadAllLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(btn_geiger)
                    .add(lbl_rssi, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 23, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(106, 106, 106))
        );

        jTabbedPane1.addTab("Geiger", Panel_ReadAll);

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jTabbedPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 429, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jTabbedPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 335, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    // <editor-fold defaultstate="collapsed" desc="Event Handle">
    private void AttachCallback(boolean en)
    {
        if (en)
        {
            Main.ReaderXP.addStateChangedEventListener(this);
            Main.ReaderXP.addAsyncCallbackEventListener(this);
        }
        else
        {
            Main.ReaderXP.removeStateChangedEventListener(this);
            Main.ReaderXP.removeAsyncCallbackEventListener(this);
        }
    }

    //callback function
    public void StateChangedEvent(StateChangedEventArgs ev)
    {
        switch (ev.state)
        {
            case RFState.IDLE:
                SetSearchButtonState(false);
                SetGeigerButtonState(false);
                switch (m_opt)
                {
                    case Opts.TAG_SEARCH:
                        break;
                    case Opts.TAG_GEIGER:
                        break;
                }
                break;
            case RFState.BUSY:
                switch (m_opt)
                {
                    case Opts.TAG_SEARCH:
                        SetSearchButtonState(true);
                        break;
                    case Opts.TAG_GEIGER:
                        SetGeigerButtonState(true);
                        break;
                }
                break;
            case RFState.STOPPING:
                break;
            case RFState.NOT_INITIALIZED:
                break;
        }
    }

    public void AsyncCallbackEvent(AsyncCallbackEventArgs ev)
    {
        if (ev.type == CallbackType.TAG_INVENTORY)
        {
            TagCallbackInfo record = ev.info;

            Object[] entry = new Object[] {record.pc.ToString(), record.epc.ToString()};
            searchTableModel.addRow(entry);
            Sound.Beep(2000, 10);
        }
        if (ev.type == CallbackType.TAG_SEARCHING)
        {
            m_rssiTimeout = false;
            
            m_rssi = (int)((TagCallbackInfo)ev.info).rssi;

            lbl_rssi.setText(Integer.toString(m_rssi));

            UpdateProgressValue(m_rssi);
        }
    }
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Other Handle">
    private void formWindowOpened(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowOpened
        AttachCallback(true);
    }//GEN-LAST:event_formWindowOpened

    private void formWindowClosing(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowClosing
        if (Main.ReaderXP.GetState() != RFState.IDLE)
        {
            Main.ReaderXP.StopOperation(true);
            if (m_opt == Opts.TAG_GEIGER)
            {
                zeroDetectTimer.cancel();
                toneTimer.cancel();
            }
        }
        while(Main.ReaderXP.GetState() != RFState.IDLE)
        {
            try {
                Thread.sleep(100);
            }
            catch(InterruptedException e) {}
        }
        AttachCallback(false);
        evt.getWindow().dispose();
    }//GEN-LAST:event_formWindowClosing

    private void table_searchKeyReleased(java.awt.event.KeyEvent evt)
    {//GEN-FIRST:event_table_searchKeyReleased
        table_searchMousePressed(null);
    }//GEN-LAST:event_table_searchKeyReleased

    private void table_searchMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_table_searchMousePressed
        int i = table_search.getSelectedRow();
        tf_selectedEPC.setText(table_search.getValueAt(i, 1).toString());
        selectedPC = table_search.getValueAt(i, 0).toString();
}//GEN-LAST:event_table_searchMousePressed

    private void btn_searchActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_searchActionPerformed
        if (Main.ReaderXP.GetState() == RFState.IDLE) {
            Clear(Opts.TAG_SEARCH);
            Start();
        } else {
            Stop();
        }
}//GEN-LAST:event_btn_searchActionPerformed

    private void btn_clearActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_clearActionPerformed
        Clear(Opts.TAG_SEARCH);
}//GEN-LAST:event_btn_clearActionPerformed

    private void btn_geigerActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_geigerActionPerformed
        if (Main.ReaderXP.GetState() == RFState.IDLE) {
            m_opt = Opts.TAG_GEIGER;

            Main.ReaderXP.GetOptions().TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
            Main.ReaderXP.GetOptions().TagSelected.epcMask = new S_MASK(tf_selectedEPC.getText());
            Main.ReaderXP.GetOptions().TagSelected.epcMaskLength = Hex.GetBitLength(tf_selectedEPC.getText());
            if (Main.ReaderXP.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
            {
                MessageBox.ErrorShow("Selected tag failed");
                return;
            }

            Main.ReaderXP.SetOperationMode(Settings.custInventory_continuous ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
            Main.ReaderXP.GetOptions().TagSearchOne.avgRssi = chb_avgRSSI.isSelected();
            Main.ReaderXP.StartOperation(Operation.TAG_SEARCHING, false);

            zeroDetectTimer = new java.util.Timer();
            zeroDetectTimer.schedule(new ZeroDetectTask(), 100, 1000);
            toneTimer = new java.util.Timer();
            toneTimer.schedule(new ToneTask(), 10, 1000);
        } else {
            Stop();
            zeroDetectTimer.cancel();
            toneTimer.cancel();
        }
}//GEN-LAST:event_btn_geigerActionPerformed

    private void jTabbedPane1StateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_jTabbedPane1StateChanged
        if (Main.ReaderXP.GetState() != RFState.IDLE) {
            Main.ReaderXP.StopOperation(true);
            if (m_opt == Opts.TAG_GEIGER)
            {
                zeroDetectTimer.cancel();
                toneTimer.cancel();
            }
        }
        int selected = jTabbedPane1.getSelectedIndex();
        m_opt = selected;
        if (selected != Opts.TAG_SEARCH &&
            (tf_selectedEPC.getText().equals("") ||
            tf_selectedEPC.getText().equals("Select or Enter EPC ID"))) {
            MessageBox.ErrorShow("Please select or input a tag ID first.");
            jTabbedPane1.setSelectedIndex(0);
            return;
        }
        switch(selected) {
            case Opts.TAG_SEARCH:
                break;
            case Opts.TAG_GEIGER:
                String text = tf_selectedEPC.getText();
                lbl_pcepc.setText(text);
                lbl_pcepc.setToolTipText(text);
                break;
        }
}//GEN-LAST:event_jTabbedPane1StateChanged

    private void slider_thresholdStateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_slider_thresholdStateChanged
        ThresholdArr[3] = slider_threshold.getValue();
        lbl_threshold.setText(Integer.toString(slider_threshold.getValue()));
    }//GEN-LAST:event_slider_thresholdStateChanged

    private void tf_selectedEPCFocusGained(java.awt.event.FocusEvent evt) {//GEN-FIRST:event_tf_selectedEPCFocusGained
        tf_selectedEPC.setText("");
    }//GEN-LAST:event_tf_selectedEPCFocusGained
    
    private void Start()
    {
        if (Main.ReaderXP.GetState() == RFState.IDLE)
        {
            m_opt = Opts.TAG_SEARCH;
            Main.ReaderXP.SetOperationMode(Settings.custInventory_continuous ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
            Main.ReaderXP.SetTagGroup(Settings.tagGroup);
            Main.ReaderXP.SetSingulationAlgorithmParms(Settings.singulation, Settings.GetSingulationAlg());

            Main.ReaderXP.GetOptions().TagInventory.flags = SelectFlags.ZERO;
            Main.ReaderXP.StartOperation(Operation.TAG_INVENTORY, Settings.custInventory_blocking_mode);
        }
    }
    private void Stop()
    {
        if (Main.ReaderXP.GetState() == RFState.BUSY)
        {
            Main.ReaderXP.StopOperation(true);
        }
    }
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="UI Update">
    private void UpdateProgressValue(int value)
    {
        if (value > 100)
            pgb_rssi.setValue(100);
        else if (value < 0)
            pgb_rssi.setValue(0);
        else
            pgb_rssi.setValue(value);
    }

    private void Clear(int tab)
    {
        switch (tab)
        {
            case Opts.TAG_SEARCH:
                int len = searchTableModel.getRowCount();
                if (len > 0)
                {
                    for (int i = len-1; i >= 0; i--)
                        searchTableModel.removeRow(i);
                }
                tf_selectedEPC.setText("Select or Enter EPC ID");
                break;
            case Opts.TAG_GEIGER:
                break;
        }
    }
    private void SetSearchButtonState(boolean searching)
    {
        if (searching)
        {
            btn_search.setText("Stop");
            btn_search.setBackground(java.awt.Color.red);
            btn_clear.setEnabled(false);
        }
        else
        {
            btn_search.setText("Search");
            btn_search.setBackground(java.awt.Color.green);
            btn_clear.setEnabled(true);
        }
    }
    private void SetGeigerButtonState(boolean searching)
    {
        if (searching)
        {
            btn_geiger.setText("Stop");
            btn_geiger.setBackground(java.awt.Color.red);
            chb_avgRSSI.setEnabled(false);
        }
        else
        {
            btn_geiger.setText("Geiger");
            btn_geiger.setBackground(java.awt.Color.green);
            chb_avgRSSI.setEnabled(true);
        }
    }
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Timer Task">
    public class ZeroDetectTask extends TimerTask {
        public void run() {
            if (m_rssiTimeout)
            {
                pgb_rssi.setValue(0);
                lbl_rssi.setText("");
            }
            else
                m_rssiTimeout = true;
        }
    }

    public class ToneTask extends TimerTask {
        public void run() {
            if (!m_rssiTimeout && chb_tone.isSelected())
            {
                if (m_rssi > ThresholdArr[3])
                {
                    Sound.Beep(5000, 10);
                }
                else if (m_rssi <= ThresholdArr[3] && m_rssi > ThresholdArr[2])
                {
                    Sound.Beep(3000, 10);
                }
                else if (m_rssi <= ThresholdArr[2] && m_rssi > ThresholdArr[1])
                {
                    Sound.Beep(1000, 10);
                }
                else if (m_rssi <= ThresholdArr[1])
                {
                    Sound.Beep(1000, 10);
                }
            }
        }
    }
    // </editor-fold>

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                TagGeigerSearchDialog dialog = new TagGeigerSearchDialog(new javax.swing.JFrame(), true);
                dialog.addWindowListener(new java.awt.event.WindowAdapter() {
                    public void windowClosing(java.awt.event.WindowEvent e) {
                        System.exit(0);
                    }
                });
                dialog.setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel Panel_ReadAll;
    private javax.swing.JPanel Panel_SelectTag;
    private javax.swing.JButton btn_clear;
    private javax.swing.JButton btn_geiger;
    private javax.swing.JButton btn_search;
    private javax.swing.JCheckBox chb_avgRSSI;
    private javax.swing.JCheckBox chb_tone;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTabbedPane jTabbedPane1;
    private javax.swing.JLabel lbl_pcepc;
    private javax.swing.JLabel lbl_pcepctext;
    private javax.swing.JLabel lbl_rssi;
    private javax.swing.JLabel lbl_threshold;
    private javax.swing.JProgressBar pgb_rssi;
    private javax.swing.JSlider slider_threshold;
    private javax.swing.JTable table_search;
    private javax.swing.JTextField tf_selectedEPC;
    // End of variables declaration//GEN-END:variables

}