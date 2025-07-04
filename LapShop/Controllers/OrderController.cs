﻿using LapShop.Domains.ViewModels;
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

        public IActionResult AddToCart(int id, int? quantity = null)
        {
            try
            {
                _orderService.AddCart(id, quantity);
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
                _orderService.UpdateCart(cart);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while changing the quantity: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveOrder(ShoppingCartVM cart)
        {
            try
            {
                _orderService.UpdateCart(cart);
                return Ok("Order saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving the order: " + ex.Message);
            }
        }


        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                var cart = await _orderService.GetCart();
                var cartItem = cart.Items.FirstOrDefault(i => i.ItemId == id);
                
                if (cartItem != null)
                {
                    cart.Items.Remove(cartItem);
                    cart.TotalPrice = cart.Items.Sum(i => i.TotalPrice);
                    _orderService.UpdateCart(cart);
                }
                return RedirectToAction("Cart");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the item from the cart: " + ex.Message);
            }
        }
    }
}
