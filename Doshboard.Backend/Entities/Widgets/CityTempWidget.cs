using Doshboard.Backend.Attributes;
using Doshboard.Backend.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display temperature for a city")]
    public class CityTempWidget : Widget
    {
        public const string Name = "city_temperature";

        public CityTempWidget() : base(Name, 2, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string City
        {
            get => Params.ContainsKey("city") ? (string)Params["city"] : "paris";
            set => Params["city"] = value;
        }

        [WidgetParam]
        [BsonIgnore]
        public UnitType Unit
        {
            get => Params.ContainsKey("unit") ? (UnitType)Params["unit"] : UnitType.Celsius;
            set => Params["unit"] = value;
        }
    }
}
