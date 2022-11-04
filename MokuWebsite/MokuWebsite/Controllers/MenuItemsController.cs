using Microsoft.AspNetCore.Mvc;
using MokuWebsite.Models;
using NuGet.LibraryModel;
using System.Security.Cryptography.X509Certificates;

namespace MokuWebsite.Controllers
{
    public class MenuItemsController : Controller
    {
        //Private view of repository
        private readonly IMenuRepository repo;
        //Sets menuitemscontroller as repo
        public MenuItemsController(IMenuRepository repo)
        {
            this.repo = repo;
        }
        // Get All Items Method//
        public IActionResult Index()
        {
            var menuItems = repo.GetAllItems();
            foreach (var item in menuItems)
            {
                if (string.IsNullOrWhiteSpace(item.Picture))
                {
                    item.Picture = "/lib/Images/imagecomingsoon.jpg";
                }
            }
            return View(menuItems);
        }
        //Gets all skewers method
        public IActionResult Skewers()
        {
            var skewers = repo.GetAllSkewers();
            foreach (var item in skewers)
            {
                if (string.IsNullOrWhiteSpace(item.Picture))
                {
                    item.Picture = "/lib/Images/imagecomingsoon.jpg";
                }
            }
            return View(skewers);
        }
        //Gets all tapas method
        public IActionResult Tapas()
        {
            var tapas = repo.GetAllTapas();
            foreach (var item in tapas)
            {
                if (string.IsNullOrWhiteSpace(item.Picture))
                {
                    item.Picture = "/lib/Images/imagecomingsoon.jpg";
                }
            }
            return View(tapas);

        }
        //Gets all ramens method
        public IActionResult Ramens()
        {

            var ramen = repo.GetAllRamen();

            foreach (var item in ramen)
            {
                if (string.IsNullOrWhiteSpace(item.Picture))
                {
                    item.Picture = "/lib/Images/imagecomingsoon.jpg";
                }
            }



            return View(ramen);
        }

        //Allows us to access ViewMenuItem view + gives empty picture default picture
        public IActionResult ViewMenuItem(int id)
        {


            var menuItem = repo.GetItem(id);
            if (string.IsNullOrWhiteSpace(menuItem.Picture))
            {
                menuItem.Picture = "/lib/Images/imagecomingsoon.jpg";
            }
            if (menuItem == null)
            {
                return View("Error");
            }
            return View(menuItem);
        }

        //If updating an item is null, redirect back to the menu
        public IActionResult UpdateMenu(int id)
        {
            MenuItems menuItems = repo.GetItem(id);
            if (menuItems == null)
            {
                return View("Error");
            }
            return View(menuItems);
        }
        //Updates menuitems to database
        public IActionResult UpdateProductToDatabase(MenuItems menuItems)
        {
            repo.UpdateMenuItems(menuItems);

            return RedirectToAction("ViewMenuItem", new { id = menuItems.ID });
        }
        //Create new menuitem
        public IActionResult InsertMenuItem()
        {
            var item = repo.AssignMenuItem();
            return View(item);
        }
        //Inserts menuitem to database
        public IActionResult InsertMenuItemToDatabase(MenuItems menuItems)
        {
            repo.InsertMenuItems(menuItems);
            return RedirectToAction("Index");
        }
        //Deletes menuitem from database
        public IActionResult DeleteMenuItems(MenuItems menuItems)
        {
            repo.DeleteMenuItems(menuItems);
            return RedirectToAction("Index");
        }
    }
}
