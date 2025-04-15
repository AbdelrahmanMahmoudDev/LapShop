namespace LapShop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? ImageName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedBy { get; set; }
        public bool CurrentState { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Gpu { get; set; } = string.Empty;
        public string? HardDisk { get; set; } = string.Empty;
        public string? Processor { get; set; } = string.Empty;
        public int? RamSize { get; set; }
        public string? ScreenResolution { get; set; } = string.Empty;
        public string? ScreenSize { get; set; } = string.Empty;
        public string? Weight { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? ItemTypeId { get; set; }
        public ItemType? ItemType { get; set; }
        public int? OperatingSystemId { get; set; }
        public OperatingSystem? OperatingSystem { get; set; }
        public List<CustomerxItem> CustomerxItems { get; set; }
        public List<ItemDiscount> ItemDiscounts { get; set; }
        public List<ItemImage> ItemImages { get; set; }
        public List<PurchaseInvoicexItem> PurchaseInvoicexItems { get; set; }
        public List<SalesInvoicexItem> SalesInvoicexItems { get; set; }
    }
}
