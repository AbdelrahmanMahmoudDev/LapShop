using System.ComponentModel.DataAnnotations;

namespace LapShop.Domains
{
    public class BusinessInfo
    {
        public int BusinessInfoId { get; set; }
        [MaxLength(20)]
        public string? BusinessCardNumber { get; set; } = string.Empty;
        public string? OfficePhone { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
