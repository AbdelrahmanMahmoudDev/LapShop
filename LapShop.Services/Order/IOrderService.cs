using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Domains.ViewModels;

namespace LapShop.Services.Order
{
    public interface IOrderService
    {
        public void UpdateCart(ShoppingCartVM cart);
        public Task<ShoppingCartVM> GetCart();
        public void AddCart(int itemId, int? quantity = null);
    }
}
