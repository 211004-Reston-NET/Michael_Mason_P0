using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class ProductList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private IProductBL _prodBL;
        public ProductList(IProductBL bl)
        {
            _prodBL = bl;
        }

        public void Menu()
        {
            

            Console.WriteLine("Product Listing");
            Console.WriteLine("----------------");
            foreach (ProductModel item in _prodBL.GetAllModel())
            {
                Console.WriteLine($"{item.Id} | {item.ProdName}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Categories Menu");
            Console.WriteLine("[1] Select Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ProductMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter Product ID");
                            string userInput = Console.ReadLine();
                            PKey = int.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.ProductList;
                        }
                    return MenuType.ProductView;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProductList;
            }
        }
    }
}