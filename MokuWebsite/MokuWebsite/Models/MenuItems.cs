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
        public double Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }
       
    }
    
}