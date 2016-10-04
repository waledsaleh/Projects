
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import org.apache.log4j.Logger;

public class EmailValidate {

    static Logger log = Logger.getLogger(EmailValidate.class);

    static Pattern pattern;
    static Matcher matcher;
    static String checkPattern
            = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
            + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
//" The current implementation checks many valid email address, but not all"

    public static boolean validateEmail(String email) {
        log.info("email validation method called");

        pattern = Pattern.compile(checkPattern);
        matcher = pattern.matcher(email);
        return matcher.matches();

    }
}
