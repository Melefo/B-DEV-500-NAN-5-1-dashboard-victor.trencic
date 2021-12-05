using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class FootModel
    {
        [Required]
        public string Id { get; set; }
        public string? Competition { get; set; }

        public FootModel(string id, string? competition)
        {
            Id = id;
            Competition = competition;
        }
    }
}