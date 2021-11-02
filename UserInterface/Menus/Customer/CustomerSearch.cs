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
        public static Customer customer;
        public static string email;
        private ICustomerBL BL;
        public CustomerSearch(ICustomerBL bl)
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
[e] By email
[n] By name
[a] By address
[p] By phone
            ";

            IEnumerable<Customer> items = new List<Customer>();

            Console.WriteLine(searchPrompt);
            var searchBy = Console.ReadLine().ToLower();
            switch (searchBy)
            {
                case "e":
                    while (items.Count() == 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter query");
                            var userInput = Console.ReadLine().ToLower();
                            items = BL.SearchByEmail(userInput);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case "n":
                    while (items.Count() == 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter query");
                            var userInput = Console.ReadLine().ToLower();
                            items = BL.SearchByName(userInput);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case "a":
                    while (items.Count() == 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter query");
                            var userInput = Console.ReadLine().ToLower();
                            items = BL.SearchByAddress(userInput);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case "p":
                    while (items.Count() == 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter query");
                            var userInput = Console.ReadLine().ToLower();
                            items = BL.SearchByPhone(int.Parse(userInput));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
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
            Console.WriteLine("[2] Select customer");
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
                    while (customer == null)
                    {
                        try
                        {
                            Console.WriteLine("Enter customer id");
                            customer = BL.GetById(int.Parse(Console.ReadLine()));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    return MenuType.CustomerView;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.CustomerSearch;
            }
        }
    }
}