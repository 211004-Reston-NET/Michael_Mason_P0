using System;
using BL;
using Models;

namespace UI
{
    public class StorefrontView : IMenu
    {
        private static string exceptionMessage;
        public static StorefrontModel model;
        private static IStorefrontBL _storeBL;
        public StorefrontView(IStorefrontBL bl)
        {
            _storeBL = bl;
        }
        public void Menu()
        {
            if (StorefrontSearch.PKey != 0)
            {
                model = _storeBL.GetModel(StorefrontSearch.PKey);
                StorefrontSearch.PKey = 0;
            }
            if (StorefrontList.PKey != 0)
            {
                model = _storeBL.GetModel(StorefrontList.PKey);
                StorefrontList.PKey = 0;
            }

            Console.WriteLine("Storefront View");
            Console.WriteLine($"Storefront: {model.Id} | {model.StoreName}");
            Console.WriteLine("-------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify Name");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter new Name");
                            model.StoreName = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.StorefrontView;
                        }
                    return MenuType.StorefrontUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.StorefrontMenu;
            }
        }
    }
}