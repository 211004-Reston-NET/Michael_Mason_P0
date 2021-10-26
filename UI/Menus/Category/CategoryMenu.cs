using System;

namespace UI
{
    public class CategoryMenu : IMenu
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
            Console.WriteLine("[1] Create a Category");
            Console.WriteLine("[2] List all Categories");
            Console.WriteLine("[3] Search for a Category");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.CategoryCreate;
                case "2":
                    return MenuType.CategoryList;
                case "3":
                    return MenuType.CategorySearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CategoryMenu;
            }
        }
    }
}