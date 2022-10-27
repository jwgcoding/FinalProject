using MokuWebsite.Models;

namespace MokuWebsite
{
    public interface IMenuRepository
    {
        public IEnumerable<MenuItems> GetAllItems();
        public IEnumerable<MenuItems> GetItem(int id);

        public IEnumerable<MenuItems> GetAllSkewers(int id);
        public IEnumerable<MenuItems> GetAllTapas(int id);
        public IEnumerable<MenuItems> GetAllRamen(int id);
     
    }
}
