using WeatherServices;

namespace facade2.TemperatureFacade
{
    public class TemperatureLookupFacade
    {
        readonly WeatherService weatherService;
        readonly GeoLookupService geoLookupService;
        readonly EnglishMetricConverter converter;

        public TemperatureLookupFacade()
            :this(new WeatherService(), new GeoLookupService(), new EnglishMetricConverter())
        {}

        public TemperatureLookupFacade(WeatherService weatherService, GeoLookupService geoLookupService, EnglishMetricConverter englishMetricConverter)
        {
            this.weatherService = weatherService;
            this.geoLookupService = geoLookupService;
            this.converter = englishMetricConverter;
        }

        public LocalTemperature GetTemperature(string zipCode)
        {
            var coords = geoLookupService.GetCoordinatesForZipCode(zipCode);
            var city = geoLookupService.GetCityForZipCode(zipCode);
            var state = geoLookupService.GetStateForZipCode(zipCode);
            
            var farenheit = weatherService.GetTempFarenheit(coords.Latitude, coords.Longitude);
            var celcius = converter.FarenheitToCelcious(farenheit);

            var localTemperature = new LocalTemperature()
                              {
                                  Farenheit = farenheit,
                                  Celcius = celcius,
                                  City = city,
                                  State = state
                              };

            return localTemperature;
        }
    }
}