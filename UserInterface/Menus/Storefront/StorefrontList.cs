using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontList : IMenu
    {
        static string exceptionMessage;
        public static Storefront storefront;

        private IStorefrontBL BL;
        public StorefrontList(IStorefrontBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            IEnumerable<Storefront> items = BL.GetAll();

            Console.WriteLine("Storefront Listing");
            Console.WriteLine("----------------");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.StoreNumber}] {item.StoreName}, {item.StoreAddress}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Storefront Menu");
            Console.WriteLine("[1] Select Storefront");
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
                            Console.WriteLine("Enter storefront number");
                            string userInput = (Console.ReadLine());
                            storefront = BL.GetById(int.Parse(userInput));
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter a name";
                            return MenuType.StorefrontList;
                        }
                    return MenuType.StorefrontView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontList;
            }
        }
    }
}