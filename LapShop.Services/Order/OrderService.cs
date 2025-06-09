using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Domains.ViewModels;
using LapShop.Services.Item;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LapShop.Services.Order
{
    public class OrderService  : IOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IItemService _itemService;
        public OrderService(IHttpContextAccessor httpContextAccessor, IItemService itemService)
        {
            _httpContextAccessor = httpContextAccessor;
            _itemService = itemService;
        }

        public Task<ShoppingCartVM> GetCart()
        {
            ShoppingCartVM cart;
            var session = _httpContextAccessor.HttpContext?.Request.Cookies["Cart"];

            if (session != null)
            {
                cart = JsonConvert.DeserializeObject<ShoppingCartVM>(session);
            }
            else
            {
                cart = new ShoppingCartVM();
            }

            return Task.FromResult(cart);
        }

        public void AddCart(int itemId)
        {
            var cart = GetCart().Result;

            try
            {
                var targetItem = _itemService.GetSingle(itemId);

                ShoppingCartItemVM cartItem = cart.Items
                                         .AsQueryable()
                                         .Where(i => i.ItemId == itemId)
                                         .FirstOrDefault();
                
                if(cartItem != null)
                {
                    cartItem.Quantity++;
                    cartItem.TotalPrice = cartItem.Quantity * cartItem.ItemPrice;
                }
                else
                {
                    cart.Items.Add(new ShoppingCartItemVM
                    {
                        ItemId = targetItem.ItemId,
                        ItemImageUrl = targetItem.ImageName,
                        ItemName = targetItem.ItemName,
                        ItemPrice = targetItem.SalesPrice,
                        Quantity = 1,
                        TotalPrice = targetItem.SalesPrice
                    });
                }
                cart.TotalPrice = cart.Items.Sum(i => i.TotalPrice);
                var session = JsonConvert.SerializeObject(cart);
                _httpContextAccessor.HttpContext?.Response.Cookies.Append("Cart", session, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30) // Set cookie expiration to 30 days
                });
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}