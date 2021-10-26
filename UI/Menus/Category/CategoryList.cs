using System;
using System.Collections.Generic;
using BL;
using DL;
using Models;

namespace UI
{
    public class CategoryList : IMenu
    {
        public static string categoryID;
        private CategoryBL _categoryBL;
        public CategoryList(CategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        public void Menu()
        {
            IEnumerable<Category> categories = _categoryBL.GetAll();

            Console.WriteLine("Category Listing");
            Console.WriteLine("----------------");
            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.CatNumber} | {category.CatName}");
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
                    categoryID = Console.ReadLine();
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