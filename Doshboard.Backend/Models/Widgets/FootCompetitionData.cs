namespace Doshboard.Backend.Models.Widgets
{

    public class CompetitionData
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Name { get; set; }
        public int? CurrentMatchDay { get; set; }

        public CompetitionData(int id,  string area, string name, int? currentMatchDay)
        {
            Id = id;
            Area = area;
            Name = name;
            CurrentMatchDay = currentMatchDay;
        }
    }
}
