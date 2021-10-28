using System;
using BL;

namespace UI
{
    public class StorefrontUpdate : IMenu
    {
        private static string exceptionMessage;
        private IStorefrontBL _storeBL;
        public StorefrontUpdate(IStorefrontBL bl)
        {
            _storeBL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------------");
                exceptionMessage = null;
            }
            Console.WriteLine($"Are you sure you want to update {StorefrontView.model.StoreName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _storeBL.UpdateModel(StorefrontView.model);
                    return MenuType.StorefrontList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontUpdate;      
            }
        }
    }
}