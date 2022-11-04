using Dapper;
using MokuWebsite.Models;
using System.Data;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace MokuWebsite
{
    // Connects to database
    public class MenuRepository : IMenuRepository
    {
        private readonly IDbConnection _conn;
        public MenuRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        //Grabs all items by categoryid and id
        public IEnumerable<MenuItems> GetAllItems()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems ORDER BY CategoryID , ID");
        }

        //grabs single item
        public MenuItems GetItem(int id)
        {
            return _conn.QuerySingle<MenuItems>("SELECT * FROM MenuItems WHERE ID = @id ", new { id = id });

        }
        // grabs all skewer items by catgoryid
        public IEnumerable<MenuItems> GetAllSkewers()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 1 Order by ID");
        }
        //grabs all tapas item by categoryid
        public IEnumerable<MenuItems> GetAllTapas()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 2 ORDER BY ID");
        }
        //grabs all ramens by categoryid
        public IEnumerable<MenuItems> GetAllRamen()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 3 ORDER BY ID");
        }
        //updates  menu items
        public void UpdateMenuItems(MenuItems menuItems)
        {
            _conn.Execute("UPDATE MenuItems SET ItemName = @name, Price = @price, CategoryID = @category WHERE ID = @id",
             new { name = menuItems.ItemName, price = menuItems.Price, category = menuItems.CategoryID, id = menuItems.ID });
        }
        // create new menu items in the menu items
        public void InsertMenuItems(MenuItems menuItems)
        {
            _conn.Execute("INSERT INTO MenuItems (ItemNAME, PRICE, CATEGORYID, HasGluten, IsSeafood) VALUES (@name, @price, @categoryID, @seafood, @gluten);",
                new { name = menuItems.ItemName, price = menuItems.Price, categoryID = menuItems.CategoryID, seafood = menuItems.IsSeafood, gluten = menuItems.HasGluten });

        }

        //assign menuitems to menuitems method 
        public MenuItems AssignMenuItem()
        {

            var menuItems = new MenuItems();
            return menuItems;
        }

        //deletes menu items by id
        public void DeleteMenuItems(MenuItems menuItems)
        {
            _conn.Execute("DELETE FROM MenuItems WHERE ID = @id;", new { id = menuItems.ID });

        }
    }
}

