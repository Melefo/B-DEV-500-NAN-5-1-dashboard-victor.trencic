using Doshboard.Backend.Attributes;
using Doshboard.Backend.Services;
using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;

namespace Doshboard.Backend.Entities.Widget
{
    [WidgetInfo("City temperature", "Display temperature for a city")]
    public class CityTempWidget : AWidget
    {
        public CityTempWidget() : base(WidgetType.CityTemp, 2, 2)
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
