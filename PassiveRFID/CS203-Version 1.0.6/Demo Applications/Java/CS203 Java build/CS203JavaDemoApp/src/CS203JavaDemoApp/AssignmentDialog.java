/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package CS203JavaDemoApp;

import java.awt.*;
import javax.swing.*;
import java.util.regex.*;
import CSLibrary.Message.*;

/**
 *
 * @author gene.yeung
 */
public class AssignmentDialog extends javax.swing.JDialog {

    // <editor-fold defaultstate="collapsed" desc="Init">
    /** Creates new form AssignmentDialog */
    public AssignmentDialog(java.awt.Frame parent, boolean modal) {
        super(parent, modal);
        initComponents();

        //Center the dialog
        Dimension size = getSize();
        setLocation((Main.screen.width - size.width)/2, (Main.screen.height - size.height)/2);

        tf_deviceName.setText(NetFinderFrame.selectedDeviceInfo.device_name);
        tf_timeout.setText(Short.toString(NetFinderFrame.selectedDeviceInfo.tcptimeout));
        String[] ip = Main.netfinder.GetIpName(NetFinderFrame.selectedDeviceInfo.ip).split("\\.", 4);
        tf_ip0.setText(ip[0]);
        tf_ip1.setText(ip[1]);
        tf_ip2.setText(ip[2]);
        tf_ip3.setText(ip[3]);
        cb_dhcp.setSelected(NetFinderFrame.selectedDeviceInfo.DHCP);

        NetFinderFrame.AssignOK = false;
    }
    // </editor-fold>

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        tf_deviceName = new javax.swing.JTextField();
        cb_dhcp = new javax.swing.JCheckBox();
        btn_assign = new javax.swing.JButton();
        tf_timeout = new javax.swing.JTextField();
        tf_ip0 = new javax.swing.JTextField();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        tf_ip1 = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        tf_ip2 = new javax.swing.JTextField();
        tf_ip3 = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Assignment");
        setIconImage(null);
        setIconImages(null);
        setModal(true);
        setResizable(false);

        jLabel1.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel1.setText("CS203 IP");

        jLabel2.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel2.setText("Device Name");

        jLabel3.setFont(new java.awt.Font("Arial", 0, 18));
        jLabel3.setText("Timeout");

        tf_deviceName.setFont(new java.awt.Font("Arial", 0, 14)); // NOI18N
        tf_deviceName.setInputVerifier(new InputLength31Verifier());

        cb_dhcp.setText("DHCP");

        btn_assign.setBackground(java.awt.Color.orange);
        btn_assign.setText("Assign");
        btn_assign.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_assignActionPerformed(evt);
            }
        });

        tf_timeout.setFont(new java.awt.Font("Arial", 0, 14)); // NOI18N
        tf_timeout.setInputVerifier(new NumberInputVerifier());

        tf_ip0.setFont(new java.awt.Font("Arial", 0, 18)); // NOI18N
        tf_ip0.setInputVerifier(new NumberInputVerifier());

        jLabel4.setFont(new java.awt.Font("Arial", 1, 18)); // NOI18N
        jLabel4.setText(".");

        jLabel5.setFont(new java.awt.Font("Arial", 1, 18)); // NOI18N
        jLabel5.setText(".");

        tf_ip1.setFont(new java.awt.Font("Arial", 0, 18)); // NOI18N
        tf_ip1.setInputVerifier(new NumberInputVerifier());

        jLabel6.setFont(new java.awt.Font("Arial", 1, 18)); // NOI18N
        jLabel6.setText(".");

        tf_ip2.setFont(new java.awt.Font("Arial", 0, 18)); // NOI18N
        tf_ip2.setInputVerifier(new NumberInputVerifier());

        tf_ip3.setFont(new java.awt.Font("Arial", 0, 18)); // NOI18N
        tf_ip3.setInputVerifier(new NumberInputVerifier());

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jLabel3, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 116, Short.MAX_VALUE)
                    .addComponent(jLabel1, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 116, Short.MAX_VALUE)
                    .addComponent(jLabel2, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 116, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(tf_deviceName, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 239, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                            .addComponent(tf_ip0, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 41, Short.MAX_VALUE)
                            .addComponent(tf_timeout, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 43, Short.MAX_VALUE))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 30, Short.MAX_VALUE)
                                .addComponent(cb_dhcp)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 46, Short.MAX_VALUE)
                                .addComponent(btn_assign))
                            .addGroup(layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jLabel4)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(tf_ip1, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jLabel5)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(tf_ip2, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jLabel6)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(tf_ip3, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE)))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel2)
                    .addComponent(tf_deviceName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(jLabel1)
                        .addComponent(tf_ip0, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jLabel4)
                    .addComponent(tf_ip1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel5)
                    .addComponent(tf_ip2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel6)
                    .addComponent(tf_ip3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(cb_dhcp)
                    .addComponent(btn_assign)
                    .addComponent(tf_timeout, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(18, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    // <editor-fold defaultstate="collapsed" desc="UI Handle">
    private void btn_assignActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_assignActionPerformed
        NetFinderFrame.selectedDeviceInfo.device_name = tf_deviceName.getText();
        NetFinderFrame.selectedDeviceInfo.tcptimeout = Short.parseShort(tf_timeout.getText());
        NetFinderFrame.selectedDeviceInfo.ip[0] = (byte)Short.parseShort(tf_ip0.getText());
        NetFinderFrame.selectedDeviceInfo.ip[1] = (byte)Short.parseShort(tf_ip1.getText());
        NetFinderFrame.selectedDeviceInfo.ip[2] = (byte)Short.parseShort(tf_ip2.getText());
        NetFinderFrame.selectedDeviceInfo.ip[3] = (byte)Short.parseShort(tf_ip3.getText());
        NetFinderFrame.selectedDeviceInfo.DHCP = cb_dhcp.isSelected();
        NetFinderFrame.AssignOK = true;
        dispose();
    }//GEN-LAST:event_btn_assignActionPerformed
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Input Verifier">
    class NumberInputVerifier extends InputVerifier {
        private Pattern p = Pattern.compile("[\\d]{1,3}");

        public boolean verify(JComponent input) {
            JTextField textField = (JTextField) input;
            Matcher m = p.matcher(textField.getText());
            if (m.matches() && Integer.parseInt(textField.getText()) <= 255) {
                return true;
            } else {
                MessageBox.ErrorShow("Input value must be in range of 0-255");
                return false;
            }
        }
    }

    class InputLength31Verifier extends InputVerifier {
        public boolean verify(JComponent input) {
            JTextField textField = (JTextField) input;
            int inputLength = textField.getText().length();
            if (inputLength > 0 && inputLength <= 31) {
                return true;
            } else {
                MessageBox.ErrorShow("Input length must be in range of 1-31");
                return false;
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
                AssignmentDialog dialog = new AssignmentDialog(new javax.swing.JFrame(), true);
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
    private javax.swing.JButton btn_assign;
    private javax.swing.JCheckBox cb_dhcp;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JTextField tf_deviceName;
    private javax.swing.JTextField tf_ip0;
    private javax.swing.JTextField tf_ip1;
    private javax.swing.JTextField tf_ip2;
    private javax.swing.JTextField tf_ip3;
    private javax.swing.JTextField tf_timeout;
    // End of variables declaration//GEN-END:variables

}
