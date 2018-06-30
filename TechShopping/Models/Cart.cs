﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechShopping.Models
{
    public class Cart
    {
        private List<CartItem> shoppingCart = new List<CartItem>();
        // Add item and quantity
        public void AddItem(Product product, int quantity)
        {
            CartItem item = shoppingCart.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (item == null)
            {
                shoppingCart.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        //Remove a product from shopping Cart
        public void RemoveItem(Product product)
        {
            shoppingCart.RemoveAll(i => i.Product.ProductID ==product.ProductID);
        }
        {
            return shoppingCart.Sum(e => e.Product.Price * e.Quantity);
        }
        {
            shoppingCart.Clear();
        }
        {
            get { return shoppingCart; }
        }
    }
}