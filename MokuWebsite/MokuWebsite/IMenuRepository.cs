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
     
    }
}
