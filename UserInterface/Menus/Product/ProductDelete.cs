using System;
using Business;

namespace UserInterface
{
    public class ProductDelete : IMenu
    {
        private IProductBL BL;
        public ProductDelete(IProductBL bl)
        {
            BL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {ProductView.product.ProdName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Delete(ProductView.product);
                    return MenuType.ProductList;
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