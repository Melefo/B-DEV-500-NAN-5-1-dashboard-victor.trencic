using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Doshboard.Backend.Services
{
    public class PriceOverview
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("initial")]
        public int Initial { get; set; }

        [JsonPropertyName("final")]
        public int Final { get; set; }

        [JsonPropertyName("discount_percent")]
        public int DiscountPercent { get; set; }

        [JsonPropertyName("initial_formatted")]
        public string InitialFormatted { get; set; }

        [JsonPropertyName("final_formatted")]
        public string FinalFormatted { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("steam_appid")]
        public int SteamAppid { get; set; }

        [JsonPropertyName("required_age")]
        public int RequiredAge { get; set; }

        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }

        [JsonPropertyName("controller_support")]
        public string ControllerSupport { get; set; }

        [JsonPropertyName("dlc")]
        public List<int> Dlc { get; set; }

        [JsonPropertyName("detailed_description")]
        public string DetailedDescription { get; set; }

        [JsonPropertyName("about_the_game")]
        public string AboutTheGame { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("supported_languages")]
        public string SupportedLanguages { get; set; }

        [JsonPropertyName("header_image")]
        public string HeaderImage { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("developers")]
        public List<string> Developers { get; set; }

        [JsonPropertyName("publishers")]
        public List<string> Publishers { get; set; }

        [JsonPropertyName("packages")]
        public List<int> Packages { get; set; }

        [JsonPropertyName("background")]
        public string Background { get; set; }

        [JsonPropertyName("price_overview")]
        public PriceOverview PriceOverview { get; set; }
    }

    public class PriceJson
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class QuerySummary
    {
        [JsonPropertyName("num_reviews")]
        public int NumReviews { get; set; }

        [JsonPropertyName("review_score")]
        public int ReviewScore { get; set; }

        [JsonPropertyName("review_score_desc")]
        public string ReviewScoreDesc { get; set; }

        [JsonPropertyName("total_positive")]
        public int TotalPositive { get; set; }

        [JsonPropertyName("total_negative")]
        public int TotalNegative { get; set; }

        [JsonPropertyName("total_reviews")]
        public int TotalReviews { get; set; }
    }

    public class ReviewJson
    {
        public int Success { get; set; }

        [JsonPropertyName("query_summary")]
        public QuerySummary QuerySummary { get; set; }

    }

    public class MetadataApp
    {
        public int Appid { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Logo { get; set; }

        [JsonPropertyName("logo_small")]
        public string LogoSmall { get; set; }

        [JsonPropertyName("community_visible_stats")]
        public bool CommunityVisibleStats { get; set; }

        [JsonPropertyName("friendly_name")]
        public string FriendlyName { get; set; }

        public string Propagation { get; set; }

        [JsonPropertyName("has_adult_content")]
        public bool HasAdultContent { get; set; }

        [JsonPropertyName("is_visible_in_steam_china")]
        public bool IsVisibleInSteamChina { get; set; }

        [JsonPropertyName("app_type")]
        public int AppType { get; set; }
    }

    public class MetadataResponse
    {
        public List<MetadataApp> Apps { get; set; }
    }

    public class MetadataJson
    {
        public MetadataResponse Response { get; set; }
    }

    public class App
    {
        public int Appid { get; set; }
        public string Name { get; set; }
    }

    public class Applist
    {
        public List<App> Apps { get; set; }
    }

    public class GameList
    {
        public Applist Applist { get; set; }
    }

    public class Response
    {
        [JsonPropertyName("player_count")]
        public int PlayerCount { get; set; }

        public int Result { get; set; }
    }

    public class PlayerJson
    {
        public Response Response { get; set; }
    }


    [ServiceName("Steam")]
    public class SteamService : IService
    {
        private readonly MongoService _mongo;
        private readonly string _apiKey;
        private GameList? _games = null;


        public static Type[] Widgets => new[]
        {
            typeof(GameWidget)
        };

        public SteamService(IConfiguration config, MongoService mongo)
        {
            _apiKey = config["Steam:ApiKey"];
            _mongo = mongo;
        }

        private async Task<MetadataJson?> GetMetadataJson(int id)
            => await ClientAPI.GetAsync<MetadataJson>($"https://api.steampowered.com/ICommunityService/GetApps/v1/?key={_apiKey}&appids[0]={id}");

        private async Task<PlayerJson?> GetPlayerJson(int id)
            => await ClientAPI.GetAsync<PlayerJson>($"https://api.steampowered.com/ISteamUserStats/GetNumberOfCurrentPlayers/v1/?key={_apiKey}&appid={id}");

        private async Task<ReviewJson?> GetReviewJson(int id)
            => await ClientAPI.GetAsync<ReviewJson>($"https://store.steampowered.com/appreviews/{id}?json=1&language=all");

        private async Task<PriceJson?> GetPriceJson(int id)
        {
            var priceJson = await ClientAPI.GetAsync<JsonElement>($"https://store.steampowered.com/api/appdetails?appids={id}");
            if (priceJson.Equals(default))
                return null;
            return priceJson.GetProperty(id.ToString()).Deserialize<PriceJson>();
        }

        public async Task<GameData> GetGameData(string id)
        {
            var widget = _mongo.GetWidget<GameWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            _games ??= await ClientAPI.GetAsync<GameList>($"https://api.steampowered.com/ISteamApps/GetAppList/v2/?key={_apiKey}");
            if (_games == null)
                throw new ApiException("Failed to call API");

            var game = _games.Applist.Apps.FirstOrDefault(x => string.Equals(x.Name, widget.GameName, StringComparison.OrdinalIgnoreCase));
            if (game == null)
                throw new WidgetException("No game with this name found");

            var metaTask = GetMetadataJson(game.Appid);
            var playersTask = GetPlayerJson(game.Appid);
            var reviewTask = GetReviewJson(game.Appid);
            var priceTask = GetPriceJson(game.Appid);

            await Task.WhenAll(metaTask, playersTask, reviewTask, priceTask);

            var meta = await metaTask;
            var playersInfo = await playersTask;
            var reviewInfo = await reviewTask;
            var priceInfo = await priceTask;
            if (meta == null || reviewInfo == null || priceInfo == null)
                throw new ApiException("Failed to call API");

            var name = meta.Response.Apps[0].FriendlyName ?? meta.Response.Apps[0].Name;
            var icon = $"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/apps/{game.Appid}/{meta.Response.Apps[0].Icon}.jpg";
            var price = priceInfo.Data.PriceOverview?.FinalFormatted ?? "Free";
            var review = reviewInfo.QuerySummary.TotalReviews > 0 ? (float)reviewInfo.QuerySummary.TotalPositive / reviewInfo.QuerySummary.TotalReviews * 100 : 0;
            var players = playersInfo?.Response?.PlayerCount ?? 0;

            return new GameData(name, icon, price, review, players);
        }

        public async Task ConfigureGame(string id, string? name)
        {
            var widget = _mongo.GetWidget<GameWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            _games ??= await ClientAPI.GetAsync<GameList>($"https://api.steampowered.com/ISteamApps/GetAppList/v2/?key={_apiKey}");
            if (_games == null)
                throw new ApiException("Failed to call API");

            if (name == null)
                return;
            var game = _games.Applist.Apps.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (game == null)
                throw new WidgetException("No game with this name found");

            widget.GameName = name;
            _mongo.SaveWidget(widget);
        }
    }
}
