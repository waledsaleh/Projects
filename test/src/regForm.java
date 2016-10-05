
import org.apache.log4j.Logger;
import java.sql.*;

public class regForm extends javax.swing.JFrame {
  
    Connection connection = null;
    Statement stm = null;
    ResultSet resultSet = null;
    PreparedStatement prepareStatement = null;
    
    static  Logger log = Logger.getLogger(regForm.class);
  
    public regForm() {
        initComponents();
       if(dbConnect.getConnection() != null){
           
        connection = dbConnect.getConnection();
        
       }
        errorText.setVisible(false);

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        name = new javax.swing.JLabel();
        email = new javax.swing.JLabel();
        pw = new javax.swing.JLabel();
        mNumber = new javax.swing.JLabel();
        userName = new javax.swing.JTextField();
        userEmail = new javax.swing.JTextField();
        userMobile = new javax.swing.JTextField();
        userReg = new javax.swing.JButton();
        userPw = new javax.swing.JPasswordField();
        errorText = new javax.swing.JLabel();
        emailError = new javax.swing.JLabel();
        mobileError = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        name.setText("Name");

        email.setText("Email");

        pw.setText("Password");

        mNumber.setText("Mobile Number");

        userReg.setText("Register");
        userReg.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                userRegActionPerformed(evt);
            }
        });

        errorText.setForeground(new java.awt.Color(255, 0, 51));
        errorText.setText("Action is denied.There are empty boxes");

        emailError.setForeground(new java.awt.Color(255, 0, 51));

        mobileError.setForeground(new java.awt.Color(255, 51, 102));

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(userReg)
                        .addGap(18, 18, 18)
                        .addComponent(errorText, javax.swing.GroupLayout.PREFERRED_SIZE, 239, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap(176, Short.MAX_VALUE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(name)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 61, Short.MAX_VALUE)
                                .addComponent(userName, javax.swing.GroupLayout.PREFERRED_SIZE, 124, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addComponent(email)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(userEmail, javax.swing.GroupLayout.PREFERRED_SIZE, 124, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(mNumber)
                                    .addComponent(pw))
                                .addGap(18, 18, 18)
                                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addComponent(userPw)
                                    .addComponent(userMobile, javax.swing.GroupLayout.DEFAULT_SIZE, 124, Short.MAX_VALUE))))
                        .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(emailError, javax.swing.GroupLayout.PREFERRED_SIZE, 175, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(jPanel1Layout.createSequentialGroup()
                                .addGap(12, 12, 12)
                                .addComponent(mobileError, javax.swing.GroupLayout.PREFERRED_SIZE, 175, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(0, 0, Short.MAX_VALUE))))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGap(26, 26, 26)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(name)
                    .addComponent(userName, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(email)
                    .addComponent(userEmail, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(emailError))
                .addGap(21, 21, 21)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(pw)
                    .addComponent(userPw, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(mNumber)
                    .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(userMobile, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addComponent(mobileError)))
                .addGap(32, 32, 32)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(userReg)
                    .addComponent(errorText))
                .addContainerGap(155, Short.MAX_VALUE))
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void userRegActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_userRegActionPerformed

        try {
            userRegister();
           log.debug("register successful");
           
        } catch (SQLException ex) {
           
            log.error("sql exeption Error for register",ex);
        }

      
    }//GEN-LAST:event_userRegActionPerformed

    private boolean findEmail(String email) {

        log.info("find-email method called");
        log.debug("email parameter= user email address"); 
        String queryCheck = "SELECT * from users WHERE Email = ?";
        try {
            //Used PreparedStatement to avoid these sorts of issues and any risk of SQL injection
            prepareStatement = connection.prepareStatement(queryCheck);
            prepareStatement.setString(1, userEmail.getText());

            resultSet = prepareStatement.executeQuery();

            if (resultSet.next()) {
            log.debug("email not found in DataBase");
                return false;
            }
        } catch (Exception ex) {

          log.error("sql exeption Error for finding email",ex);
        }
        return true;
    }

    private void userRegister() throws SQLException {
        log.info("user register method called");
        
        if (userEmail.getText().equals("") || userMobile.getText().equals("")
                || userPw.getText().equals("") || userName.getText().equals("")) {

            errorText.setVisible(true);
            return;
        }

        if (!EmailValidate.validateEmail(userEmail.getText()) || !findEmail(userEmail.getText())) {
         
            emailError.setText("Invalid email or already taken");
            return;
        }
       if(!MobileValidate.containsNonNumeric(userMobile.getText())){
           
           mobileError.setText("Invalid mobile number");
           return;
       }
        try {

            stm = connection.createStatement();
            String sqlQuery = "INSERT INTO users(Name,Email,Password,MobileNumber)VALUES (?,?,?,?)";

            prepareStatement = connection.prepareStatement(sqlQuery);

            prepareStatement.setString(1, userName.getText());
            prepareStatement.setString(2, userEmail.getText());
            prepareStatement.setString(3, userPw.getText());
            prepareStatement.setString(4, userMobile.getText());

            prepareStatement.executeUpdate();
            
            log.debug("Register successful..");
            //close connection
            dbConnect.disconnect();

            new userScreen().setVisible(true);
            this.setVisible(false);

        } catch (Exception ex) {

          log.error("Error:User can not register.",ex);
            
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
                new regForm().setVisible(true);

            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel email;
    private javax.swing.JLabel emailError;
    private javax.swing.JLabel errorText;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JLabel mNumber;
    private javax.swing.JLabel mobileError;
    private javax.swing.JLabel name;
    private javax.swing.JLabel pw;
    private javax.swing.JTextField userEmail;
    private javax.swing.JTextField userMobile;
    private javax.swing.JTextField userName;
    private javax.swing.JPasswordField userPw;
    private javax.swing.JButton userReg;
    // End of variables declaration//GEN-END:variables
}
