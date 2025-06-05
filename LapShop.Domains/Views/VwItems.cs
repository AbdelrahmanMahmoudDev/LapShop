namespace LapShop.Domains.Views
{
    public class VwItems
    {
        public string ItemName { get; set; } = null!;
        public decimal SalesPrice {get; set;}
        public decimal PurchasePrice {get; set;}
        public string ImageName {get; set;} = null!;
        public string Gpu {get; set;} = null!;
        public string HardDisk {get; set;} = null!;
        public string Processor {get; set;} = null!;
        public int RamSize {get; set;}
        public string ScreenResolution {get; set;} = null!;
        public string ScreenSize {get; set;} = null!;
        public string Weight {get; set;} = null!;
        public string CategoryName {get; set;} = null!;
        public string ItemTypeName {get; set;} = null!;
        public string OperatingSystemName {get; set;} = null!;
    }
}
