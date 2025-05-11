namespace LapShop.Domains
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; } = string.Empty;
        public string? ImageName { get; set; } = string.Empty;
        public int CurrentState { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public List<Item> Items { get; set; }
    }
}
