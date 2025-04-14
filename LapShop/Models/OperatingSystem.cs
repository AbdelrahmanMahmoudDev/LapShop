namespace LapShop.Models
{
    public class OperatingSystem
    {
        public int OperatingSystemId { get; set; }
        public string OperatingSystemName { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public bool ShowInHomePage { get; set; }
        public int CurrentState { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public List<Item> Items { get; set; }
    }
}
