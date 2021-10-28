using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class CategorySearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private ICategoryBL _catBL;
        public CategorySearch(ICategoryBL bl)
        {
            _catBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Category Name");
            Console.WriteLine("-------------------");

            IEnumerable<CategoryModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _catBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (CategoryModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.CatName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a search term");
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
                    try
                    {
                        Console.WriteLine("Enter Category Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.CategorySearch;
                    }
                    return MenuType.CategoryView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CategorySearch;
            }
        }
    }
}