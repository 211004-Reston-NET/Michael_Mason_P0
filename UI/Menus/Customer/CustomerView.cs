using System;
using BL;
using Models;

namespace UI
{
    public class CustomerView : IMenu
    {
        private static string exceptionMessage;
        public static CustomerModel model;
        private static ICustomerBL _custBL;
        public CustomerView(ICustomerBL bl)
        {
            _custBL = bl;
        }
        public void Menu()
        {
            if (CustomerSearch.PKey != 0)
            {
                model = _custBL.GetModel(CustomerSearch.PKey);
                CustomerSearch.PKey = 0;
            }
            if (CustomerList.PKey != 0)
            {
                model = _custBL.GetModel(CustomerList.PKey);
                CustomerList.PKey = 0;
            }

            Console.WriteLine("Customer View");
            Console.WriteLine($"Customer: {model.Id} | {model.CustName}");
            Console.WriteLine("-------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify Name");
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
                            Console.WriteLine("Enter new Name");
                            model.CustName = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.CustomerView;
                        }
                    return MenuType.CustomerUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CustomerMenu;
            }
        }
    }
}