using System;
using BL;

namespace UI
{
    public class InventoryUpdate : IMenu
    {
        private static string exceptionMessage;
        private IInventoryBL _invBL;
        public InventoryUpdate(IInventoryBL bl)
        {
            _invBL = bl;
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
            Console.WriteLine($"Are you sure you want to update {InventoryView.model.Id}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _invBL.UpdateModel(InventoryView.model);
                    return MenuType.InventoryList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventoryUpdate;      
            }
        }
    }
}