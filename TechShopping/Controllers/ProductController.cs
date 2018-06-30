using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopping.Repositories;

using TechShopping.Models;

namespace TechShopping.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repoProduct;
        public int PageSize = 4;
        public ProductController(IProductRepository repoProduct)
        {
            _repoProduct = repoProduct;
        }

        //View All Product of TechShop
        public ViewResult List(int page = 1)
        {
            ProductsListViewModel listProduct = new ProductsListViewModel
            {
                Products = _repoProduct.Products
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repoProduct.Products.Count()
                }
            };
            return View(listProduct);
        }
        // List Product By Category
        public ActionResult GetProductByCategory(int? categoryId, int page=1)
        {
            ProductsListViewModel listProductByCategory = new ProductsListViewModel
            {
                Products = _repoProduct.Products
            .OrderBy(p => p.ProductID)
            .Where( p => p.CategoryID == categoryId)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repoProduct.Products.Count()
                }
            };
            return View(listProductByCategory);
        }

        //Get Detail of one Product 
        public ActionResult ProductDetail ( int productId)
        {
            Product pd = _repoProduct.Products.Single(p => p.ProductID == productId);
            return View(pd);

        }
    }
}