using System;
using BL;
using Models;

namespace UI
{
    public class CategoryCreate : IMenu
    {
        private static CategoryModel newModel = new CategoryModel();
        private static string exceptionMessage;
        private ICategoryBL _catBL;
        public CategoryCreate(ICategoryBL catbl)
        {
            _catBL = catbl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a Category");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.CatName}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save Category");
            Console.WriteLine("-----------------");
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
                        Console.WriteLine("Enter the Category Name");
                        newModel.CatName = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.CategoryCreate;
                case "2":
                    try
                    {
                        _catBL.CreateModel(newModel);
                        newModel.CatName = Console.ReadLine();
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.CategoryCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CategoryCreate;
            }
        }
    }
}