using System;
using Business;

namespace UserInterface
{
    public class InventoryDelete : IMenu
    {
        private IInventoryBl _prodBL;
        public InventoryDelete(IInventoryBl bl)
        {
            _prodBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {InventoryView.inventoryM.ProdId}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodBL.Delete(InventoryView.inventoryM);
                    return MenuType.InventoryList;
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