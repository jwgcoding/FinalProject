using Dapper;
using MokuWebsite.Models;
using System.Data;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace MokuWebsite
{

    public class MenuRepository : IMenuRepository
    {
        private readonly IDbConnection _conn;
        public MenuRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<MenuItems> GetAllItems()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems ");
        }

        public MenuItems GetItem(int id)
        {
          return _conn.QuerySingle<MenuItems>("SELECT * FROM MenuItems WHERE ID = @id", new { id = id });

        }

        public IEnumerable<MenuItems> GetAllSkewers()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 1");
        }
       
        public IEnumerable<MenuItems> GetAllTapas()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 2");
        }
        public IEnumerable<MenuItems> GetAllRamen()
        {
            return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE CategoryID = 3");
        }
        public void UpdateMenuItems(MenuItems menuItems)
        {
            _conn.Execute("UPDATE MenuItems SET ItemName = @name, Price = @price, CategoryID = @category WHERE ID = @id",
             new { name = menuItems.ItemName, price = menuItems.Price, category = menuItems.CategoryID, id = menuItems.ID });
        }

        public void InsertMenuItems(MenuItems menuItems)
        {
            _conn.Execute("INSERT INTO MenuItems (NAME, PRICE, CATEGORYID, HasGluten, IsSeafood) VALUES (@name, @price, @categoryID, @seafood, @gluten);",
                new { name = menuItems.ItemName, price = menuItems.Price, categoryID = menuItems.CategoryID, seafood = menuItems.IsSeafood, gluten = menuItems.HasGluten });
        }

        public IEnumerable<Category> GetCategoryID()
        {
            return _conn.Query<Category>("SELECT * FROM CategoryID;");
        }
        public MenuItems AssignCategoryID()
        {
            var categoryIDList = GetCategoryID();
            var menuItems = new MenuItems();
            menuItems.CategoryID = categoryIDList;
            return menuItems;
        }
        public void DeleteProduct(MenuItems menuItems)
        {
            _conn.Execute("DELETE FROM MenuItems WHERE ID = @id;", new { id = menuItems.ID });
    
        }
    }
}
  
