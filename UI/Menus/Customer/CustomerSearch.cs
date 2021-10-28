using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class CustomerSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private ICustomerBL _custBL;
        public CustomerSearch(ICustomerBL bl)
        {
            _custBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Customer Name");
            Console.WriteLine("-------------------");

            IEnumerable<CustomerModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _custBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (CustomerModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.CustName}");
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
            Console.WriteLine("[2] View Customer");
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
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Customer Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.CustomerSearch;
                    }
                    return MenuType.CustomerView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerSearch;
            }
        }
    }
}