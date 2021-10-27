using System;
using BL;
using Models;

namespace UI
{
    public class CategoryView : IMenu
    {
        private static string exceptionMessage;
        public static CategoryModel catModel;
        private static ICategoryBL _catBL;
        public CategoryView(ICategoryBL catBL)
        {
            _catBL = catBL;
        }
        public void Menu()
        {
            if (CategorySearch.PKey != 0)
            {
                catModel = _catBL.GetModel(CategorySearch.PKey);
                CategorySearch.PKey = 0;
            }
            if (CategoryList.PKey != 0)
            {
                catModel = _catBL.GetModel(CategoryList.PKey);
                CategoryList.PKey = 0;
            }

            Console.WriteLine("Category View");
            Console.WriteLine($"Category: {catModel.Id} | {catModel.CatName}");
            Console.WriteLine("-------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify Name");
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
                            Console.WriteLine("Enter new Name");
                            catModel.CatName = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                        }
                    return MenuType.CategoryUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.CategoryMenu;
            }
        }
    }
}