using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class CategoryBL : BusinessLogic<Category>, ICategoryBL
    {
        public CategoryBL(CategoryRepository context) : base(context)
        {
        }
        
        public CategoryRepository CatRepo
        { 
            get {return _context as CategoryRepository;}
        }

        public CategoryModel MapEntityToModel(Category entity, CategoryModel model)
        {
            model.PKey = entity.Id;
            model.CatName = entity.CatName;
            return model;
        }

        public Category MapModelToEntity(Category entity, CategoryModel model)
        {
            
            entity.CatName = model.CatName;
            return entity;
        }

        public CategoryModel GetModel(int id)
        {
            var entity = _context.Get(id);
            var model = MapEntityToModel(entity, new CategoryModel());
            return model;
        }

        public List<CategoryModel> GetAllModel()
        {
            IEnumerable<Category> cats = _context.GetAll();
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (var item in cats)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<CategoryModel> FindModel(string query)
        {
            IEnumerable<Category> cats = _context.Find(query);
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (Category cat in cats)
            {
                result.Add(GetModel(cat.Id));
            }
            return result;
        }

        public void CreateModel(CategoryModel model)
        {
            var entity = MapModelToEntity(new Category(), model);
            CatRepo.Create(entity);
        }

        public void UpdateModel(CategoryModel model)
        {
            Category entity = CatRepo.Get(model.PKey);
            entity = MapModelToEntity(entity, model);
            CatRepo.Update(entity);
        }
    }
}