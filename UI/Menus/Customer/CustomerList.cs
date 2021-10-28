using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class CustomerList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private ICustomerBL _custBL;
        public CustomerList(ICustomerBL bl)
        {
            _custBL = bl;
        }

        public void Menu()
        {
            IEnumerable<CustomerModel> items = _custBL.GetAllModel();

            Console.WriteLine("Customer Listing");
            Console.WriteLine("----------------");
            foreach (CustomerModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.CustName}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Categories Menu");
            Console.WriteLine("[1] Select Customer");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter Customer ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "Customer added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.CustomerList;
                        }
                    return MenuType.CustomerList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerList;
            }
        }
    }
}