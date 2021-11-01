using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Models;

namespace UserInterface
{
    public class ProductCreate : IMenu
    {
        private static ProductM productM = new ProductM();
        public static List<int> catList = new List<int>();
        private IQueryable<string> catNames;

        private static string exceptionMessage;
        private IProductBL BL;
        public ProductCreate(IProductBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a Product");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {productM.ProdName}");
            Console.WriteLine($"Price: {productM.ProdPrice}");
            Console.WriteLine($"Description: {productM.ProdDescription}");
            // foreach (var item in cats)
            // {
            //     Console.WriteLine(item);
            // }
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Product Number");
            Console.WriteLine("[2] Input Name");
            Console.WriteLine("[3] Input Product Price");
            Console.WriteLine("[4] Input Product Description");
            Console.WriteLine("[5] Choose Categories");
            Console.WriteLine("[6] Save Product");
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
                        Console.WriteLine("Enter Product Number");
                        // productM.ProdNumber = int.Parse(Console.ReadLine());
                        return MenuType.ProductCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProductCreate;
                    }
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Product Name");
                        productM.ProdName = Console.ReadLine();
                        return MenuType.ProductCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProductCreate;
                    }
                case "3":
                    try
                    {
                        Console.WriteLine("Enter Product Price");
                        productM.ProdPrice = decimal.Parse(Console.ReadLine());
                        return MenuType.ProductCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProductCreate;
                    }
                case "4":
                    try
                    {
                        Console.WriteLine("Enter Product Description");
                        productM.ProdDescription = Console.ReadLine();
                        return MenuType.ProductCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProductCreate;
                    }
                case "6":
                    try
                    {
                        // _prodBL.Create(productM, catList);
                        exceptionMessage = "Product saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.ProductCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.ProductCreate;
            }
        }
    }
}