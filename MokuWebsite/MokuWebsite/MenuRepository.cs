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

        public IEnumerable<MenuItems> GetItem(int id)
        {
          return _conn.Query<MenuItems>("SELECT * FROM MenuItems WHERE ID = @id", new { id = id });
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
        public void UpdateProduct(MenuItems menuItems)
        {
            _conn.Execute("UPDATE MenuItems SET Name = @name, Price = @price WHERE CategoryID = @id",
             new { name = menuItems.ItemName, price = menuItems.Price, id = product.ProductID });
        }
    }
}
  
