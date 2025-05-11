using System.ComponentModel.DataAnnotations;

namespace LapShop.Domains
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
            ShowInHomePage = true;
        }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a valid category name")]
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
