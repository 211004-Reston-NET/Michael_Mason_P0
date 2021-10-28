using System;

namespace UI
{
    public class LineItemMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Line Items Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a Line Item");
            Console.WriteLine("[2] List all Line Items");
            Console.WriteLine("[3] Search for a Line Item");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.LineItemCreate;
                case "2":
                    return MenuType.LineItemList;
                case "3":
                    return MenuType.LineItemSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.LineItemMenu;
            }
        }
    }
}