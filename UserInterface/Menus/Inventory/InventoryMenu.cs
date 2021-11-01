using System;

namespace UserInterface
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
            Console.WriteLine("[1] List all Inventory");
            Console.WriteLine("[2] Add a product");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.InventoryList;
                case "2":
                    return MenuType.InventoryCreate;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventoryMenu;
            }
        }
    }
}