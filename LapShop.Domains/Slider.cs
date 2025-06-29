using System.ComponentModel.DataAnnotations;

namespace LapShop.Domains
{
    public class Slider
    {
        public int SliderId { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string ImageName { get; set; }
    }
}
