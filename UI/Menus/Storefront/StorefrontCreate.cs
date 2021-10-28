using System;
using BL;
using Models;

namespace UI
{
    public class StorefrontCreate : IMenu
    {
        private static StorefrontModel newModel = new StorefrontModel();
        private static string exceptionMessage;
        private IStorefrontBL _storeBL;
        public StorefrontCreate(IStorefrontBL bl)
        {
            _storeBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a Storefront");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.StoreName}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save Storefront");
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
                        Console.WriteLine("Enter the Storefront Name");
                        newModel.StoreName = Console.ReadLine();
                        return MenuType.StorefrontCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.StorefrontCreate;
                    }
                case "2":
                    try
                    {
                        _storeBL.CreateModel(newModel);
                        exceptionMessage = "Storefront saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.StorefrontCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.StorefrontCreate;
            }
        }
    }
}