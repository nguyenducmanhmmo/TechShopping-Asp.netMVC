using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopping.Models;
using TechShopping.Repositories;

namespace TechShopping.Controllers
{
    public class CartController : Controller

    {
        private IOrderProcessor orderProcessor;

        private IProductRepository _repoProdcuct;

        public CartController(IProductRepository repoProduct, IOrderProcessor proc)
        {
            _repoProdcuct = repoProduct;
            orderProcessor = proc;
        }
        // Get or Create Cart Session
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Funtion Add to Cart for button
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _repoProdcuct.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        //Function Remove Item From User's Cart button
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = _repoProdcuct.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // Get User's Cart
        public ViewResult MyCart(Cart cart, string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,

                ReturnUrl = returnUrl
            });
        }
        //View User's Cart in Navbar
        public PartialViewResult ViewCart(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, order);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(order);
            }
        }
    }
}