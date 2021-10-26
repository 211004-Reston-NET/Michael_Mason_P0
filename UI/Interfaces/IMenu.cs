using System;

namespace UI
{
    public enum MenuType
    {
        MainMenu,
        ExitMenu,

        //PRODUCT
        CategoryMenu,
        CategoryCreate,
        CategoryList,
        CategorySearch,
        CategoryView,
        CategoryUpdate,
    }

    public interface IMenu
    {
        void Menu();
        MenuType UserSelection();
    }
}