using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class CategorySearch : IMenu
    {
        public static int PKey;
        private ICategoryBL _catBL;
        public CategorySearch(ICategoryBL catBL)
        {
            _catBL = catBL;
        }

        public void Menu()
        {
            Console.WriteLine("Enter Category Name");
            Console.WriteLine("-------------------");

            IEnumerable<CategoryModel> categories;
            string userInput = Console.ReadLine();
            
            categories = _catBL.FindModel(userInput);

            Console.WriteLine("-------------------");

            if (categories.Count() == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                foreach (CategoryModel category in categories)
                {
                    Console.WriteLine($"{category.PKey} | {category.CatName}");
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