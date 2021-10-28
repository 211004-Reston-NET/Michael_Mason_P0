using System;
using BL;

namespace UI
{
    public class ProductUpdate : IMenu
    {
        private static string exceptionMessage;
        private IProductBL _prodBL;
        public ProductUpdate(IProductBL bl)
        {
            _prodBL = bl;
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
            Console.WriteLine($"Are you sure you want to update {ProductView.model.ProdName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodBL.UpdateModel(ProductView.model);
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