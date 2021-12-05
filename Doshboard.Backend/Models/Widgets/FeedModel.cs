using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class FeedModel
    {
        [Required]
        public string Id { get; set; }
        public string? Url { get; set; }
        public int? Items { get; set; }
    }
}
