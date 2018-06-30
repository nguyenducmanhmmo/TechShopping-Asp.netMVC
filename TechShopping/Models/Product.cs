using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechShopping.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        [Required, StringLength(100), Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}