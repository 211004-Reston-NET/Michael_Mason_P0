using System;
using BL;

namespace UI
{
    public class CustomerUpdate : IMenu
    {
        private static string exceptionMessage;
        private ICustomerBL _custBL;
        public CustomerUpdate(ICustomerBL bl)
        {
            _custBL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------------");
                exceptionMessage = null;
            }
            Console.WriteLine($"Are you sure you want to update {CustomerView.model.CustName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _custBL.UpdateModel(CustomerView.model);
                    return MenuType.CustomerList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CustomerUpdate;      
            }
        }
    }
}