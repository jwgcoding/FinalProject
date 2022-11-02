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
    }
}
  
