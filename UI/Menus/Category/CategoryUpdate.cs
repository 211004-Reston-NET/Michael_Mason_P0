using System;
using BL;

namespace UI
{
    public class CategoryUpdate : IMenu
    {
        private static string exceptionMessage;
        private ICategoryBL _catBL;
        public CategoryUpdate(ICategoryBL bl)
        {
            _catBL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------------");
                exceptionMessage = null;
            }
            Console.WriteLine($"Are you sure you want to update {CategoryView.model.CatName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _catBL.UpdateModel(CategoryView.model);
                    return MenuType.CategoryList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.CategoryUpdate;      
            }
        }
    }
}