
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

public class EmailJUnitTest {
    
    public EmailJUnitTest() {
    }
  
	public String[] validEmail() {
		return new String[]  { "test@yahoo.com",
			"test-100@yahoo.com", "test.100@yahoo.com",
			"test111@test.com", "test-100@test.net",
			"test.100@test.com.au", "test@1.com",
			"test@gmail.com.com", "test+100@gmail.com",
			"test-100@yahoo-test.com"  };
                
	}

	public String[] invalidEmail() {
		return new String[] {  "test", "test@.com.my",
			"test123@gmail.a", "test123@.com", "test123@.com.com",
			".test@test.com", "test()*@gmail.com", "test@%*.com",
			"test..2002@gmail.com", "test.@gmail.com",
			"test@test@gmail.com", "test@gmail.com.1a" }  ;
	}

	@Test
	public void validEmailTest() {

             String[] emailValid = validEmail();
		for (String temp : emailValid) {
			boolean valid = EmailValidate.validateEmail(temp);
			System.out.println("Email is valid : " + temp + " , " + valid);
			assertEquals(valid, true);
		}

	}

	@Test
	public void inValidEmailTest() {
            String[] emailinValid = invalidEmail();
            
		for (String temp : emailinValid) {
			boolean valid = EmailValidate.validateEmail(temp);
			System.out.println("Email is valid : " + temp + " , " + valid);
			assertEquals(valid, false);
		}
	}
   
   
     
     
}
