using Microsoft.AspNetCore.Mvc;

namespace WEB.Components
{
    public class CartViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() => View();
        
    }
}
