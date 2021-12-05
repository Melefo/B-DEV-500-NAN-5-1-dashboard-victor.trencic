namespace Doshboard.Backend.Models.Widgets
{
    public class CityTempData
    {
        public string Icon { get; set; }
        public int Humidity { get; set; }
        public double Temp { get; set; }
        public string City { get; set; }

        public CityTempData(string icon, int hum, double temp, string city)
        {
            Icon = icon;
            Humidity = hum;
            Temp = temp;
            City = city;
        }
    }

}