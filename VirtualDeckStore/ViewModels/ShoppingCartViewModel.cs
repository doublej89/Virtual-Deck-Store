using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckStore.Models;

namespace VirtualDeckStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public string PublishedKey { get; set; }
    }
}