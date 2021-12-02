using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display realtime cryptocurrency informations")]
    public class RealTimeCryptoWidget : Widget
    {
        public const string Name = "realtime_crypto";

        public RealTimeCryptoWidget() : base(Name, 1, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string Currency
        {
            get => Params.ContainsKey("currency") ? (string)Params["currency"] : "BTC";
            set => Params["currency"] = value;
        }


        [WidgetParam]
        [BsonIgnore]
        public string Convert
        {
            get => Params.ContainsKey("convert") ? (string)Params["convert"] : "EUR";
            set => Params["convert"] = value;
        }
    }
}
