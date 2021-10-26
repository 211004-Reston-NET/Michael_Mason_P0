using System;
using DL;
using Models;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new MenuFactory();
            IMenu page = factory.GetMenu(MenuType.MainMenu);
            
            while (true)
            {
                Console.Clear();
                page.Menu();
                MenuType currentMenu = page.UserSelection();
                page = factory.GetMenu(currentMenu);
            }
        }
    }
}
