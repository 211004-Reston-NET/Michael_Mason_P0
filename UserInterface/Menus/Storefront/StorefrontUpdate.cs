using System;
using System.Linq;
using Business;
using Data;

namespace UserInterface
{
    public class StorefrontUpdate : IMenu
    {
        private static string exceptionMessage;
        private IStorefrontBL BL;
        public StorefrontUpdate(IStorefrontBL bl)
        {
            BL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter new quantity");
            Console.WriteLine("Save changes?");
            return MenuType.StorefrontList;
            // switch(userSelection)
            // {
            //     case "y":
            //         return MenuType.StorefrontList;
            //     case "n":
            //         return MenuType.MainMenu;
            //     default:
            //         exceptionMessage = "INVALID SELECTION";
            //         return MenuType.StorefrontUpdate;      
            // }
        }
    }
}