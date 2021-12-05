using Doshboard.Backend.Attributes;
using Doshboard.Backend.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display temperature for a city")]
    public class CityTempWidget : Widget
    {
        public const string Name = "city_temperature";

        [WidgetParam]
        [BsonIgnore]
        public string City
        {
            get => (string)Params["city"];
            set => Params["city"] = value;
        }

        [WidgetParam]
        [BsonIgnore]
        public UnitType Unit
        {
            get => (UnitType)Params["unit"];
            set => Params["unit"] = value;
        }

        public CityTempWidget() : base(Name, 2, 2)
        {
            City = "Paris";
            Unit = UnitType.Metric;
        }
    }
}
