using System;
using Business;

namespace UserInterface
{
    public class ProductUpdate : IMenu
    {
        private static string exceptionMessage;
        private IProductBL BL;
        public ProductUpdate(IProductBL bl)
        {
            BL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------------");
                exceptionMessage = null;
            }
            Console.WriteLine($"Are you sure you want to update {ProductView.product.ProdName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Update(ProductView.product);
                    return MenuType.ProductList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProductUpdate;      
            }
        }
    }
}