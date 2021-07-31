using Business.Abstract;
using Etities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Etities.Concrete;
using MvcWebUI.Models;
using MvcWebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        ICartSessionService _cartSessionService;
        ICartService _cartService;
        IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartSErvice, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartSErvice;
            _productService = productService;
        }

        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your Product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartListViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your Product was successfully remove from the cart!"));
            return RedirectToAction("List");
        }
        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShipppingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShipppingDetails shipppingDetails)
        {
            if (!ModelState.IsValid)
            {
               
                return View();
            }
            TempData.Add("message",String.Format("Thank you {0}, your order is in process",shipppingDetails.FirstName));
            return View();
        }
    }
}
