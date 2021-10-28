using System;
using BL;

namespace UI
{
    public class StorefrontDelete : IMenu
    {
        private IStorefrontBL _storeBL;
        public StorefrontDelete(IStorefrontBL bl)
        {
            _storeBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {StorefrontView.model.StoreName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _storeBL.DeleteModel(StorefrontView.model);
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