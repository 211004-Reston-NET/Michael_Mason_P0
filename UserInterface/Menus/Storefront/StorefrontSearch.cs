using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontSearch : IMenu
    {
        private static string exceptionMessage;
        public static Storefront storefront;
        private IStorefrontBL BL;
        public StorefrontSearch(IStorefrontBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }

            var searchPrompt = $@"Customer search
[n] By name
[a] By address
            ";

            IEnumerable<Storefront> items = new List<Storefront>();

            Console.WriteLine(searchPrompt);
            var searchBy = Console.ReadLine().ToLower();
            Console.WriteLine("Enter query");
            switch (searchBy)
            {
                case "n":
                    var userInput = Console.ReadLine().ToLower();
                    items = BL.SearchStorefrontsByName(userInput);
                    break;
                case "a":
                    userInput = Console.ReadLine().ToLower();
                    items = BL.SearchStorefrontsByAddress(userInput);
                    break;
            }

            Console.WriteLine("-----");
            Console.WriteLine("[id] | name | address");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.StoreNumber}] | {item.StoreName} | {item.StoreAddress}");
            }


            Console.WriteLine("-----");
            Console.WriteLine("[0] Back");
            Console.WriteLine("[1] Search again");
            Console.WriteLine("[2] Select storefront");
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
                        Console.WriteLine("Enter storefront id");
                        storefront = BL.GetById(int.Parse(Console.ReadLine()));
                        return MenuType.StorefrontView;
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.StorefrontSearch;
                    }
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontSearch;
            }
        }
    }
}