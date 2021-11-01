using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontCreate : IMenu
    {
        static string exceptionMessage;
        IStorefrontBL BL;
        Storefront storefront = new Storefront();

        public StorefrontCreate(IStorefrontBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Create a Storefront");
            Console.WriteLine("-----");
            Console.WriteLine($"Enter name");
            storefront.StoreName = Console.ReadLine();
            Console.WriteLine("-----");
            Console.WriteLine("Enter address");
            storefront.StoreAddress = Console.ReadLine();
            Console.WriteLine("-----");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Save Storefront");
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
                        Console.WriteLine(BL.Create(storefront));
                        BL.Save();
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.StorefrontMenu;
                    }
                    return MenuType.StorefrontList;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.StorefrontCreate;
            }
        }
    }
}