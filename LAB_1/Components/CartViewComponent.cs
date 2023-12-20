using Microsoft.AspNetCore.Mvc;
using WEB.Extensions;
using WEB.Models;

namespace WEB.Components
{
    public class CartViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<Cart>("cart");
            return View(cart);
        }

    }
}
