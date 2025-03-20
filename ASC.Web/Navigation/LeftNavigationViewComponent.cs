using ASC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASC.Web.Navigation
{
    [ViewComponent(Name = "LeftNavigation")]
    public class LeftNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(NavigationMenu menu)
        {
            menu.MenuItems = menu.MenuItems.OrderBy(p => p.Sequence).ToList();
            return View(menu);
        }
    }
}
