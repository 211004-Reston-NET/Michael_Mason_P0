using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ICategoryBL : IBusinessLogic<Category>
    {
        CategoryModel MapEntityToModel(Category entity, CategoryModel model);
        Category MapModelToEntity(Category entity, CategoryModel model);
        void CreateModel(CategoryModel model);
        void UpdateModel(CategoryModel model);
        CategoryModel GetModel(int id);
        List<CategoryModel> GetAllModel();
        List<CategoryModel> FindModel(string query);
    }
}