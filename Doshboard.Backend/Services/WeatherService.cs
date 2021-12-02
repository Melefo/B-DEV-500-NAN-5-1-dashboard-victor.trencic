using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widget;
using Doshboard.Backend.Interfaces;

namespace Doshboard.Backend.Services
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class WeatherJson
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public enum UnitType
    {
        Celsius,
        Fahrenheit
    }

    [ServiceName("Weather")]
    public class WeatherService : IService
    {
        private readonly HttpClient _client = new();
        private readonly MongoService _mongo;
        private readonly string _apiKey;
        public static Type[] Widgets => new[]
        {
            typeof(CityTempWidget)
        };

        public WeatherService(IConfiguration config, MongoService mongo)
        {
            _apiKey = config["Weather:ApiKey"];
            _mongo = mongo;
        }

        public void ConfigureCityTemp(string id, string? newCity, UnitType? newUnit)
        {
            var widget = _mongo.GetWidget<CityTempWidget>(id);
            if (widget == null || widget.Type != CityTempWidget.Name)
                return;

            if (newCity != null)
                widget.City = newCity;
            if (newUnit != null)
                widget.Unit = (UnitType)newUnit;

            _mongo.SaveWidget(widget);
        }

        public async Task<WeatherData?> GetCityTemp(string id)
        {
            var widget = _mongo.GetWidget<CityTempWidget>(id);
            if (widget == null || widget.Type != CityTempWidget.Name)
                return default;

            WeatherJson? response = await _client.GetFromJsonAsync<WeatherJson>($"https://api.openweathermap.org/data/2.5/weather?q={widget.City}&appid={_apiKey}&unit={widget.Unit}");

            if (response == null)
                return default;

            return new WeatherData($"https://openweathermap.org/img/wn/{response.Weather[0].Icon}@4x.png", response.Main.Humidity, response.Main.Temp, response.Name);
        }
    }
}
