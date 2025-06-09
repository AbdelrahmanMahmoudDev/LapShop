using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains.ViewModels
{
    public class ShoppingCartVM
    {
        public List<ShoppingCartItemVM> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public ShoppingCartVM()
        {
            Items = new List<ShoppingCartItemVM>();
            TotalPrice = 0.0m;
        }
        public ShoppingCartVM(List<ShoppingCartItemVM> items, decimal totalPrice)
        {
            Items = items ?? new List<ShoppingCartItemVM>();
            TotalPrice = totalPrice;
        }
    }
}
