using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class CategoryList : IMenu
    {
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
                Console.WriteLine($"{category.PKey} | {category.CatName}");
            }
            Console.WriteLine("----------------");
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
                    Console.WriteLine("Enter Category ID");
                    string userInput = Console.ReadLine();
                    PKey = int.Parse(userInput);
                    return MenuType.CategoryView;
                default:
                    Console.WriteLine("INVALID SELECTION");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    return MenuType.CategoryList;
            }
        }
    }
}