using System;

namespace UI
{
    public class ProdCatMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("ProdCats Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a ProdCat");
            Console.WriteLine("[2] List all ProdCats");
            Console.WriteLine("[3] Search for a ProdCat");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ProdCatCreate;
                case "2":
                    return MenuType.ProdCatList;
                case "3":
                    return MenuType.ProdCatSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProdCatMenu;
            }
        }
    }
}