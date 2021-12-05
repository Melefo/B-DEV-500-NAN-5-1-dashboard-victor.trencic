namespace Doshboard.Backend.Models.Widgets
{
    public class GameData
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Price { get; set; }
        public float Review { get; set; }
        public int Players { get; set; }

        public GameData(string name, string logo, string price, float review, int players)
        {
            Name = name;
            Logo = logo;
            Price = price;
            Review = review;
            Players = players;
        }
    }
}
