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

        private ICategoryBL _categoryBL;
        public CategoryList(ICategoryBL catBL)
        {
            _categoryBL = catBL;
        }

        public void Menu()
        {
            IEnumerable<CategoryModel> categories = _categoryBL.GetAllModel();

            Console.WriteLine("Category Listing");
            Console.WriteLine("----------------");
            foreach (CategoryModel category in categories)
            {
                Console.WriteLine($"{category.Id} | {category.CatName}");
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
                            PKey = int.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.CategoryList;
                        }
                    return MenuType.CategoryView;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CategoryList;
            }
        }
    }
}