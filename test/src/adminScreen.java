
import com.github.fedy2.weather.YahooWeatherService;
import com.github.fedy2.weather.data.Channel;
import com.github.fedy2.weather.data.unit.DegreeUnit;
import java.sql.*;

import java.util.*;
import org.apache.log4j.Logger;

public class adminScreen extends javax.swing.JFrame {

    Connection connection = null;
    Statement stm = null;
    ResultSet resultSet = null;
    PreparedStatement prepareStatement = null;
    Set<String> uniqueOldNotes;
    static String currForecast = "", getNote = "";
    int Value;

    static Logger log = Logger.getLogger(adminScreen.class);
    static final String WEATHER_ID = "2502265";

    public adminScreen() {
        initComponents();
        uniqueOldNotes = new HashSet<String>();

        if (dbConnect.getConnection() != null) {
            log.debug("Get DataBase Connection");
            connection = dbConnect.getConnection();
        }

        YahooService.makeService();
        countryText.setText(YahooService.makelocation());
        Value = YahooService.makeTemperature();
        tempValue.setText(Value + " C");

        //Get All forecast conditions.
        currForecast = YahooService.conditionState();

        setNote.setText("Country is " + currForecast);

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        getNotes = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        logout = new javax.swing.JButton();
        setNotes = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        setNote = new javax.swing.JTextArea();
        jScrollPane2 = new javax.swing.JScrollPane();
        oldNote = new javax.swing.JTextArea();
        weatherID = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        countryText = new javax.swing.JLabel();
        temperatureValue = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        tempValue = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        getNotes.setText("Get Notes");
        getNotes.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                getNotesActionPerformed(evt);
            }
        });

        jLabel1.setText("Set Note");

        logout.setText("Logout");
        logout.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                logoutActionPerformed(evt);
            }
        });

        setNotes.setText("Set Note");
        setNotes.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                setNotesActionPerformed(evt);
            }
        });

        jLabel2.setText("Old Notes");

        setNote.setColumns(20);
        setNote.setRows(5);
        jScrollPane1.setViewportView(setNote);

        oldNote.setColumns(20);
        oldNote.setRows(5);
        oldNote.setEnabled(false);
        jScrollPane2.setViewportView(oldNote);

        weatherID.setText("2502265");
        weatherID.setEnabled(false);

        jLabel3.setText("Weather ID");

        countryText.setText("jLabel4");

        temperatureValue.setText("Temperature:");

        jLabel4.setText("Country:");

        tempValue.setText("jLabel5");

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(setNotes)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(getNotes)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(logout)
                .addContainerGap(294, Short.MAX_VALUE))
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel1)
                    .addComponent(jLabel2))
                .addGap(23, 23, 23)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 160, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 160, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel3)
                            .addComponent(temperatureValue)
                            .addComponent(jLabel4))
                        .addGap(18, 18, 18)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(weatherID, javax.swing.GroupLayout.PREFERRED_SIZE, 113, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(countryText)
                            .addComponent(tempValue))
                        .addGap(65, 65, 65))))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(46, 46, 46)
                                .addComponent(jLabel1))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addContainerGap()
                                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(52, 52, 52)
                                .addComponent(jLabel2))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(19, 19, 19)
                                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 82, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(44, 44, 44)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(setNotes)
                            .addComponent(getNotes)
                            .addComponent(logout)))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(19, 19, 19)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(weatherID, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jLabel3))
                        .addGap(18, 18, 18)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(countryText)
                            .addComponent(jLabel4))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(temperatureValue)
                            .addComponent(tempValue))))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void setNotesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_setNotesActionPerformed

        try {
            setNoteAdmin();
        } catch (SQLException  ex) {
         log.error("SQL excepion :set note button error.",ex);
            ex.printStackTrace();
        }
    }//GEN-LAST:event_setNotesActionPerformed

    private void getNotesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_getNotesActionPerformed

        try {
            oldNotes();
            log.debug("get old-notes and add them in set");
            for (String word : uniqueOldNotes) {
                oldNote.append(word + "\n");
            }

        } catch (SQLException  ex) {
             log.error("SQL excepion :Admin can not get Note.",ex);
           
        }

    }//GEN-LAST:event_getNotesActionPerformed

    private void logoutActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_logoutActionPerformed

        log.info("switching to login screen");
        this.setVisible(false);
        new logForm().setVisible(true);

    }//GEN-LAST:event_logoutActionPerformed

    private void setNoteAdmin() throws SQLException {

        log.info("calling note admin method");
        if (!setNote.getText().equals("")) {
            getNote = setNote.getText();
        }

        try {
            stm = connection.createStatement();
            String sqlQuery = "INSERT INTO weather(oldNote)VALUES(?)";

            prepareStatement = connection.prepareStatement(sqlQuery);
            prepareStatement.setString(1, getNote);

            prepareStatement.executeUpdate();

            log.debug("Insert note successful..");

        } catch (SQLException  ex) {

            log.error("SQL excepion :Admin can not insert Note.",ex);

        } finally {

            if (prepareStatement != null) {
                prepareStatement.close();
            }

            if (resultSet != null) {
                resultSet.close();
            }
            if (stm != null) {
                stm.close();
            }
        }

    }

    public static String getNoteAdmin() {

        return getNote;
    }

    private void oldNotes() throws SQLException {

        log.info("old-note method called");
        try {
            stm = connection.createStatement();
            String sqlQuery = "SELECT oldNote FROM weather";

            prepareStatement = connection.prepareStatement(sqlQuery);
            ResultSet rs = prepareStatement.executeQuery();

            while (rs.next()) {
                //adding unique notes.
                uniqueOldNotes.add(rs.getString("oldNote"));
            }

        } catch (SQLException  ex) {
            log.error("SQL excepion :Admin can not get OldNote.",ex);

        } finally {

            if (prepareStatement != null) {
                prepareStatement.close();
            }

            if (resultSet != null) {
                resultSet.close();
            }
            if (stm != null) {
                stm.close();
            }
        }

    }

    public static void main(String args[]) {

        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new adminScreen().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel countryText;
    private javax.swing.JButton getNotes;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JButton logout;
    private javax.swing.JTextArea oldNote;
    private javax.swing.JTextArea setNote;
    private javax.swing.JButton setNotes;
    private javax.swing.JLabel tempValue;
    private javax.swing.JLabel temperatureValue;
    private javax.swing.JTextField weatherID;
    // End of variables declaration//GEN-END:variables
}
