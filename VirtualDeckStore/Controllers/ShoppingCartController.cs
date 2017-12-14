using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using VirtualDeckStore.Models;
using VirtualDeckStore.ViewModels;

namespace VirtualDeckStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                PublishedKey = ConfigurationManager.AppSettings["stripePublishableKey"]
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(product => product.Id == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

            return RedirectToAction("Index");
        }
       
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //string productName = db.Carts.FirstOrDefault(item => item.ProductId == id).Product.Name;

            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                PublishedKey = ConfigurationManager.AppSettings["stripePublishableKey"]
            };

            return View("Index", results);
        }

        [HttpPost]
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var order = new CustomerOrder();
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var cart = ShoppingCart.GetCart(this.HttpContext);

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = (int)(cart.GetTotal() * 100),
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            order.CustomerUserName = User.Identity.Name;
            order.DateCreated = DateTime.Now;

            db.CustomerOrders.Add(order);
            db.SaveChanges();

            cart.CreateOrder(order);

            db.SaveChanges();

            return RedirectToAction("Complete", new { id = order.Id });
        }

        public ActionResult Complete(int id)
        {
            bool isValid = db.CustomerOrders.Any(
                o => o.Id == id &&
                     o.CustomerUserName == User.Identity.Name
                );

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}