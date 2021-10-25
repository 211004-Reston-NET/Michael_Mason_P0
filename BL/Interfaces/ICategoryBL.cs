using System;
using DL;
using Models;

namespace BL
{
    public interface ICategoryBL : IBusinessLogic<Category>
    {
        int GetHighestCatNum();
        CategoryModel ModelMap(Category entity, CategoryModel model);
    }
}