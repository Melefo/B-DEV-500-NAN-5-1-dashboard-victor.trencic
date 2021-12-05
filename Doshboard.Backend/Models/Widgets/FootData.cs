namespace Doshboard.Backend.Models.Widgets
{

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Scorer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Assist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Goal
    {
        public int Minute { get; set; }
        public object Type { get; set; }
        public Team Team { get; set; }
        public Scorer Scorer { get; set; }
        public Assist Assist { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string CoatchName  { get; set; }
        public Score Score { get; set; }
        public Goal Goal { get; set; }
    }

    public class FootData
    {
        public FootData()
        {

        }
        public List<Match> Matches { get; set; }
        public string Matchday { get; set; }
        public string CompetitionName { get; set; }
        public string Area { get; set; }
    }
}
