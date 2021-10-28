using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class ProductSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private IProductBL _prodBL;
        public ProductSearch(IProductBL bl)
        {
            _prodBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Product Name");
            Console.WriteLine("-------------------");

            IEnumerable<ProductModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _prodBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (ProductModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.ProdName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a search term");
            }



            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search Again");
            Console.WriteLine("[2] View Product");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ProductMenu;
                case "1":
                    return MenuType.ProductSearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Product Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProductSearch;
                    }
                    return MenuType.ProductView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProductSearch;
            }
        }
    }
}