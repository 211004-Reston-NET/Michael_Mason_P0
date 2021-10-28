using System;
using BL;

namespace UI
{
    public class ProductDelete : IMenu
    {
        private IProductBL _prodBL;
        public ProductDelete(IProductBL bl)
        {
            _prodBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {ProductView.model.ProdName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodBL.DeleteModel(ProductView.model);
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