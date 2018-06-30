using System;
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
        }        // Caculate money custommer has to pay        public decimal CaculateTotal()
        {
            return shoppingCart.Sum(e => e.Product.Price * e.Quantity);
        }        //Delete User's Cart        public void Clear()
        {
            shoppingCart.Clear();
        }        public IEnumerable<CartItem> Items
        {
            get { return shoppingCart; }
        }
    }
}