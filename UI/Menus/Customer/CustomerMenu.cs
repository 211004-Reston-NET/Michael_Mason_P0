using System;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Customer Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a Customer");
            Console.WriteLine("[2] List all Customers");
            Console.WriteLine("[3] Search for a Customer");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.CustomerCreate;
                case "2":
                    return MenuType.CustomerList;
                case "3":
                    return MenuType.CustomerSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerMenu;
            }
        }
    }
}