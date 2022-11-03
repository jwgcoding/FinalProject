using Microsoft.AspNetCore.Mvc;
using MokuWebsite.Models;
using System.Security.Cryptography.X509Certificates;

namespace MokuWebsite.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly IMenuRepository repo;
        public MenuItemsController(IMenuRepository repo)
        {
            this.repo = repo;
        }
        // Get All Products Method//
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
        public IActionResult ViewMenuItem(int id)
        {
            //var result = Request.Form["id"];
            //var id = Convert.ToInt32(result);
            var menuItem = repo.GetItem(id);
            if (menuItem == null)
            {
                return View("Error");
            }
            return View(menuItem);
        }
        public IActionResult UpdateMenu(int id)
        {
            MenuItems menuItems = repo.GetItem(id);
            if (menuItems == null)
            {
                return View("Error");
            }
            return View(menuItems);
        }

        public IActionResult UpdateProductToDatabase(MenuItems menuItems)
        {
            repo.UpdateMenuItems(menuItems);

            return RedirectToAction("ViewMenuItem", new { id = menuItems.ID });
        }

        public IActionResult InsertMenuItem()
        {
            var item = repo.AssignCategoryID();
            return View(item);
        }
        public IActionResult InsertProductToDatabase(MenuItems menuItems)
        {
            repo.InsertMenuItems(menuItems);
            return RedirectToAction("Index");
        }

        //  public List<MenuItems> GetMenuItems()
        //  {
        //      List<MenuItems> mod = new List<MenuItems>
        //     {
        //          new MenuItems { repo.GetAllItems }
        //      };
        //  }
        //  public PartialViewResult SearchItems(string searchText)
        //      {

        //       var result = repo.Where(a => a.Name.ToLower().Contains(searchText)) || a.Price.ToString().Contains(searchText));
        //      return PartialView("_Index.cshtml",result);
        //  }
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
