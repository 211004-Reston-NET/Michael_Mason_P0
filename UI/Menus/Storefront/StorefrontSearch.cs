using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class StorefrontSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private IStorefrontBL _storeBL;
        public StorefrontSearch(IStorefrontBL bl)
        {
            _storeBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Storefront Name");
            Console.WriteLine("-------------------");

            IEnumerable<StorefrontModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _storeBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (StorefrontModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.StoreName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a search term");
            }



            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search Again");
            Console.WriteLine("[2] View Storefront");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontMenu;
                case "1":
                    return MenuType.StorefrontSearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Storefront Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.StorefrontSearch;
                    }
                    return MenuType.StorefrontView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontSearch;
            }
        }
    }
}