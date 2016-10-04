

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

public class MobileJUnitTest {
    
    public MobileJUnitTest() {
    }
    
    public String[] validMobile() {
		return new String[]  { "01201245214","000012312345678","8128978978",
			"124567899","0123456789","789456123" ,"9876543210" };
                
	}

	public String[] invalidMobile() {
		return new String[] { "0a12012-45214-","+1-234-567-8901",
			"123-456-+789","-01-2f3456789-","78-945'-6123" ,"+98-.765/4321+0" }  ;
	}

	@Test
	public void validMobileTest() {

             String[] mobileValid = validMobile();
		for (String temp : mobileValid) {
			boolean valid = MobileValidate.containsNonNumeric(temp);
			System.out.println("Mobile is valid : " + temp + " , " + valid);
			assertEquals(valid, true);
		}

	}

	@Test
	public void inValidMobileTest() {
            String[] mobileInValid = invalidMobile();
            
		for (String temp : mobileInValid) {
			boolean valid = MobileValidate.containsNonNumeric(temp);
			System.out.println("Mobile is invalid : " + temp + " , " + valid);
			assertEquals(valid, false);
		}
	}

    
}
