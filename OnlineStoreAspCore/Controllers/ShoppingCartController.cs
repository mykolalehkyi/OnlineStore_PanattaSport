using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStoreAspCore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            return View("ShoppingCartIndex");
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            return Json(shoppingCartService.AddProductToCart(productId));
        }

        public IActionResult GetListShoppingCart()
        {

            return Json(new { data = shoppingCartService.GetShoppingCartDTOs()});
        }

        [HttpPost]
        [Authorize]
        public IActionResult ConfirmCart()
        {
            return Json(shoppingCartService.ConfirmCart());
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            return Json(shoppingCartService.ClearCart());
        }

    }
}
