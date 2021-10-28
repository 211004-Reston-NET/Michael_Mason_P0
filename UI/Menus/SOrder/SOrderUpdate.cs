using System;
using BL;

namespace UI
{
    public class SOrderUpdate : IMenu
    {
        private static string exceptionMessage;
        private ISOrderBL _orderBL;
        public SOrderUpdate(ISOrderBL bl)
        {
            _orderBL = bl;
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
            Console.WriteLine($"Are you sure you want to update {SOrderView.model.OrderNumber}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _orderBL.UpdateModel(SOrderView.model);
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