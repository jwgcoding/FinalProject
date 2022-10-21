using Microsoft.AspNetCore.Mvc;

namespace MokuWebsite.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly IMenuRepository repo;
        public MenuItemsController(IMenuRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var menuItems = repo.GetAllItems();
            return View(menuItems);
        }
    }
}
