using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class StorefrontList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private IStorefrontBL _storeBL;
        public StorefrontList(IStorefrontBL bl)
        {
            _storeBL = bl;
        }

        public void Menu()
        {
            IEnumerable<StorefrontModel> items = _storeBL.GetAllModel();

            Console.WriteLine("Storefront Listing");
            Console.WriteLine("----------------");
            foreach (StorefrontModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.StoreName}");
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
            Console.WriteLine("[2] Back to Product");
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
                            Console.WriteLine("Enter Storefront ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "Storefront added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.StorefrontList;
                        }
                    return MenuType.StorefrontList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontList;
            }
        }
    }
}