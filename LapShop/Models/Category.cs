namespace LapShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CurrentState { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public bool ShowInHomePage { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public List<Item> Items { get; set; }

    }
}
