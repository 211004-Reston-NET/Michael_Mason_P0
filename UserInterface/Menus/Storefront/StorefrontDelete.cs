using System;
using Business;

namespace UserInterface
{
    public class StorefrontDelete : IMenu
    {
        private IStorefrontBL BL;
        public StorefrontDelete(IStorefrontBL bl)
        {
            BL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {StorefrontView.storefront.StoreName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Delete(StorefrontView.storefront);
                    return MenuType.StorefrontList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ExitMenu;      
            }
        }
    }
}