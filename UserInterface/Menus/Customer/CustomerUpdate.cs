using System;
using Business;

namespace UserInterface
{
    public class CustomerUpdate : IMenu
    {
        private static string exceptionMessage;
        private ICustomerBL BL;
        public CustomerUpdate(ICustomerBL bl)
        {
            BL = bl;
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
            //Console.WriteLine($"Are you sure you want to update {CustomerView.customerM.CustName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    //var entity = BL.GetById(CustomerView.customerM.CustNumber);
                    //BL.Update(entity);
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