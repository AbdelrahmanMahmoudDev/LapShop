using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LapShop.Models
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
            ShowInHomePage = true;
        }
        [ValidateNever]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter a valid category name")]
        public string CategoryName { get; set; } = string.Empty;
        [ValidateNever]
        public string CategoryBy { get; set; } = string.Empty;
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        public int CurrentState { get; set; }
        public string ImageName { get; set; } = string.Empty;
        [ValidateNever]
        public bool ShowInHomePage { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
