using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerList : IMenu
    {
        private static string exceptionMessage;
        public static string email;
        public static CustomerM customerM;
        public static Customer customer;

        private ICustomerBL BL;
        public CustomerList(ICustomerBL bl)
        {
            BL = bl;
        }


        public void Menu()
        {
            var custs = BL.GetAll();
            foreach(var item in custs)
            {
                customerM = new CustomerM(item);
                Console.WriteLine(customerM.ToList());
            }
            Console.WriteLine("-----");
            
            Console.WriteLine("[0] Back to Customers Menu");
            Console.WriteLine("[1] Select customer");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Enter customer id");
                    customer = BL.GetById(int.Parse(Console.ReadLine()));
                    return MenuType.CustomerView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerList;
            }
        }
    }
}