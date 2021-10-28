using System;
using BL;
using Models;

namespace UI
{
    public class CustomerCreate : IMenu
    {
        private static CustomerModel newModel = new CustomerModel();
        private static string exceptionMessage;
        private ICustomerBL _custBL;
        public CustomerCreate(ICustomerBL bl)
        {
            _custBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a Customer");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.CustName}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save Customer");
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
                        Console.WriteLine("Enter the Customer Name");
                        newModel.CustName = Console.ReadLine();
                        return MenuType.CustomerCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.CustomerCreate;
                    }
                case "2":
                    try
                    {
                        _custBL.CreateModel(newModel);
                        exceptionMessage = "Customer saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.CustomerCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CustomerCreate;
            }
        }
    }
}