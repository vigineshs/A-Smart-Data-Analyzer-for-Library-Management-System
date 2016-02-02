package CS203JavaDemoApp;

import java.awt.*;
import CSLibrary.*;
import CSLibrary.Net.*;

/**
 *
 */
public class Main {

    // <editor-fold defaultstate="collapsed" desc="Variable">
    public static String demeAppVer = "1.0.4";
    public static HighLevelInterface ReaderXP;
    public static NetFinder netfinder;
    public static String applicationSettings = "";
    public static Dimension screen = Toolkit.getDefaultToolkit().getScreenSize();
    public static String ipAddress;
    public static String macAddress;
    // </editor-fold>

    // <editor-fold defaultstate="collapsed" desc="Init">
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        new NetFinderFrame().setVisible(true);
    }
    // </editor-fold>
}
