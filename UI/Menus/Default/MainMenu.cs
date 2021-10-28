using System;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Categories Menu");
            Console.WriteLine("[2] Products Menu");
            Console.WriteLine("[3] ProdCats Menu");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ExitMenu;
                case "1":
                    return MenuType.CategoryMenu;
                case "2":
                    return MenuType.ProductMenu;
                case "3":
                    return MenuType.ProdCatMenu;
                default:
                    Console.WriteLine("INVALID SELECTION");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}