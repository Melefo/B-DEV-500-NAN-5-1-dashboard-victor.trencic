using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using Doshboard.Backend.Utilities;
using System.Text.Json.Serialization;

namespace Doshboard.Backend.Services
{
    public class Filters
    {
    }

    public class Area
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Competition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }

    public class Season
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("currentMatchday")]
        public int CurrentMatchday { get; set; }
    }

    public class Odds
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }

    public class FullTime
    {
        [JsonPropertyName("homeTeam")]
        public object HomeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public object AwayTeam { get; set; }
    }

    public class HalfTime
    {
        [JsonPropertyName("homeTeam")]
        public object HomeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public object AwayTeam { get; set; }
    }

    public class ExtraTime
    {
        [JsonPropertyName("homeTeam")]
        public object HomeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public object AwayTeam { get; set; }
    }

    public class Penalties
    {
        [JsonPropertyName("homeTeam")]
        public object HomeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public object AwayTeam { get; set; }
    }

    public class Score
    {
        [JsonPropertyName("winner")]
        public object Winner { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("fullTime")]
        public FullTime FullTime { get; set; }

        [JsonPropertyName("halfTime")]
        public HalfTime HalfTime { get; set; }

        [JsonPropertyName("extraTime")]
        public ExtraTime ExtraTime { get; set; }

        [JsonPropertyName("penalties")]
        public Penalties Penalties { get; set; }
    }

    public class HomeTeam
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class AwayTeam
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Referee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
    }

    public class Match
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("utcDate")]
        public DateTime UtcDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("matchday")]
        public int Matchday { get; set; }

        [JsonPropertyName("stage")]
        public string Stage { get; set; }

        [JsonPropertyName("group")]
        public object Group { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("odds")]
        public Odds Odds { get; set; }

        [JsonPropertyName("score")]
        public Score Score { get; set; }

        [JsonPropertyName("homeTeam")]
        public HomeTeam HomeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public AwayTeam AwayTeam { get; set; }

        [JsonPropertyName("referees")]
        public List<Referee> Referees { get; set; }
    }

    public class FootJson
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("filters")]
        public Filters Filters { get; set; }

        [JsonPropertyName("competition")]
        public Competition Competition { get; set; }

        [JsonPropertyName("matches")]
        public List<Match> Matches { get; set; }
    }


    // End of Foot
    // Start of Competitions

    public class CurrentSeason
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("currentMatchday")]
        public int? CurrentMatchday { get; set; }
    }

    public class CompetitionFull
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("currentSeason")]
        public CurrentSeason? CurrentSeason { get; set; }

        [JsonPropertyName("numberOfAvailableSeasons")]
        public int NumberOfAvailableSeasons { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }

    public class CompetitionsJson
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("filters")]
        public Filters Filters { get; set; }

        [JsonPropertyName("competitions")]
        public List<CompetitionFull> Competitions { get; set; }
    }



    // end of Competitions


    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    public class Squad
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

    public class FootTeamJson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("tla")]
        public string Tla { get; set; }

        [JsonPropertyName("crestUrl")]
        public string? CrestUrl { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("founded")]
        public int Founded { get; set; }

        [JsonPropertyName("clubColors")]
        public string ClubColors { get; set; }

        [JsonPropertyName("venue")]
        public string Venue { get; set; }

        [JsonPropertyName("squad")]
        public List<Squad> Squad { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }

    /// <summary>
    /// Foot Service
    /// </summary>
    [ServiceName("Foot")]
    public class FootService : IService
    {

        private readonly MongoService _mongo;
        private readonly string _apiKey;
        private readonly HttpClient _client = new();
        public static Type[] Widgets => new[]
        {
            typeof(FootWidget)
        };

        /// <summary>
        /// Foot Service Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="mongo"></param>
        public FootService(IConfiguration config, MongoService mongo)
        {
            _apiKey = config["Foot:ApiKey"];
            _mongo = mongo;
            _client.DefaultRequestHeaders.Add("X-Auth-Token", _apiKey);
        }

        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public async Task<List<CompetitionData>> GetCompetitions()
        {
            CompetitionsJson? response = await _client.GetAsync<CompetitionsJson>($"http://api.football-data.org/v2/competitions/");
            if (response == null)
                throw new ApiException("Failed to call API");

            List<CompetitionData> result = response.Competitions.Select(x => new CompetitionData(x.Id, x.Area.Name, x.Name, x.CurrentSeason?.CurrentMatchday)).ToList();
            return result;
        }

        /// <summary>
        /// Get competition by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public async Task<CompetitionData> GetCompetitionById(string id)
        {
            CompetitionFull? response = await _client.GetAsync<CompetitionFull>($"http://api.football-data.org/v2/competitions/{id}");
            if (response == null)
                throw new ApiException("Failed to call API");

            return new CompetitionData(response.Id, response.Area.Name, response.Name, response.CurrentSeason?.CurrentMatchday);
        }

        /// <summary>
        /// get all teams by competition throught widget config
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="MongoException"></exception>
        /// <exception cref="ApiException"></exception>
        public async Task<FootJson> GetTeams(string userId)
        {
            var widget = _mongo.GetWidget<FootWidget>(userId);
            if (widget == null)
                throw new MongoException("Widget not found");

            CompetitionData? compet = await GetCompetitionById(widget.CompetitionId);
            if (compet == null)
                throw new ApiException("Failed to call API");
            DateTime today = DateTime.UtcNow;
            int? matchDay = compet.CurrentMatchDay;
            FootJson? response;

            if (matchDay == null)
                response = await _client.GetAsync<FootJson>($"http://api.football-data.org/v2/competitions/{widget.CompetitionId}/matches?dateFrom={today:yyyy-MM-dd}&dateTo={today.AddDays(5):yyyy-MM-dd}");
            else
                response = await _client.GetAsync<FootJson>($"http://api.football-data.org/v2/competitions/{widget.CompetitionId}/matches?matchday={ matchDay }");
            if (response == null)
                throw new ApiException("Failed to call API");

            return response;
        }

        /// <summary>
        /// Get teamby id
        /// </summary>
        /// <param name="teamsId"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        public async Task<FootTeamJson> GetTeam(string teamsId)
        {
            FootTeamJson? response = await _client.GetAsync<FootTeamJson>($"http://api.football-data.org/v2/teams/{teamsId}");
            if (response == null)
                throw new ApiException("Failed to call API");

            return response;
        }

        /// <summary>
        /// Change widget configuration in db
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="competitionId"></param>
        /// <exception cref="MongoException"></exception>
        public void ConfigureFootCompetition(string userId, string? competitionId)
        {
            var widget = _mongo.GetWidget<FootWidget>(userId);
            if (widget == null)
                throw new MongoException("Widget not found");

            if (competitionId != null)
                widget.CompetitionId = competitionId;
            _mongo.SaveWidget(widget);
        }
    }
}
