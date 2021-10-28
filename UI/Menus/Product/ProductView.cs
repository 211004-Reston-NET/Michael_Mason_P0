using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class ProductView : IMenu
    {
        private static string exceptionMessage;
        public static ProductModel model;
        private static IProductBL _prodBL;
        public ProductView(IProductBL bl)
        {
            _prodBL = bl;
        }
        public void Menu()
        {
            if (ProductSearch.PKey != 0)
            {
                model = _prodBL.GetModel(ProductSearch.PKey);
                ProductSearch.PKey = 0;
            }
            if (ProductList.PKey != 0)
            {
                model = _prodBL.GetModel(ProductList.PKey);
                ProductList.PKey = 0;
            }

            Console.WriteLine("Product View");
            Console.WriteLine($"UPC: {model.ProdNumber}");
            Console.WriteLine($"Name: {model.ProdName}");
            Console.WriteLine($"Price: {model.ProdPrice}");
            Console.WriteLine($"Description: {model.ProdDescription}");
            List<int> catList = new List<int>();
            foreach (var item in _prodBL.FindProdCatByProdId(model.Id))
            {
                catList.Add(item.CatId);
            }
            var cats = _prodBL.GetProdCatNames(catList);
            foreach (var item in cats)
            {
                Console.WriteLine(item);
            }
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
                            model.ProdNumber = int.Parse(Console.ReadLine());
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
                            model.ProdName = Console.ReadLine();
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
                            model.ProdPrice = decimal.Parse(Console.ReadLine());
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
                            model.ProdDescription = Console.ReadLine();
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