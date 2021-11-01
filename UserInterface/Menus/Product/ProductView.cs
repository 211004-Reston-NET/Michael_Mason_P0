using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class ProductView : IMenu
    {
        private static string exceptionMessage;
        public static Product product;
        private static IProductBL BL;
        public ProductView(IProductBL bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            if (ProductSearch.prodId != 0)
            {
                product = BL.GetById(ProductSearch.prodId);
                ProductSearch.prodId = 0;
            }
            if (ProductList.prodID != 0)
            {
                product = BL.GetById(ProductList.prodID);
                ProductList.prodID = 0;
            }

            Console.WriteLine("Product View");
            Console.WriteLine($"Name: {product.ProdName}");
            Console.WriteLine($"Price: {product.ProdPrice}");
            Console.WriteLine($"Description: {product.ProdDescription}");
            List<int> catList = new List<int>();
            
            Console.WriteLine("-------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify UPC");
            Console.WriteLine("[2] Modify Name");
            Console.WriteLine("[3] Modify Price");
            Console.WriteLine("[4] Modify Description");
            Console.WriteLine("[5] Save changes");
            Console.WriteLine("[6] Delete Product");
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
                            Console.WriteLine("Enter new UPC");
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                        }
                    return MenuType.ProductView;
                case "2":
                        try
                        {
                            Console.WriteLine("Enter new Name");
                            product.ProdName = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                        }
                    return MenuType.ProductView;
                case "3":
                        try
                        {
                            Console.WriteLine("Enter new Price");
                            product.ProdPrice = decimal.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                        }
                    return MenuType.ProductView;
                case "4":
                        try
                        {
                            Console.WriteLine("Enter new Description");
                            product.ProdDescription = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                        }
                    return MenuType.ProductView;
                case "5":
                    return MenuType.ProductUpdate;
                case "6":
                    return MenuType.ProductDelete;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.ProductMenu;
            }
        }
    }
}