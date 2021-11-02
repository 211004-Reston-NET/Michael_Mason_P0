using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerView : IMenu
    {
        private static string exceptionMessage;
        public Customer customer;
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
            
            CustomerM customerM = new CustomerM(CustomerList.customer);
            customerM.SOrders = BL.GetOrders(CustomerList.customer);
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
                    return MenuType.CustomerMenu;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CustomerMenu;
            }
        }
    }
}