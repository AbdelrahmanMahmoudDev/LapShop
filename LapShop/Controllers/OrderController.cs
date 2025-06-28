using LapShop.Domains.ViewModels;
using LapShop.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class QuantityDTO
    {
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemTotalPrice { get; set; }
    }
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

        [HttpPost("ChangeQuantity")]
        public IActionResult ChangeQuantity([FromBody] QuantityDTO quantityDTO)
        {
            try
            {
                var cart = _orderService.GetCart().Result;
                var cartItem = cart.Items.FirstOrDefault(i => i.ItemId == quantityDTO.ItemId);
                
                if (cartItem != null)
                {
                    cartItem.Quantity = quantityDTO.ItemCount;
                    cartItem.TotalPrice = quantityDTO.ItemTotalPrice;
                    cart.TotalPrice = cart.Items.Sum(i => i.TotalPrice);
                }
                // Update the cart in the session or database as needed
                _orderService.UpdateCart(cart);
                // For example, you might want to serialize and save it back to the session
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while changing the quantity: " + ex.Message);
            }
        }
    }
}
