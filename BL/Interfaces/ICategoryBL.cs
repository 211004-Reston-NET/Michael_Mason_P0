using System;
using DL;
using Models;

namespace BL
{
    public interface ICategoryBL : IBusinessLogic<Category>
    {
        CategoryModel MapEntityToModel(Category entity, CategoryModel model);
        Category MapModelToEntity(Category entity, CategoryModel model);
        int GetHighestCatNum();
        void Create(CategoryModel model);
        void Delete(CategoryModel model);
        void Update(CategoryModel model);
    }
}