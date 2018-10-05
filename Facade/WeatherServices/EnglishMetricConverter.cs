namespace WeatherServices
{
    public class EnglishMetricConverter
    {
        public double FarenheitToCelcious(double degrees)
        {
            return ((degrees - 32)/9.0) *5.0;
        }
    }
}