import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;
import org.apache.log4j.Logger;
public class dbConnect {
     // init database constants
    private static final String DATABASE_DRIVER = "com.mysql.jdbc.Driver";
    private static final String DATABASE_URL = "jdbc:mysql://localhost:3306/company";
    private static final String USERNAME = "root";
    private static final String PASSWORD = "root";
    private static final String MAX_POOL = "250";
    static Logger log = Logger.getLogger(dbConnect.class);
    // init connection object
    private static Connection connection;
    // init properties object
    private static Properties properties;
    
     // create properties
    private static Properties getProperties() {
        if (properties == null) {
            
            log.info("DataBase initialization Properties");
            
            properties = new Properties();
            properties.setProperty("user", USERNAME);
            properties.setProperty("password", PASSWORD);
            properties.setProperty("MaxPooledStatements", MAX_POOL);
        }
        return properties;
    }

    // connect database
    public static Connection connect() {
        if (connection == null) {
            try {
                  log.debug("Loading driver...");
                  
                  Class.forName(DATABASE_DRIVER);
                  connection = DriverManager.getConnection(DATABASE_URL, getProperties());
                  
                  log.info("Database connection established");
                 
            } catch (ClassNotFoundException | SQLException e) {
                log.error("Cannot connect to database server",e);
            }
        }
        return connection;
    }
 public static Connection getConnection(){
     log.info("Get Current Db Connection");
     return connection;
 }
    // disconnect database
    public  static void disconnect() {
        if (connection != null) {
            try {
                log.info("DisConnect DataBase function");
                connection.close();
                connection = null;
            } catch (SQLException e) {
                log.error("DisConnection error",e);
                e.printStackTrace();
            }
        }
    }
    
    
}
