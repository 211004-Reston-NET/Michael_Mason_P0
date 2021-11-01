using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class ProductSearch : IMenu
    {
        private static string exceptionMessage;
        public static int prodId;
        private IProductBL BL;
        public ProductSearch(IProductBL bl)
        {
            BL = bl;
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

            IEnumerable<Product> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = BL.GetProductByName(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"{item.ProdId} | {item.ProdName}");
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
                        prodId = int.Parse(userInput);
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