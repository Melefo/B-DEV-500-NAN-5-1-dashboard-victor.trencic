using Doshboard.Backend.Entities;

namespace Doshboard.Backend.Services
{
    public enum UnitType
    {
        CELSIUS,
        FAHRENHEIT
    }

    public class WeatherData
    {
        public string Icon;
        public int Humidity;
        public double Temp;
        public string City;
        public WeatherData(string icon, int hum, double temp, string city)
        {
            Icon = icon;
            Humidity = hum;
            Temp = temp;
            City = city;
        }
    }                 

    public class WeatherService
    {
        private HttpClient _client = new HttpClient();
        private string _apiKey;
        private string _city;
        private UnitType _unit;
        public WeatherService(string apiKey, string city, UnitType unit)
        {
            _apiKey = apiKey;
            _city = city;
            _unit = unit;
        }
        public void Configure(string? newCity, UnitType? newUnit)
        {
            if (newCity != null)
                _city = newCity;
            if (newUnit != null)
                _unit = (UnitType)newUnit; 
        }

        public async Task<WeatherData?> Get()
        {
            WeatherJson? response = await _client.GetFromJsonAsync<WeatherJson>($"https://api.openweathermap.org/data/2.5/weather?q={_city}&appid={_apiKey}&unit={_unit}");
            if (response == null)
                return default;

            return new WeatherData($"https://openweathermap.org/img/wn/{response.Weather[0].Icon}@4x.png", response.Main.Humidity, response.Main.Temp, response.Name);
        }
    }
}
