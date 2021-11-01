using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerCreate : IMenu
    {
        private static CustomerM customerM;
        private static Customer customer;
        private static string exceptionMessage;
        private ICustomerBL BL;
        public CustomerCreate(ICustomerBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            customer = new Customer();
            Console.WriteLine("Create a Customer");
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter a name");
            customer.CustName = Console.ReadLine();
            Console.WriteLine("Enter address");
            customer.CustAddress = Console.ReadLine();
            Console.WriteLine("Enter Email");
            customer.CustEmail = Console.ReadLine();
            Console.WriteLine("Enter Phone");
            customer.CustPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------");

            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Save Customer");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine(BL.Create(customer));
                    BL.Save();
                    return MenuType.CustomerList;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CustomerCreate;
            }
        }
    }
}