using Doshboard.Backend.Services;
using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models.Widgets
{
    public class CityTempModel
    {
        [Required]
        public string Id { get; set; }
        public string? City { get; set; }
        public UnitType? Unit { get; set; }
    }
}
