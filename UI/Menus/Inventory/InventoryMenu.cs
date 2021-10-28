using System;

namespace UI
{
    public class InventoryMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Categories Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a Inventory");
            Console.WriteLine("[2] List all Inventory");
            Console.WriteLine("[3] Search for a Inventory");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.InventoryCreate;
                case "2":
                    return MenuType.InventoryList;
                case "3":
                    return MenuType.InventorySearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventoryMenu;
            }
        }
    }
}