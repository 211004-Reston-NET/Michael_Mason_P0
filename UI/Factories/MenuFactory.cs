using System;
using BL;
using DL;

namespace UI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType menu)
        {
            switch (menu)
            {
                // DEFAULT
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.ExitMenu:
                    return new ExitMenu();
                
                // CATEGORY
                case MenuType.CategoryMenu:
                    return new CategoryMenu();
                case MenuType.CategoryCreate:
                    return new CategoryCreate(new CategoryBL(new CategoryRepository(new StoreManagerContext())));
                case MenuType.CategoryList:
                    return new CategoryList(new CategoryBL(new CategoryRepository(new StoreManagerContext())));
                case MenuType.CategorySearch:
                    return new CategorySearch(new CategoryBL(new CategoryRepository(new StoreManagerContext())));
                case MenuType.CategoryView:
                    return new CategoryView(new CategoryBL(new CategoryRepository(new StoreManagerContext())));
                case MenuType.CategoryUpdate:
                    return new CategoryUpdate(new CategoryBL(new CategoryRepository(new StoreManagerContext())));
                default:
                    return new MainMenu();

                // PRODUCT
            }
        }
    }
}