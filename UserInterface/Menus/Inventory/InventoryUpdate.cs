using System;
using Business;

namespace UserInterface
{
    public class InventoryUpdate : IMenu
    {
        private static string exceptionMessage;
        private IInventoryBl BL;
        public InventoryUpdate(IInventoryBl bl)
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
            Console.WriteLine($"Are you sure you want to update {InventoryView.inventoryM.ProdId}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Update(InventoryView.inventoryM);
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