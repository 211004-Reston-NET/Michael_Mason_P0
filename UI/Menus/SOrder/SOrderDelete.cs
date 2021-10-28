using System;
using BL;

namespace UI
{
    public class SOrderDelete : IMenu
    {
        private ISOrderBL _orderBL;
        public SOrderDelete(ISOrderBL bl)
        {
            _orderBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {SOrderView.model.OrderNumber}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _orderBL.DeleteModel(SOrderView.model);
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