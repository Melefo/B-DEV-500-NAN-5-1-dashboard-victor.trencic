using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display realtime cryptocurrency informations")]
    public class RealTimeCryptoWidget : Widget
    {
        public const string Name = "realtime_crypto";

        [WidgetParam]
        [BsonIgnore]
        public string Currency
        {
            get => (string)Params["currency"];
            set => Params["currency"] = value;
        }


        [WidgetParam]
        [BsonIgnore]
        public string Convert
        {
            get => (string)Params["convert"];
            set => Params["convert"] = value;
        }

        public RealTimeCryptoWidget() : base(Name, 1, 2)
        {
            Currency = "BTC";
            Convert = "EUR";
        }
    }
}
