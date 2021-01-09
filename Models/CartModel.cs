using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsShop.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public Dictionary<string, int> items { get; set; }
    }
}
