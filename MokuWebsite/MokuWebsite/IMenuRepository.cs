using Microsoft.AspNetCore.Mvc;
using MokuWebsite.Models;


namespace MokuWebsite
{
    public interface IMenuRepository
    {
        public IEnumerable<MenuItems> GetAllItems();
   

        public IEnumerable<MenuItems> GetAllSkewers();
      
        public IEnumerable<MenuItems> GetAllTapas();
        
        public IEnumerable<MenuItems> GetAllRamen();
        public void UpdateMenuItems(MenuItems item);
        public MenuItems GetItem(int id);
        public void InsertMenuItems(MenuItems item);
        
        public MenuItems AssignMenuItem();
        public void DeleteMenuItems(MenuItems item);
    }
}
