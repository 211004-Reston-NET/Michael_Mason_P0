using System;
using System.Collections.Generic;
using Business;
using Models;

namespace UserInterface
{
    public class ProductList : IMenu
    {
        private static string exceptionMessage;
        public static int prodID;

        private IProductBL BL;
        public ProductList(IProductBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            

            Console.WriteLine("Product Listing");
            Console.WriteLine("----------------");
            foreach (var item in BL.GetAll())
            {
                Console.WriteLine($"{item.ProdId} | {item.ProdName}");
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
                            prodID = int.Parse(userInput);
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