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
            entity.CatNumber = model.CatNumber;
            entity.CatName = model.CatName;
            return model;
        }

        public Category MapModelToEntity(Category entity, CategoryModel model)
        {
            model.CatNumber = entity.CatNumber;
            model.CatName = entity.CatName;
            return entity;
        }

        public int GetHighestCatNum()
        {
            return CatRepo.GetHighestCatNum();
        }

        public void Create(CategoryModel model)
        {
            using (var unitOfWork = new CategoryUOW(new CategoryRepository(new StoreManagerContext())))
            {
                var entity = MapModelToEntity(new Category(), model);
                entity.CatNumber = GetHighestCatNum() + 1;
                CatRepo.Create(entity);
                unitOfWork.Complete();
            }
        }

        public void Delete(CategoryModel model)
        {
            using (var unitOfWork = new CategoryUOW(new CategoryRepository(new StoreManagerContext())))
            {
                var entity = MapModelToEntity(new Category(), model);
                IEnumerable<Category> all = base.GetAll();
                foreach (Category item in all)
                {
                    if (item.CatNumber > entity.CatNumber)
                    {
                        item.CatNumber -= 1;
                    }
                }
                CatRepo.Delete(entity);
                unitOfWork.Complete();
            }
        }

        public void Update(CategoryModel model)
        {
            using (var unitOfWork = new CategoryUOW(new CategoryRepository(new StoreManagerContext())))
            {
                Category entity = CatRepo.GetByCatNum(model.CatNumber);
                var newEntity = MapModelToEntity(entity, model);
                unitOfWork.Complete();
            }
        }
    }
}