using System;
using Business;

namespace UserInterface
{
    public class CustomerDelete : IMenu
    {
        private ICustomerBL BL;
        public CustomerDelete(ICustomerBL bl)
        {
            BL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            //Console.WriteLine($"Are you sure you want to delete {CustomerView.customerM.CustName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                //var entity = BL.GetById(CustomerView.customerM.CustNumber);
                //    BL.Delete(entity);
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