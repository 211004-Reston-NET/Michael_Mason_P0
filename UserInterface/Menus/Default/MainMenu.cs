using System;

namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Customer Menu");
            Console.WriteLine("[2] Storefront Menu");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ExitMenu;
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StorefrontMenu;
                default:
                    Console.WriteLine("INVALID SELECTION");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}