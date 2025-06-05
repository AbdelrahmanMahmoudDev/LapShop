using Microsoft.AspNetCore.Http;

namespace LapShop.Domains.ViewModels
{
    public class VwItemsVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ImageName { get; set; } = null!;
        public string Gpu { get; set; } = null!;
        public string HardDisk { get; set; } = null!;
        public string Processor { get; set; } = null!;
        public int RamSize { get; set; }
        public string ScreenResolution { get; set; } = null!;
        public string ScreenSize { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; } = null!;
        public ICollection<ItemType> ItemTypes { get; set; } = new List<ItemType>();
        public int OperatingSystemId { get; set; }
        public string OperatingSystemName { get; set; } = null!;
        public ICollection<OperatingSystem> OperatingSystems { get; set; } = new List<OperatingSystem>();
        public IFormFile File { get; set; } = null!;
    }
}
