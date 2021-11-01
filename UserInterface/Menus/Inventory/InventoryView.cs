using System;
using Business;
using Models;

namespace UserInterface
{
    public class InventoryView : IMenu
    {
        private static string exceptionMessage;
        public static InventoryM inventoryM;
        private static IInventoryBl BL;
        public InventoryView(IInventoryBl bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify Name");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.InventoryMenu;
                
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.InventoryMenu;
            }
        }
    }
}