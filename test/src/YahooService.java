
import com.github.fedy2.weather.YahooWeatherService;
import com.github.fedy2.weather.data.unit.DegreeUnit;
import com.github.fedy2.weather.data.Channel;
import org.apache.log4j.Logger;

public class YahooService {
    
     static YahooWeatherService service;
     static Channel channel;
     static String definedNote="";
     
     static Logger log = Logger.getLogger(YahooService.class);
      
     public YahooService(){
         
    service = null;
    channel=null;
    
     }
     
    public static  void makeService(){
        
        log.info("calling yahoo weather service method");
         try {

            service = new YahooWeatherService();
            channel = service.getForecast(adminScreen.WEATHER_ID, DegreeUnit.CELSIUS);
          
        } catch (Exception ex) {

            log.error("Yahoo Weather Service Error",ex);
            
        }
        
    }
    public static Channel getChannel(){
        log.info("get channel method called");
        return channel;
    }
    public static String makelocation(){
         log.info("get country location method called");
        return channel.getLocation().getCountry();
    }
    public static int makeTemperature(){
         log.info("get country temperature method called");
        return channel.getItem().getCondition().getTemp();
        
    }
    public static String conditionState(){
        
         log.info("get weather condition state between specified ranges");
         
         int Value = makeTemperature();
         if (Value > 1 && Value <= 10) {
               definedNote = channel.getItem().getCondition().getText();
            } else if (Value > 10 && Value <= 15) {
              definedNote = channel.getItem().getCondition().getText();
            } else if (Value > 15 && Value <= 20) {
           definedNote = channel.getItem().getCondition().getText();
            } else {
                definedNote = channel.getItem().getCondition().getText();
            }
         
        return definedNote;
    }
    public static float windSpeed(){
        log.info("wind speed method called");
        return channel.getWind().getSpeed();
    }
    public static String getCity(){
        log.info("get current city method called");
        return channel.getLocation().getCity();
    }
}
