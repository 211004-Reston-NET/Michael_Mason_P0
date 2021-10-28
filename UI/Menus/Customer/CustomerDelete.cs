using System;
using BL;

namespace UI
{
    public class CustomerDelete : IMenu
    {
        private ICustomerBL _custBL;
        public CustomerDelete(ICustomerBL bl)
        {
            _custBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {CustomerView.model.CustName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _custBL.DeleteModel(CustomerView.model);
                    return MenuType.CustomerList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ExitMenu;      
            }
        }
    }
}