using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class GameModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
