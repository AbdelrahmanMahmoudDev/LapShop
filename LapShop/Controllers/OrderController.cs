using LapShop.Domains.ViewModels;
using LapShop.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Cart()
        {
            return View(await _orderService.GetCart());
        }

        public IActionResult AddToCart(int id)
        {
            try
            {
                _orderService.AddCart(id);
                return RedirectToAction("Cart");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the item to the cart: " + ex.Message);
            }
        }
    }
}
