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
            Console.WriteLine("[4] Inventory Menu");
            Console.WriteLine("[5] Customer Menu");
            Console.WriteLine("[6] Storefront Menu");
            Console.WriteLine("[7] Order Menu");
            Console.WriteLine("[8] Line Item Menu");
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
                case "4":
                    return MenuType.InventoryMenu;
                case "5":
                    return MenuType.CustomerMenu;
                case "6":
                    return MenuType.StorefrontMenu;
                case "7":
                    return MenuType.SOrderMenu;
                case "8":
                    return MenuType.LineItemMenu;
                default:
                    Console.WriteLine("INVALID SELECTION");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}