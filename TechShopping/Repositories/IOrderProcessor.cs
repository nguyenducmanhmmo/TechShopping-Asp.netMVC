using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopping.Models;

namespace TechShopping.Repositories
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, Order order);
    }
}
