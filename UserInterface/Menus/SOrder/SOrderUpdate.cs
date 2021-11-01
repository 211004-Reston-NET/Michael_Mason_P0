using System;
using Business;

namespace UserInterface
{
    public class SOrderUpdate : IMenu
    {
        private static string exceptionMessage;
        private ISOrderBL BL;
        public SOrderUpdate(ISOrderBL bl)
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
            Console.WriteLine($"Are you sure you want to update {SOrderView.sOrder.OrderId}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Update(SOrderView.sOrder);
                    return MenuType.SOrderList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.SOrderUpdate;      
            }
        }
    }
}