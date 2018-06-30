using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechShopping.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}