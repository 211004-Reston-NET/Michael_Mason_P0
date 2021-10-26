using System;
using BL;

namespace UI
{
    public class CategoryUpdate : IMenu
    {
        private ICategoryBL _catBL;
        public CategoryUpdate(ICategoryBL catBL)
        {
            _catBL = catBL;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to update {CategoryView.catModel.CatName}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _catBL.UpdateModel(CategoryView.catModel);
                    return MenuType.CategoryList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ExitMenu;      
            }
        }
    }
}