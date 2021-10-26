using System;
using BL;
using Models;

namespace UI
{
    public class CategoryCreate : IMenu
    {
        private static CategoryModel newModel = new CategoryModel();
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
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save Category");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CategoryMenu;
                case "1":
                    Console.WriteLine("Enter the Category Name");
                    newModel.CatName = Console.ReadLine();
                    return MenuType.CategoryCreate;
                case "2":
                    _catBL.CreateModel(newModel);
                    newModel.CatName = null;
                    return MenuType.CategoryCreate;
                default:
                    Console.WriteLine(".....INVALID SELECTION...");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    return MenuType.CategoryCreate;
            }
        }
    }
}