using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webcouch.Models;

namespace webcouch.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {

        private thewhitecouchContext storeDB; 
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.storeDB);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAsset = storeDB.Assets.Single(asset => asset.Assetid == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.storeDB);

            cart.AddToCart(addedAsset);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.storeDB);

            // Get the name of the album to display confirmation
            string assetName = storeDB.Carts
                .Single(item => item.RecordID == id).Assets.Comments;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = assetName +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.storeDB);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}