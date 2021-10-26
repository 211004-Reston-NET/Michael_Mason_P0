using System;
namespace UI
{
    public class ExitMenu : IMenu
    {
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine("Are you sure you want to exit?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    Environment.Exit(0);
                    return MenuType.ExitMenu;
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