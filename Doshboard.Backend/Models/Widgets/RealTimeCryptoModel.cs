using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class RealTimeCryptoModel
    {
        [Required]
        public string Id { get; set; }
        public string? Currency { get; set; }
        public string? Convert { get; set; }
    }
}
