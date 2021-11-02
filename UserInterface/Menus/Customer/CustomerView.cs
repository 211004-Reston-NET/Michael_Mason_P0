using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerView : IMenu
    {
        private static string exceptionMessage;
        public static Customer customer = new Customer();
        private static ICustomerBL BL;
        public CustomerView(ICustomerBL bl)
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
            if (CustomerList.customer != null)
            {
                customer = CustomerList.customer;
                CustomerList.customer = null;
            }
            if (CustomerSearch.customer != null)
            {
                customer = CustomerSearch.customer;
                CustomerSearch.customer = null;
            }
            CustomerM customerM = new CustomerM(customer);
            customerM.SOrders = BL.GetOrders(customer);
            Console.WriteLine("Customer View");
            Console.WriteLine(customerM);
            Console.WriteLine("-----");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    customer = null;
                    return MenuType.CustomerMenu;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CustomerMenu;
            }
        }
    }
}