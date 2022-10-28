using Microsoft.AspNetCore.Mvc;
using MokuWebsite.Models;

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

        public IActionResult Skewers()
        {
            var skewers = repo.GetAllSkewers();
            return View(skewers);
        }
        public IActionResult Tapas()
        {
            var tapas = repo.GetAllTapas();
            return View(tapas);

        }
        public IActionResult Ramens()
        {
            var ramen = repo.GetAllRamen(); 
            return View(ramen);
        }
        //public IEnumerable<MenuItems> GetAllTapas()
        //{
        //    var tapas = repo.GetAllTapas();
        //    return tapas;
        //}
        //public IEnumerable<MenuItems> GetAllRamen()
        //{
        //    var ramen = repo.GetAllRamen();
        //    return ramen;
        //}
    }
}
