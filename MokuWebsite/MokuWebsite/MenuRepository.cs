using Dapper;
using MokuWebsite.Models;
using System.Data;
using System.Drawing;

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

       
    }
}
  
