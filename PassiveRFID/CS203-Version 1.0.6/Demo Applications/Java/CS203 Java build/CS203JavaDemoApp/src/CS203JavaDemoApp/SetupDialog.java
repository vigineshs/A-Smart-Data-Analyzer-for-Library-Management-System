package CS203JavaDemoApp;

import java.awt.*;
import java.util.*;
import CSLibrary.Constants.*;
import CSLibrary.Structures.*;
import CSLibrary.Message.*;

public class SetupDialog extends javax.swing.JDialog {

    // <editor-fold defaultstate="collapsed" desc="Variable">
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Init">
    /** Creates new form SetupDialog */
    public SetupDialog(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();

        //Center the dialog
        Dimension size = getSize();
        setLocation((Main.screen.width - size.width)/2, (Main.screen.height - size.height)/2);

        int i;

        // Get available setting
        int[] profile = Main.ReaderXP.AvailableLinkProfile();
        for (i = 0; i < profile.length; i++)
        {
            cbb_profile.addItem(Integer.toString(profile[i]));
        }

        ArrayList countryList = Main.ReaderXP.AvailableRegionCode();
        for (i = 0; i < countryList.size(); i++)
        {
            cbb_country.addItem(RegionCode.ToString(Integer.parseInt(countryList.get(i).toString())));
        }

        double[] freqList = Main.ReaderXP.AvailableFrequencyTable(Settings.Region);
        for (i = 0; i < freqList.length; i++)
        {
            cbb_frequency.addItem(Double.toString(freqList[i]));
        }

        chb_fixedChannel.setEnabled(!Main.ReaderXP.IsFixedChannelOnly());
        chb_fixedChannel.setSelected(Settings.FixedChannel);
        cbb_frequency.setEnabled(Settings.FixedChannel);
        if (Main.ReaderXP.SelectedRegionCode() == RegionCode.JP)
        {
            chb_LBT.setEnabled(true);
            chb_LBT.setSelected(Settings.Lbt);
        }
        else
            chb_LBT.setEnabled(Settings.Lbt);

        cbb_algorithm.addItem(SingulationAlgorithm.ToString(SingulationAlgorithm.FIXEDQ));
        cbb_algorithm.addItem(SingulationAlgorithm.ToString(SingulationAlgorithm.DYNAMICQ));
        cbb_algorithm.addItem(SingulationAlgorithm.ToString(SingulationAlgorithm.DYNAMICQ_ADJUST));
        cbb_algorithm.addItem(SingulationAlgorithm.ToString(SingulationAlgorithm.DYNAMICQ_THRESH));
        cbb_algorithm.addItem(SingulationAlgorithm.ToString(SingulationAlgorithm.UNKNOWN));

        cbb_selected.addItem(Selected.ToString(Selected.ALL));
        cbb_selected.addItem(Selected.ToString(Selected.OFF));
        cbb_selected.addItem(Selected.ToString(Selected.ON));
        cbb_selected.addItem(Selected.ToString(Selected.UNKNOWN));

        cbb_session.addItem(Session.ToString(Session.S0));
        cbb_session.addItem(Session.ToString(Session.S1));
        cbb_session.addItem(Session.ToString(Session.S2));
        cbb_session.addItem(Session.ToString(Session.S3));
        cbb_session.addItem(Session.ToString(Session.UNKNOWN));

        cbb_target.addItem(SessionTarget.ToString(SessionTarget.A));
        cbb_target.addItem(SessionTarget.ToString(SessionTarget.B));
        cbb_target.addItem(SessionTarget.ToString(SessionTarget.UNKNOWN));

        // Set current setting
        cbb_profile.setSelectedItem(Integer.toString(Settings.Link_profile));
        tf_power.setText(Integer.toString(Settings.Power));
        cbb_country.setSelectedItem(RegionCode.ToString(Settings.Region));
        if (Settings.FixedChannel)
        {
            cbb_frequency.setSelectedIndex(Settings.Channel_number);
        }
        cbb_algorithm.setSelectedItem(SingulationAlgorithm.ToString(Settings.singulation));
        cbb_selected.setSelectedItem(Selected.ToString(Settings.tagGroup.selected));
        cbb_session.setSelectedItem(Session.ToString(Settings.tagGroup.session));
        cbb_target.setSelectedItem(SessionTarget.ToString(Settings.tagGroup.target));

        chb_custInvtryCont.setSelected(Settings.custInventory_continuous);
        chb_custInvtryBlocking.setSelected(Settings.custInventory_blocking_mode);

        SetupAlgorithmTab();
    }

