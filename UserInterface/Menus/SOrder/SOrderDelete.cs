using System;
using Business;

namespace UserInterface
{
    public class SOrderDelete : IMenu
    {
        private ISOrderBL BL;
        public SOrderDelete(ISOrderBL bl)
        {
            BL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {SOrderView.sOrder.OrderId}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Delete(SOrderView.sOrder);
                    return MenuType.SOrderList;
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