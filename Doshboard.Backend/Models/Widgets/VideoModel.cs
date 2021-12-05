using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class VideoModel
    {
        [Required]
        public string Id { get; set; }
        public string? VideoId { get; set; }
    }
}
