using Org.BouncyCastle.Crypto.Paddings;
using System;

namespace MokuWebsite.Models

{
    public class MenuItems
    {
        public MenuItems()
        {

        }
    
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }
        
        public string Picture { get; set; }
       
        public string Skewers { get; set; }
        public string Tapas { get; set; }
        public string Ramen { get; set; }
    }
    
}