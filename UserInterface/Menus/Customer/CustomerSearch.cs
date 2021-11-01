using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;
using System.Linq;

namespace UserInterface
{
    public class CustomerSearch : IMenu
    {
        private static string exceptionMessage;
        public static string email;
        private ICustomerBL BL;
        public CustomerSearch(ICustomerBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            var searchPrompt = $@"Customer search
[e] By email
[n] By name
[a] By address
[p] By phone
            ";

            IEnumerable<Customer> items = new List<Customer>();

            Console.WriteLine(searchPrompt);
            var searchBy = Console.ReadLine().ToLower();
            Console.WriteLine("Enter query");
            switch (searchBy)
            {
                case "e":
                    var userInput = Console.ReadLine().ToLower();
                    items = BL.SearchByEmail(userInput);
                    break;
                case "n":
                    userInput = Console.ReadLine().ToLower();
                    items = BL.SearchByName(userInput);
                    break;
                case "a":
                    userInput = Console.ReadLine().ToLower();
                    items = BL.SearchByAddress(userInput);
                    break;
                case "p":
                    userInput = Console.ReadLine().ToLower();
                    items = BL.SearchByPhone(int.Parse(userInput));
                    break;
            }

            Console.WriteLine("-----");

            if (items.Count() == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                foreach (var item in items)
                {
                    CustomerM custM = new CustomerM(item);
                    Console.WriteLine(custM.ToList());
                }
            }

            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Customer menu");
            Console.WriteLine("[1] Search again");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    return MenuType.CustomerSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerSearch;
            }
        }
    }
}