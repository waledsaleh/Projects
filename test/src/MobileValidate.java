
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import org.apache.log4j.Logger;

public class MobileValidate {
 static Logger log = Logger.getLogger(MobileValidate.class);
 
    static Pattern pattern;
    static Matcher matcher;
    static String checkPattern = "^[0-9]{10}$";

    //This method returns false if string contains any non-numeric characters.
    public static boolean containsNonNumeric(String mobile) {

        log.info("Non-Numeric method called");
        int asciiCode;
        for (int j = 0; j < mobile.length(); ++j) {
            asciiCode = (int) mobile.charAt(j);
            //escaping all characters,except numbers between 0-9. 
            if ((asciiCode < 48 || asciiCode > 57)) {
                return false;
            }
        }
        return true;

    }
    //regex method checks but not tested yet.
    public static boolean isNumeric(String mobile) {
       
        
        /*A numeric value will have following format: 
         ^[-+]?: Starts with an optional "+" or "-" sign. 
         [0-9]*: May have one or more digits. 
         \\.? : May contain an optional "." (decimal point) character. 
         [0-9]+$ : ends with numeric digit. 
         */
        String expression = "^[-+]?[0-9]*\\.?[0-9]+$";
        
         pattern = Pattern.compile(expression);
         matcher = pattern.matcher(mobile);
      
        return matcher.matches();
    }
}
