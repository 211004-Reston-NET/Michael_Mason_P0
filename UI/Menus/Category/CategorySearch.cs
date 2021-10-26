using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using DL;
using Models;

namespace UI
{
    public class CategorySearch : IMenu
    {
        public static string catNum;
        private CategoryBL _categoryBL;
        public CategorySearch(CategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        public void Menu()
        {
            Console.WriteLine("Enter Category Name");
            Console.WriteLine("-------------------");

            string userInput = Console.ReadLine();
            IEnumerable<Category> categories;

            categories = _categoryBL.Find(userInput);

            Console.WriteLine("-------------------");

            if (categories.Count() == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                foreach (Category category in categories)
                {
                    Console.WriteLine($"{category.CatNumber} | {category.CatName}");
                }
            }

            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search Again");
            Console.WriteLine("[2] View Category");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CategoryMenu;
                case "1":
                    return MenuType.CategorySearch;
                case "2":
                    Console.WriteLine("Enter Category Number");
                    catNum = Console.ReadLine();
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