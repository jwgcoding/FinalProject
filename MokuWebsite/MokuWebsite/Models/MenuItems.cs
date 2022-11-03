using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Paddings;
using System;

namespace MokuWebsite.Models

{
    public class MenuItems
    {
        //Getting MenuItems
        public MenuItems()
        {

        }
        
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }
        public int CategoryID{ get; set; }
        public string Picture { get; set; }
        public int ID { get; set;}
        
    }
    //Getting Skewer Items

    public class SkewerItems
    {
        public SkewerItems()
        {
        }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }

        public string Picture { get; set; }
    }
    //Getting Tapa Items
    public class TapaItems
    {
        public TapaItems()
        {

        }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }

        public string Picture { get; set; }
    }

    //Getting Ramen Items
    public class RamenItems
    {
        public RamenItems()
        {

        }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsSeafood { get; set; }
        public string HasGluten { get; set; }

        public string Picture { get; set; }
    }
}