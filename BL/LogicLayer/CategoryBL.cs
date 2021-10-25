using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class CategoryBL : BusinessLogic<Category>, ICategoryBL
    {
        private CategoryRepository _context;
        public CategoryBL(CategoryRepository context) : base(context)
        {
            _context = context;
        }

        public override void Create(Category entity)
        {
            entity.CatNumber = GetHighestCatNum() + 1;
            _context.Create(entity);
        }

        public override void Delete(Category entity)
        {
            IEnumerable<Category> all = base.GetAll();
            foreach (Category item in all)
            {
                if (item.CatNumber > entity.CatNumber)
                {
                    item.CatNumber -= 1;
                }
            }
            base.Delete(entity);
        }

        public int GetHighestCatNum()
        {
            return _context.GetHighestCatNum();
        }

        public CategoryModel ModelMap(Category entity, CategoryModel model)
        {
            entity.CatNumber = model.CatNumber;
            entity.CatName = model.CatName;
            return model;
        }
    }
}