    private void SetupAlgorithmTab()
    {
        // set fixed Q
        tf_fixQValue.setText(Integer.toString(Settings.fixedQ.qValue));
        tf_fixRetry.setText(Integer.toString(Settings.fixedQ.retryCount));
        chb_fixRepeat.setSelected(Settings.fixedQ.repeatUntilNoTags == 1);
        chb_fixToggle.setSelected(Settings.fixedQ.toggleTarget == 1);

        // set dynamic Q
        tf_dynQValue.setText(Integer.toString(Settings.dynamicQ.startQValue));
        tf_dynMinQ.setText(Integer.toString(Settings.dynamicQ.minQValue));
        tf_dynMaxQ.setText(Integer.toString(Settings.dynamicQ.maxQValue));
        tf_dynMaxQueryRep.setText(Integer.toString(Settings.dynamicQ.maxQueryRepCount));
        tf_dynRetry.setText(Integer.toString(Settings.dynamicQ.retryCount));
        chb_dynToggle.setSelected(Settings.dynamicQ.toggleTarget == 1);

        // set dynamic Q Adj
        tf_dynAdjQValue.setText(Integer.toString(Settings.dynamicQAdj.startQValue));
        tf_dynAdjMinQ.setText(Integer.toString(Settings.dynamicQAdj.minQValue));
        tf_dynAdjMaxQ.setText(Integer.toString(Settings.dynamicQAdj.maxQValue));
        tf_dynAdjMaxQueryRep.setText(Integer.toString(Settings.dynamicQAdj.maxQueryRepCount));
        tf_dynAdjRetry.setText(Integer.toString(Settings.dynamicQAdj.retryCount));
        chb_dynAdjToggle.setSelected(Settings.dynamicQAdj.toggleTarget == 1);

        // set dynamic Q Thres
        tf_dynThresQValue.setText(Integer.toString(Settings.dynamicQThres.startQValue));
        tf_dynThresMinQ.setText(Integer.toString(Settings.dynamicQThres.minQValue));
        tf_dynThresMaxQ.setText(Integer.toString(Settings.dynamicQThres.maxQValue));
        tf_dynThresMultiplier.setText(Integer.toString(Settings.dynamicQThres.thresholdMultiplier));
        tf_dynThresRetry.setText(Integer.toString(Settings.dynamicQThres.retryCount));
        chb_dynThresToggle.setSelected(Settings.dynamicQThres.toggleTarget == 1);
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
        jPanel1 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        cbb_profile = new javax.swing.JComboBox();
        chb_LBT = new javax.swing.JCheckBox();
        chb_fixedChannel = new javax.swing.JCheckBox();
        chb_saveSettings = new javax.swing.JCheckBox();
        tf_power = new javax.swing.JTextField();
        cbb_country = new javax.swing.JComboBox();
        cbb_frequency = new javax.swing.JComboBox();
        jPanel2 = new javax.swing.JPanel();
        jLabel5 = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        jLabel9 = new javax.swing.JLabel();
        chb_custInvtryCont = new javax.swing.JCheckBox();
        chb_custInvtryBlocking = new javax.swing.JCheckBox();
        cbb_selected = new javax.swing.JComboBox();
        cbb_session = new javax.swing.JComboBox();
        cbb_target = new javax.swing.JComboBox();
        cbb_algorithm = new javax.swing.JComboBox();
        jPanel3 = new javax.swing.JPanel();
        jLayeredPane1 = new javax.swing.JLayeredPane();
        Panel_DynamicQThres = new javax.swing.JPanel();
        jLabel24 = new javax.swing.JLabel();
        tf_dynThresQValue = new javax.swing.JTextField();
        tf_dynThresMinQ = new javax.swing.JTextField();
        tf_dynThresMaxQ = new javax.swing.JTextField();
        tf_dynThresMultiplier = new javax.swing.JTextField();
        tf_dynThresRetry = new javax.swing.JTextField();
        jLabel25 = new javax.swing.JLabel();
        jLabel26 = new javax.swing.JLabel();
        jLabel27 = new javax.swing.JLabel();
        jLabel28 = new javax.swing.JLabel();
        chb_dynThresToggle = new javax.swing.JCheckBox();
        jLabel39 = new javax.swing.JLabel();
        jLabel40 = new javax.swing.JLabel();
        jLabel41 = new javax.swing.JLabel();
        jLabel42 = new javax.swing.JLabel();
        jLabel43 = new javax.swing.JLabel();
        Panel_DynamicQAdj = new javax.swing.JPanel();
        jLabel19 = new javax.swing.JLabel();
        tf_dynAdjQValue = new javax.swing.JTextField();
        tf_dynAdjMinQ = new javax.swing.JTextField();
        tf_dynAdjMaxQ = new javax.swing.JTextField();
        tf_dynAdjMaxQueryRep = new javax.swing.JTextField();
        tf_dynAdjRetry = new javax.swing.JTextField();
        jLabel20 = new javax.swing.JLabel();
        jLabel21 = new javax.swing.JLabel();
        jLabel22 = new javax.swing.JLabel();
        jLabel23 = new javax.swing.JLabel();
        chb_dynAdjToggle = new javax.swing.JCheckBox();
        jLabel34 = new javax.swing.JLabel();
        jLabel35 = new javax.swing.JLabel();
        jLabel36 = new javax.swing.JLabel();
        jLabel37 = new javax.swing.JLabel();
        jLabel38 = new javax.swing.JLabel();
        Panel_DynamicQ = new javax.swing.JPanel();
        jLabel12 = new javax.swing.JLabel();
        jLabel13 = new javax.swing.JLabel();
        jLabel16 = new javax.swing.JLabel();
        jLabel17 = new javax.swing.JLabel();
        jLabel18 = new javax.swing.JLabel();
        chb_dynToggle = new javax.swing.JCheckBox();
        tf_dynQValue = new javax.swing.JTextField();
        tf_dynMinQ = new javax.swing.JTextField();
        tf_dynMaxQ = new javax.swing.JTextField();
        tf_dynMaxQueryRep = new javax.swing.JTextField();
        tf_dynRetry = new javax.swing.JTextField();
        jLabel29 = new javax.swing.JLabel();
        jLabel30 = new javax.swing.JLabel();
        jLabel31 = new javax.swing.JLabel();
        jLabel32 = new javax.swing.JLabel();
        jLabel33 = new javax.swing.JLabel();
        Panel_FixedQ = new javax.swing.JPanel();
        jLabel11 = new javax.swing.JLabel();
        jLabel10 = new javax.swing.JLabel();
        chb_fixToggle = new javax.swing.JCheckBox();
        chb_fixRepeat = new javax.swing.JCheckBox();
        tf_fixQValue = new javax.swing.JTextField();
        tf_fixRetry = new javax.swing.JTextField();
        jLabel14 = new javax.swing.JLabel();
        jLabel15 = new javax.swing.JLabel();
        btn_apply = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setTitle("Setup");
        setModal(true);
        setName("Setup"); // NOI18N
        setResizable(false);
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowClosing(java.awt.event.WindowEvent evt) {
                formWindowClosing(evt);
            }
        });

        jLabel1.setText("Profile");

        jLabel2.setText("Power");

        jLabel3.setText("Country");

        jLabel4.setText("Frequencies (MHz)");

        cbb_profile.setModel(new javax.swing.DefaultComboBoxModel());

        chb_LBT.setText("Enable LBT");

        chb_fixedChannel.setText("Fixed Channel");

        chb_saveSettings.setSelected(true);
        chb_saveSettings.setText("Save Settings");

        cbb_country.setModel(new javax.swing.DefaultComboBoxModel());

        cbb_frequency.setModel(new javax.swing.DefaultComboBoxModel());

        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                    .add(jLabel4, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(jLabel3, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(jLabel2, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(jLabel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(cbb_profile, 0, 95, Short.MAX_VALUE)
                    .add(tf_power, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 95, Short.MAX_VALUE)
                    .add(cbb_country, 0, 95, Short.MAX_VALUE)
                    .add(cbb_frequency, 0, 95, Short.MAX_VALUE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(chb_saveSettings)
                    .add(chb_LBT)
                    .add(chb_fixedChannel))
                .add(82, 82, 82))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jPanel1Layout.createSequentialGroup()
                        .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                            .add(jLabel1)
                            .add(cbb_profile, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                        .add(6, 6, 6)
                        .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                            .add(jLabel2)
                            .add(tf_power, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 21, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                            .add(cbb_country, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(jLabel3))
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                            .add(jLabel4)
                            .add(cbb_frequency, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))
                    .add(jPanel1Layout.createSequentialGroup()
                        .add(chb_LBT)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(chb_fixedChannel)
                        .add(23, 23, 23)
                        .add(chb_saveSettings)))
                .addContainerGap(87, Short.MAX_VALUE))
        );

        jTabbedPane1.addTab("General Options", jPanel1);

        jLabel5.setText("Operation");

        jLabel6.setText("Selected");

        jLabel7.setText("Session");

        jLabel8.setText("Target");

        jLabel9.setText("Algorithm");

        chb_custInvtryCont.setSelected(true);
        chb_custInvtryCont.setText("Continuous");

        chb_custInvtryBlocking.setText("Blocking mode");

        cbb_selected.setModel(new javax.swing.DefaultComboBoxModel());

        cbb_session.setModel(new javax.swing.DefaultComboBoxModel());

        cbb_target.setModel(new javax.swing.DefaultComboBoxModel());

        cbb_algorithm.setModel(new javax.swing.DefaultComboBoxModel());
        cbb_algorithm.addItemListener(new java.awt.event.ItemListener() {
            public void itemStateChanged(java.awt.event.ItemEvent evt) {
                cbb_algorithmItemStateChanged(evt);
            }
        });

        org.jdesktop.layout.GroupLayout jPanel2Layout = new org.jdesktop.layout.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel5)
                    .add(jLabel6)
                    .add(jLabel7)
                    .add(jLabel8)
                    .add(jLabel9))
                .add(30, 30, 30)
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jPanel2Layout.createSequentialGroup()
                        .add(chb_custInvtryCont)
                        .add(18, 18, 18)
                        .add(chb_custInvtryBlocking))
                    .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING, false)
                        .add(org.jdesktop.layout.GroupLayout.LEADING, cbb_algorithm, 0, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .add(org.jdesktop.layout.GroupLayout.LEADING, cbb_target, 0, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .add(org.jdesktop.layout.GroupLayout.LEADING, cbb_session, 0, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .add(org.jdesktop.layout.GroupLayout.LEADING, cbb_selected, 0, 122, Short.MAX_VALUE)))
                .addContainerGap(97, Short.MAX_VALUE))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel5)
                    .add(chb_custInvtryCont)
                    .add(chb_custInvtryBlocking))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel6)
                    .add(cbb_selected, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel7)
                    .add(cbb_session, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel8)
                    .add(cbb_target, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel9)
                    .add(cbb_algorithm, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(52, Short.MAX_VALUE))
        );

        jTabbedPane1.addTab("Custom Inventory", jPanel2);

        jLabel24.setText("StartQValue");

        jLabel25.setText("Retry");

        jLabel26.setText("Multiplier");

        jLabel27.setText("MaxQValue");

        jLabel28.setText("MinQValue");

        chb_dynThresToggle.setText("Toggle");

        jLabel39.setText("0-255");

        jLabel40.setText("0-255");

        jLabel41.setText("0-15");

        jLabel42.setText("0-15");

        jLabel43.setText("0-15");

        org.jdesktop.layout.GroupLayout Panel_DynamicQThresLayout = new org.jdesktop.layout.GroupLayout(Panel_DynamicQThres);
        Panel_DynamicQThres.setLayout(Panel_DynamicQThresLayout);
        Panel_DynamicQThresLayout.setHorizontalGroup(
            Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQThresLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(chb_dynThresToggle)
                    .add(Panel_DynamicQThresLayout.createSequentialGroup()
                        .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel24)
                            .add(jLabel28)
                            .add(jLabel27)
                            .add(jLabel26)
                            .add(jLabel25))
                        .add(27, 27, 27)
                        .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                            .add(tf_dynThresRetry)
                            .add(tf_dynThresMultiplier)
                            .add(tf_dynThresMaxQ)
                            .add(tf_dynThresMinQ)
                            .add(tf_dynThresQValue, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 97, Short.MAX_VALUE))
                        .add(18, 18, 18)
                        .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel39)
                            .add(jLabel40)
                            .add(jLabel41)
                            .add(jLabel42)
                            .add(jLabel43))))
                .addContainerGap(144, Short.MAX_VALUE))
        );
        Panel_DynamicQThresLayout.setVerticalGroup(
            Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQThresLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel24)
                    .add(tf_dynThresQValue, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel43))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel28)
                    .add(tf_dynThresMinQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel42))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel27)
                    .add(tf_dynThresMaxQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel41))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel26)
                    .add(tf_dynThresMultiplier, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel40))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQThresLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel25)
                    .add(tf_dynThresRetry, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel39))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(chb_dynThresToggle)
                .addContainerGap(26, Short.MAX_VALUE))
        );

        Panel_DynamicQThres.setBounds(0, 0, 380, 210);
        jLayeredPane1.add(Panel_DynamicQThres, javax.swing.JLayeredPane.DEFAULT_LAYER);

        jLabel19.setText("StartQValue");

        jLabel20.setText("Retry");

        jLabel21.setText("MaxQueryRep");

        jLabel22.setText("MaxQValue");

        jLabel23.setText("MinQValue");

        chb_dynAdjToggle.setText("Toggle");

        jLabel34.setText("0-255");

        jLabel35.setText("0-255");

        jLabel36.setText("0-15");

        jLabel37.setText("0-15");

        jLabel38.setText("0-15");

        org.jdesktop.layout.GroupLayout Panel_DynamicQAdjLayout = new org.jdesktop.layout.GroupLayout(Panel_DynamicQAdj);
        Panel_DynamicQAdj.setLayout(Panel_DynamicQAdjLayout);
        Panel_DynamicQAdjLayout.setHorizontalGroup(
            Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQAdjLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(chb_dynAdjToggle)
                    .add(Panel_DynamicQAdjLayout.createSequentialGroup()
                        .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel19)
                            .add(jLabel23)
                            .add(jLabel22)
                            .add(jLabel21)
                            .add(jLabel20))
                        .add(27, 27, 27)
                        .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                            .add(tf_dynAdjRetry)
                            .add(tf_dynAdjMaxQueryRep)
                            .add(tf_dynAdjMaxQ)
                            .add(tf_dynAdjMinQ)
                            .add(tf_dynAdjQValue, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 97, Short.MAX_VALUE))
                        .add(18, 18, 18)
                        .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel34)
                            .add(jLabel35)
                            .add(jLabel36)
                            .add(jLabel37)
                            .add(jLabel38))))
                .addContainerGap(131, Short.MAX_VALUE))
        );
        Panel_DynamicQAdjLayout.setVerticalGroup(
            Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQAdjLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel19)
                    .add(tf_dynAdjQValue, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel38))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel23)
                    .add(tf_dynAdjMinQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel37))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel22)
                    .add(tf_dynAdjMaxQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel36))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel21)
                    .add(tf_dynAdjMaxQueryRep, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel35))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQAdjLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel20)
                    .add(tf_dynAdjRetry, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel34))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(chb_dynAdjToggle)
                .addContainerGap(26, Short.MAX_VALUE))
        );

        Panel_DynamicQAdj.setBounds(0, 0, 380, 210);
        jLayeredPane1.add(Panel_DynamicQAdj, javax.swing.JLayeredPane.DEFAULT_LAYER);

        Panel_DynamicQ.setMinimumSize(new java.awt.Dimension(310, 160));

        jLabel12.setText("StartQValue");

        jLabel13.setText("MinQValue");

        jLabel16.setText("MaxQValue");

        jLabel17.setText("MaxQueryRep");

        jLabel18.setText("Retry");

        chb_dynToggle.setText("Toggle");

        jLabel29.setText("0-15");

        jLabel30.setText("0-15");

        jLabel31.setText("0-15");

        jLabel32.setText("0-255");

        jLabel33.setText("0-255");

        org.jdesktop.layout.GroupLayout Panel_DynamicQLayout = new org.jdesktop.layout.GroupLayout(Panel_DynamicQ);
        Panel_DynamicQ.setLayout(Panel_DynamicQLayout);
        Panel_DynamicQLayout.setHorizontalGroup(
            Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(chb_dynToggle)
                    .add(Panel_DynamicQLayout.createSequentialGroup()
                        .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel12)
                            .add(jLabel13)
                            .add(jLabel16)
                            .add(jLabel17)
                            .add(jLabel18))
                        .add(27, 27, 27)
                        .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                            .add(tf_dynRetry)
                            .add(tf_dynMaxQueryRep)
                            .add(tf_dynMaxQ)
                            .add(tf_dynMinQ)
                            .add(tf_dynQValue, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 97, Short.MAX_VALUE))
                        .add(18, 18, 18)
                        .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel33)
                            .add(jLabel32)
                            .add(jLabel31)
                            .add(jLabel30)
                            .add(jLabel29))))
                .addContainerGap(131, Short.MAX_VALUE))
        );
        Panel_DynamicQLayout.setVerticalGroup(
            Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_DynamicQLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel12)
                    .add(tf_dynQValue, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel29))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel13)
                    .add(tf_dynMinQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel30))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel16)
                    .add(tf_dynMaxQ, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel31))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel17)
                    .add(tf_dynMaxQueryRep, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel32))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_DynamicQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel18)
                    .add(tf_dynRetry, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel33))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(chb_dynToggle)
                .addContainerGap(26, Short.MAX_VALUE))
        );

        Panel_DynamicQ.setBounds(0, 0, 380, 210);
        jLayeredPane1.add(Panel_DynamicQ, javax.swing.JLayeredPane.DEFAULT_LAYER);

        jLabel11.setText("Q Value");

        jLabel10.setText("Retry");

        chb_fixToggle.setText("Toggle");

        chb_fixRepeat.setText("Repeat");

        jLabel14.setText("0-15");

        jLabel15.setText("0-255");

        org.jdesktop.layout.GroupLayout Panel_FixedQLayout = new org.jdesktop.layout.GroupLayout(Panel_FixedQ);
        Panel_FixedQ.setLayout(Panel_FixedQLayout);
        Panel_FixedQLayout.setHorizontalGroup(
            Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_FixedQLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(chb_fixRepeat)
                    .add(chb_fixToggle)
                    .add(Panel_FixedQLayout.createSequentialGroup()
                        .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel10)
                            .add(jLabel11))
                        .add(49, 49, 49)
                        .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                            .add(tf_fixRetry)
                            .add(tf_fixQValue, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 88, Short.MAX_VALUE))
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel15)
                            .add(jLabel14))))
                .addContainerGap(157, Short.MAX_VALUE))
        );
        Panel_FixedQLayout.setVerticalGroup(
            Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(Panel_FixedQLayout.createSequentialGroup()
                .addContainerGap()
                .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(tf_fixQValue, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel14)
                    .add(jLabel11))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Panel_FixedQLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel10)
                    .add(tf_fixRetry, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel15))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(chb_fixToggle)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(chb_fixRepeat)
                .addContainerGap(94, Short.MAX_VALUE))
        );

        Panel_FixedQ.setBounds(0, 0, 380, 210);
        jLayeredPane1.add(Panel_FixedQ, javax.swing.JLayeredPane.DEFAULT_LAYER);

        org.jdesktop.layout.GroupLayout jPanel3Layout = new org.jdesktop.layout.GroupLayout(jPanel3);
        jPanel3.setLayout(jPanel3Layout);
        jPanel3Layout.setHorizontalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jLayeredPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 379, Short.MAX_VALUE)
        );
        jPanel3Layout.setVerticalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jLayeredPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 209, Short.MAX_VALUE)
        );

        jTabbedPane1.addTab("Algorithm", jPanel3);

        btn_apply.setBackground(java.awt.Color.green);
        btn_apply.setText("Apply");
        btn_apply.setAlignmentY(0.0F);
        btn_apply.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_applyActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .addContainerGap(302, Short.MAX_VALUE)
                .add(btn_apply, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 72, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
            .add(jTabbedPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 384, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .add(jTabbedPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 235, Short.MAX_VALUE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(btn_apply)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents
    
    // <editor-fold defaultstate="collapsed" desc="UI Handle">
    private void formWindowClosing(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowClosing
        evt.getWindow().dispose();
    }//GEN-LAST:event_formWindowClosing

    private void btn_applyActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_applyActionPerformed
        if ((chb_custInvtryBlocking.isSelected() && chb_custInvtryCont.isSelected()))
        {
            MessageBox.ErrorShow("Cannot run blocking and continuous mode at the same time");
            return;
        }

        //Set PowerLevel
        if (isNumber(tf_power.getText()) && Main.ReaderXP.SetPowerLevel(Integer.parseInt(tf_power.getText())) != Result.OK)
        {
            MessageBox.ErrorShow("SetPowerLevel fail with err " + Integer.toString(Main.ReaderXP.LastResultCode()));
            return;
        }
        //Set LinkProfile
        if (Main.ReaderXP.SetCurrentLinkProfile(Integer.parseInt(cbb_profile.getSelectedItem().toString())) != Result.OK)
        {
            MessageBox.ErrorShow("SetCurrentLinkProfile fail with err " + Integer.toString(Main.ReaderXP.LastResultCode()));
            return;
        }

        //Set Region and Frequency
        Settings.FixedChannel = chb_fixedChannel.isSelected();
        if (chb_fixedChannel.isSelected())
        {
            if(cbb_frequency.getSelectedIndex() < 0 || cbb_frequency.getSelectedIndex() >= cbb_frequency.getItemCount())
            {
                MessageBox.ErrorShow("Please select a channel first");
                return;
            }
            if (Main.ReaderXP.SetFixedChannel(RegionCode.ToInt(cbb_country.getSelectedItem().toString()), cbb_frequency.getSelectedIndex(), chb_LBT.isSelected() ? LBT.ON : LBT.OFF) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.ErrorShow("SetFixedChannel fail with err " + Integer.toString(Main.ReaderXP.LastResultCode()));
                return;
            }
        }
        else
        {
            if (Main.ReaderXP.SetHoppingChannels(RegionCode.ToInt(cbb_country.getSelectedItem().toString())) != CSLibrary.Constants.Result.OK)
            {
                MessageBox.ErrorShow("SetHoppingChannels fail with err " + Integer.toString(Main.ReaderXP.LastResultCode()));
                return;
            }
        }

        Settings.custInventory_blocking_mode = chb_custInvtryBlocking.isSelected();
        Settings.custInventory_continuous = chb_custInvtryCont.isSelected();
        Settings.singulation = SingulationAlgorithm.ToInt(cbb_algorithm.getSelectedItem().toString());

        Settings.tagGroup = new TagGroup(Selected.ToInt(cbb_selected.getSelectedItem().toString()),
                                       Session.ToInt(cbb_session.getSelectedItem().toString()),
                                       SessionTarget.ToInt(cbb_target.getSelectedItem().toString()));

        ApplyAlgorithmTab();

        //Save all settings to config file
        if (chb_saveSettings.isSelected())
        {
            MainMenuFrame.SaveSettings();
        }

        this.dispose();
    }//GEN-LAST:event_btn_applyActionPerformed

    private void cbb_algorithmItemStateChanged(java.awt.event.ItemEvent evt) {//GEN-FIRST:event_cbb_algorithmItemStateChanged
        jTabbedPane1.setEnabledAt(2, true);
        if (SingulationAlgorithm.ToInt(evt.getItem().toString()) == SingulationAlgorithm.FIXEDQ)
        {
            jTabbedPane1.setTitleAt(2, "FixedQ");
            Panel_FixedQ.setVisible(true);
            Panel_DynamicQ.setVisible(false);
            Panel_DynamicQAdj.setVisible(false);
            Panel_DynamicQThres.setVisible(false);
        }
        else if (SingulationAlgorithm.ToInt(evt.getItem().toString()) == SingulationAlgorithm.DYNAMICQ)
        {
            jTabbedPane1.setTitleAt(2, "DynamicQ");
            Panel_FixedQ.setVisible(false);
            Panel_DynamicQ.setVisible(true);
            Panel_DynamicQAdj.setVisible(false);
            Panel_DynamicQThres.setVisible(false);
        }
        else if (SingulationAlgorithm.ToInt(evt.getItem().toString()) == SingulationAlgorithm.DYNAMICQ_ADJUST)
        {
            jTabbedPane1.setTitleAt(2, "DynamicQAdj");
            Panel_FixedQ.setVisible(false);
            Panel_DynamicQ.setVisible(false);
            Panel_DynamicQAdj.setVisible(true);
            Panel_DynamicQThres.setVisible(false);
        }
        else if (SingulationAlgorithm.ToInt(evt.getItem().toString()) == SingulationAlgorithm.DYNAMICQ_THRESH)
        {
            jTabbedPane1.setTitleAt(2, "DynamicQThres");
            Panel_FixedQ.setVisible(false);
            Panel_DynamicQ.setVisible(false);
            Panel_DynamicQAdj.setVisible(false);
            Panel_DynamicQThres.setVisible(true);
        }
        else
        {
            jTabbedPane1.setEnabledAt(2, false);
        }
    }//GEN-LAST:event_cbb_algorithmItemStateChanged

    private void ApplyAlgorithmTab()
    {
        // set fixed Q
        Settings.fixedQ.qValue = isNumber(tf_fixQValue.getText()) ? Integer.parseInt(tf_fixQValue.getText()) : Settings.fixedQ.qValue;
        Settings.fixedQ.retryCount = isNumber(tf_fixRetry.getText()) ? Integer.parseInt(tf_fixRetry.getText()) : Settings.fixedQ.retryCount;
        Settings.fixedQ.repeatUntilNoTags = chb_fixRepeat.isSelected() ? 1 : 0;
        Settings.fixedQ.toggleTarget = chb_fixToggle.isSelected() ? 1 : 0;

        // set dynamic Q
        Settings.dynamicQ.startQValue = isNumber(tf_dynQValue.getText()) ? Integer.parseInt(tf_dynQValue.getText()) : Settings.dynamicQ.startQValue;
        Settings.dynamicQ.minQValue = isNumber(tf_dynMinQ.getText()) ? Integer.parseInt(tf_dynMinQ.getText()) : Settings.dynamicQ.minQValue;
        Settings.dynamicQ.maxQValue = isNumber(tf_dynMaxQ.getText()) ? Integer.parseInt(tf_dynMaxQ.getText()) : Settings.dynamicQ.maxQValue;
        Settings.dynamicQ.maxQueryRepCount = isNumber(tf_dynMaxQueryRep.getText()) ? Integer.parseInt(tf_dynMaxQueryRep.getText()) : Settings.dynamicQ.maxQueryRepCount;
        Settings.dynamicQ.retryCount = isNumber(tf_dynRetry.getText()) ? Integer.parseInt(tf_dynRetry.getText()) : Settings.dynamicQ.retryCount;
        Settings.dynamicQ.toggleTarget = chb_dynToggle.isSelected() ? 1 : 0;

        // set dynamic Q Adj
        Settings.dynamicQAdj.startQValue = isNumber(tf_dynAdjQValue.getText()) ? Integer.parseInt(tf_dynAdjQValue.getText()) : Settings.dynamicQAdj.startQValue;
        Settings.dynamicQAdj.minQValue = isNumber(tf_dynAdjMinQ.getText()) ? Integer.parseInt(tf_dynAdjMinQ.getText()) : Settings.dynamicQAdj.minQValue;
        Settings.dynamicQAdj.maxQValue = isNumber(tf_dynAdjMaxQ.getText()) ? Integer.parseInt(tf_dynAdjMaxQ.getText()) : Settings.dynamicQAdj.maxQValue;
        Settings.dynamicQAdj.maxQueryRepCount = isNumber(tf_dynAdjMaxQueryRep.getText()) ? Integer.parseInt(tf_dynAdjMaxQueryRep.getText()) : Settings.dynamicQAdj.maxQueryRepCount;
        Settings.dynamicQAdj.retryCount = isNumber(tf_dynAdjRetry.getText()) ? Integer.parseInt(tf_dynAdjRetry.getText()) : Settings.dynamicQAdj.retryCount;
        Settings.dynamicQAdj.toggleTarget = chb_dynAdjToggle.isSelected() ? 1 : 0;

        // set dynamic Q Thres
        Settings.dynamicQThres.startQValue = isNumber(tf_dynThresQValue.getText()) ? Integer.parseInt(tf_dynThresQValue.getText()) : Settings.dynamicQThres.startQValue;
        Settings.dynamicQThres.minQValue = isNumber(tf_dynThresMinQ.getText()) ? Integer.parseInt(tf_dynThresMinQ.getText()) : Settings.dynamicQThres.minQValue;
        Settings.dynamicQThres.maxQValue = isNumber(tf_dynThresMaxQ.getText()) ? Integer.parseInt(tf_dynThresMaxQ.getText()) : Settings.dynamicQThres.maxQValue;
        Settings.dynamicQThres.thresholdMultiplier = isNumber(tf_dynThresMultiplier.getText()) ? Integer.parseInt(tf_dynThresMultiplier.getText()) : Settings.dynamicQThres.thresholdMultiplier;
        Settings.dynamicQThres.retryCount = isNumber(tf_dynThresRetry.getText()) ? Integer.parseInt(tf_dynThresRetry.getText()) : Settings.dynamicQThres.retryCount;
        Settings.dynamicQThres.toggleTarget = chb_dynThresToggle.isSelected() ? 1 : 0;
    }

    private boolean isNumber(String text) {
        try {
            Integer.parseInt(text);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    // </editor-fold>

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                SetupDialog dialog = new SetupDialog(new javax.swing.JFrame(), true);
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
    private javax.swing.JPanel Panel_DynamicQ;
    private javax.swing.JPanel Panel_DynamicQAdj;
    private javax.swing.JPanel Panel_DynamicQThres;
    private javax.swing.JPanel Panel_FixedQ;
    private javax.swing.JButton btn_apply;
    private javax.swing.JComboBox cbb_algorithm;
    private javax.swing.JComboBox cbb_country;
    private javax.swing.JComboBox cbb_frequency;
    private javax.swing.JComboBox cbb_profile;
    private javax.swing.JComboBox cbb_selected;
    private javax.swing.JComboBox cbb_session;
    private javax.swing.JComboBox cbb_target;
    private javax.swing.JCheckBox chb_LBT;
    private javax.swing.JCheckBox chb_custInvtryBlocking;
    private javax.swing.JCheckBox chb_custInvtryCont;
    private javax.swing.JCheckBox chb_dynAdjToggle;
    private javax.swing.JCheckBox chb_dynThresToggle;
    private javax.swing.JCheckBox chb_dynToggle;
    private javax.swing.JCheckBox chb_fixRepeat;
    private javax.swing.JCheckBox chb_fixToggle;
    private javax.swing.JCheckBox chb_fixedChannel;
    private javax.swing.JCheckBox chb_saveSettings;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel15;
    private javax.swing.JLabel jLabel16;
    private javax.swing.JLabel jLabel17;
    private javax.swing.JLabel jLabel18;
    private javax.swing.JLabel jLabel19;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel20;
    private javax.swing.JLabel jLabel21;
    private javax.swing.JLabel jLabel22;
    private javax.swing.JLabel jLabel23;
    private javax.swing.JLabel jLabel24;
    private javax.swing.JLabel jLabel25;
    private javax.swing.JLabel jLabel26;
    private javax.swing.JLabel jLabel27;
    private javax.swing.JLabel jLabel28;
    private javax.swing.JLabel jLabel29;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel30;
    private javax.swing.JLabel jLabel31;
    private javax.swing.JLabel jLabel32;
    private javax.swing.JLabel jLabel33;
    private javax.swing.JLabel jLabel34;
    private javax.swing.JLabel jLabel35;
    private javax.swing.JLabel jLabel36;
    private javax.swing.JLabel jLabel37;
    private javax.swing.JLabel jLabel38;
    private javax.swing.JLabel jLabel39;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel40;
    private javax.swing.JLabel jLabel41;
    private javax.swing.JLabel jLabel42;
    private javax.swing.JLabel jLabel43;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JLayeredPane jLayeredPane1;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JPanel jPanel3;
    private javax.swing.JTabbedPane jTabbedPane1;
    private javax.swing.JTextField tf_dynAdjMaxQ;
    private javax.swing.JTextField tf_dynAdjMaxQueryRep;
    private javax.swing.JTextField tf_dynAdjMinQ;
    private javax.swing.JTextField tf_dynAdjQValue;
    private javax.swing.JTextField tf_dynAdjRetry;
    private javax.swing.JTextField tf_dynMaxQ;
    private javax.swing.JTextField tf_dynMaxQueryRep;
    private javax.swing.JTextField tf_dynMinQ;
    private javax.swing.JTextField tf_dynQValue;
    private javax.swing.JTextField tf_dynRetry;
    private javax.swing.JTextField tf_dynThresMaxQ;
    private javax.swing.JTextField tf_dynThresMinQ;
    private javax.swing.JTextField tf_dynThresMultiplier;
    private javax.swing.JTextField tf_dynThresQValue;
    private javax.swing.JTextField tf_dynThresRetry;
    private javax.swing.JTextField tf_fixQValue;
    private javax.swing.JTextField tf_fixRetry;
    private javax.swing.JTextField tf_power;
    // End of variables declaration//GEN-END:variables

}
