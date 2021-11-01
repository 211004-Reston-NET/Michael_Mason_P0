using System;

namespace UserInterface
{
    public class ProductMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Products Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a Product");
            Console.WriteLine("[2] List all Products");
            Console.WriteLine("[3] Search for a Product");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ProductCreate;
                case "2":
                    return MenuType.ProductList;
                case "3":
                    return MenuType.ProductSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProductMenu;
            }
        }
    }
}