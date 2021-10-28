using System;
using BL;

namespace UI
{
    public class InventoryDelete : IMenu
    {
        private IInventoryBL _prodBL;
        public InventoryDelete(IInventoryBL bl)
        {
            _prodBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {InventoryView.model.Id}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodBL.DeleteModel(InventoryView.model);
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