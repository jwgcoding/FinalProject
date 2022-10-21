using MokuWebsite.Models;

namespace MokuWebsite
{
    public interface IMenuRepository
    {
        public IEnumerable<MenuItems> GetAllItems();
        public MenuItems GetItem(int id);
    }
}
