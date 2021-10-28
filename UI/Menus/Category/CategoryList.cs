using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class CategoryList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private ICategoryBL _catBL;
        public CategoryList(ICategoryBL bl)
        {
            _catBL = bl;
        }

        public void Menu()
        {
            IEnumerable<CategoryModel> items = _catBL.GetAllModel();

            Console.WriteLine("Category Listing");
            Console.WriteLine("----------------");
            foreach (CategoryModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.CatName}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Categories Menu");
            Console.WriteLine("[1] Select Category");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CategoryMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter Category ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "Category added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.CategoryList;
                        }
                    return MenuType.CategoryList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CategoryList;
            }
        }
    }
}