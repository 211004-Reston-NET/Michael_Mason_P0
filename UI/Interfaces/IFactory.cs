using System;

namespace UI
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType menu);
    }
}