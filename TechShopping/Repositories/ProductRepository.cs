using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechShopping.Models;

namespace TechShopping.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }

        }
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry =
                context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}