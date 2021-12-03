using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Doshboard.Backend.Services
{
    public class Sub
    {
        [JsonPropertyName("packageid")]
        public int Packageid { get; set; }

        [JsonPropertyName("percent_savings_text")]
        public string PercentSavingsText { get; set; }

        [JsonPropertyName("percent_savings")]
        public int PercentSavings { get; set; }

        [JsonPropertyName("option_text")]
        public string OptionText { get; set; }

        [JsonPropertyName("option_description")]
        public string OptionDescription { get; set; }

        [JsonPropertyName("can_get_free_license")]
        public string CanGetFreeLicense { get; set; }

        [JsonPropertyName("is_free_license")]
        public bool IsFreeLicense { get; set; }

        [JsonPropertyName("price_in_cents_with_discount")]
        public int PriceInCentsWithDiscount { get; set; }
    }

    public class PackageGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("selection_text")]
        public string SelectionText { get; set; }

        [JsonPropertyName("save_text")]
        public string SaveText { get; set; }

        [JsonPropertyName("display_type")]
        public int DisplayType { get; set; }

        [JsonPropertyName("is_recurring_subscription")]
        public string IsRecurringSubscription { get; set; }

        [JsonPropertyName("subs")]
        public List<Sub> Subs { get; set; }
    }

    public class Platforms
    {
        [JsonPropertyName("windows")]
        public bool Windows { get; set; }

        [JsonPropertyName("mac")]
        public bool Mac { get; set; }

        [JsonPropertyName("linux")]
        public bool Linux { get; set; }
    }

    public class Metacritic
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Screenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("path_thumbnail")]
        public string PathThumbnail { get; set; }

        [JsonPropertyName("path_full")]
        public string PathFull { get; set; }
    }

    public class Webm
    {
        [JsonPropertyName("480")]
        public string _480 { get; set; }

        [JsonPropertyName("max")]
        public string Max { get; set; }
    }

    public class Mp4
    {
        [JsonPropertyName("480")]
        public string _480 { get; set; }

        [JsonPropertyName("max")]
        public string Max { get; set; }
    }

    public class Movy
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("webm")]
        public Webm Webm { get; set; }

        [JsonPropertyName("mp4")]
        public Mp4 Mp4 { get; set; }

        [JsonPropertyName("highlight")]
        public bool Highlight { get; set; }
    }

    public class Recommendations
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class Highlighted
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    public class Achievements
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("highlighted")]
        public List<Highlighted> Highlighted { get; set; }
    }

    public class ReleaseDate
    {
        [JsonPropertyName("coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

    public class SupportInfo
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class ContentDescriptors
    {
        [JsonPropertyName("ids")]
        public List<int> Ids { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }

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

        [JsonPropertyName("package_groups")]
        public List<PackageGroup> PackageGroups { get; set; }

        [JsonPropertyName("platforms")]
        public Platforms Platforms { get; set; }

        [JsonPropertyName("metacritic")]
        public Metacritic Metacritic { get; set; }

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("screenshots")]
        public List<Screenshot> Screenshots { get; set; }

        [JsonPropertyName("movies")]
        public List<Movy> Movies { get; set; }

        [JsonPropertyName("recommendations")]
        public Recommendations Recommendations { get; set; }

        [JsonPropertyName("achievements")]
        public Achievements Achievements { get; set; }

        [JsonPropertyName("release_date")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonPropertyName("support_info")]
        public SupportInfo SupportInfo { get; set; }

        [JsonPropertyName("background")]
        public string Background { get; set; }

        [JsonPropertyName("content_descriptors")]
        public ContentDescriptors ContentDescriptors { get; set; }
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

    public class Author
    {
        public string Steamid { get; set; }

        [JsonPropertyName("num_games_owned")]
        public int NumGamesOwned { get; set; }

        [JsonPropertyName("num_reviews")]
        public int NumReviews { get; set; }

        [JsonPropertyName("playtime_forever")]
        public int PlaytimeForever { get; set; }

        [JsonPropertyName("playtime_last_two_weeks")]
        public int PlaytimeLastTwoWeeks { get; set; }

        [JsonPropertyName("playtime_at_review")]
        public int PlaytimeAtReview { get; set; }

        [JsonPropertyName("last_played")]
        public int LastPlayed { get; set; }
    }

    public class Review
    {
        public string Recommendationid { get; set; }

        public Author Author { get; set; }

        public string Language { get; set; }

        [JsonPropertyName("review")]
        public string Content { get; set; }

        [JsonPropertyName("timestamp_created")]
        public int TimestampCreated { get; set; }

        [JsonPropertyName("timestamp_updated")]
        public int TimestampUpdated { get; set; }

        [JsonPropertyName("voted_up")]
        public bool VotedUp { get; set; }

        [JsonPropertyName("votes_up")]
        public int VotesUp { get; set; }

        [JsonPropertyName("votes_funny")]
        public int VotesFunny { get; set; }

        [JsonPropertyName("weighted_vote_score")]
        public string WeightedVoteScore { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("steam_purchase")]
        public bool SteamPurchase { get; set; }

        [JsonPropertyName("received_for_free")]
        public bool ReceivedForFree { get; set; }

        [JsonPropertyName("written_during_early_access")]
        public bool WrittenDuringEarlyAccess { get; set; }
    }

    public class ReviewJson
    {
        public int Success { get; set; }

        [JsonPropertyName("query_summary")]
        public QuerySummary QuerySummary { get; set; }

        public List<Review> Reviews { get; set; }

        public string Cursor { get; set; }
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

        public async Task<GameData?> GetGameData(string id)
        {
            var widget = _mongo.GetWidget<GameWidget>(id);
            if (widget == null || widget.Type != GameWidget.Name)
                return default;

            _games ??= await ClientAPI.GetAsync<GameList>($"https://api.steampowered.com/ISteamApps/GetAppList/v2/?key={_apiKey}");
            if (_games == null)
                return default;

            var game = _games.Applist.Apps.FirstOrDefault(x => string.Equals(x.Name, widget.GameName, StringComparison.OrdinalIgnoreCase));
            if (game == null)
                return default;

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
                return default;

            var name = meta.Response.Apps[0].FriendlyName ?? meta.Response.Apps[0].Name;
            var icon = $"https://steamcdn-a.akamaihd.net/steamcommunity/public/images/apps/{game.Appid}/{meta.Response.Apps[0].Icon}.jpg";
            var price = priceInfo.Data.PriceOverview?.FinalFormatted ?? "Free";
            var review = reviewInfo.QuerySummary.TotalReviews > 0 ? (float)reviewInfo.QuerySummary.TotalPositive / reviewInfo.QuerySummary.TotalReviews * 100 : 0;
            var players = playersInfo?.Response?.PlayerCount ?? 0;

            return new GameData(name, icon, price, review, players);
        }

        public async Task ConfigureGame(string id, string name)
        {
            var widget = _mongo.GetWidget<GameWidget>(id);
            if (widget == null || widget.Type != GameWidget.Name)
                return;

            _games ??= await ClientAPI.GetAsync<GameList>($"https://api.steampowered.com/ISteamApps/GetAppList/v2/?key={_apiKey}");
            if (_games == null)
                return;
            var game = _games.Applist.Apps.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (game == null)
                return;

            widget.GameName = name;
            _mongo.SaveWidget(widget);
        }
    }
}
