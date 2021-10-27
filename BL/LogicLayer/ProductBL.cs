using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class ProductBL : BusinessLogic<Product>, IProductBL
    {
        public ProductBL(ProductRepository context) : base(context)
        {
        }

        public ProductRepository ProdRepo
        {
            get { return _context as ProductRepository; }
        }

        public ProductModel MapEntityToModel(Product entity, ProductModel model)
        {
            model.PKey = entity.Id;
            model.ProdNumber = entity.ProdNumber;
            model.ProdName = entity.ProdName;
            model.ProdPrice = entity.ProdPrice;
            model.ProdDesc = entity.ProdDescription;
            return model;
        }

        public Product MapModelToEntity(Product entity, ProductModel model)
        {
            entity.Id = model.PKey;
            entity.ProdNumber = model.ProdNumber;
            entity.ProdName = model.ProdName;
            entity.ProdPrice = model.ProdPrice;
            entity.ProdDescription = model.ProdDesc;
            return entity;
        }

        public ProductModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new ProductModel());
                return model;
        }

        public List<ProductModel> GetAllModel()
        {
            IEnumerable<Product> items = _context.GetAll();
            List<ProductModel> result = new List<ProductModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<ProductModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IEnumerable<Product> items = _context.Find(query);
            List<ProductModel> result = new List<ProductModel>();
            foreach (Product item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(ProductModel model)
        {
            if (model.ProdName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            var entity = MapModelToEntity(new Product(), model);
            ProdRepo.Create(entity);
        }

        public void UpdateModel(ProductModel model)
        {
            if (model.ProdName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            Product entity = ProdRepo.Get(model.PKey);
            entity = MapModelToEntity(entity, model);
            ProdRepo.Update(entity);
        }
    }
}