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
            get { return _context as CategoryRepository; }
        }

        public CategoryModel MapEntityToModel(Category entity, CategoryModel model)
        {
            model.Id = entity.Id;
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
            IEnumerable<Category> items = _context.GetAll();
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<CategoryModel> FindModel(string query)
        {
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            IEnumerable<Category> items = _context.Find(query);
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (Category item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(CategoryModel model)
        {
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            var entity = MapModelToEntity(new Category(), model);
            CatRepo.Create(entity);
        }

        public void UpdateModel(CategoryModel model)
        {
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            Category entity = CatRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            CatRepo.Update(entity);
        }
    }
}