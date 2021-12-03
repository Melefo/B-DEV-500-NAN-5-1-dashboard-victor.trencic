namespace Doshboard.Backend.Models.Widgets
{
    public class RealTimeCryptoData
    {
        public string Currency { get; set; }
        public string LogoUrl { get; set; }
        public float PriceChange { get;  set; }
        public float Price { get; set; }
        public int Rank { get; set; }

        public RealTimeCryptoData(string currency, string logoUrl, float price, float priceChange, int rank)
        {
            Currency = currency;
            LogoUrl = logoUrl;
            Price = price;
            PriceChange = priceChange;
            Rank = rank;
        }
    }
}
