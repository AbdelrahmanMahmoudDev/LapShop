using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains.ViewModels
{
    public class ShoppingCartItemVM
    {
        public ShoppingCartItemVM()
        {
            ItemId = 0;
            ItemImageUrl = string.Empty;
            ItemName = string.Empty;
            ItemPrice = 0.0m;
            Quantity = 0;
            TotalPrice = 0.0m;
        }
        public ShoppingCartItemVM(int itemId, string itemImageUrl, string itemName, decimal itemPrice, int quantity)
        {
            ItemId = itemId;
            ItemImageUrl = itemImageUrl;
            ItemName = itemName;
            ItemPrice = itemPrice;
            Quantity = quantity;
            TotalPrice = ItemPrice * Quantity;
        }
        public int ItemId { get; set; }
        public string ItemImageUrl { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
