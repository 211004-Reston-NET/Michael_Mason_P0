using System;
using System.Collections.Generic;
using System.Linq;
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
            model.Id = entity.Id;
            model.ProdNumber = entity.ProdNumber;
            model.ProdName = entity.ProdName;
            model.ProdPrice = entity.ProdPrice;
            model.ProdDescription = entity.ProdDescription;
            model.ProdCats = entity.ProdCats;
            model.LineItems = entity.LineItems;
            model.Inventories = entity.Inventories;
            return model;
        }

        public Product MapModelToEntity(Product entity, ProductModel model)
        {
            entity.ProdNumber = model.ProdNumber;
            entity.ProdName = model.ProdName;
            entity.ProdPrice = model.ProdPrice;
            entity.ProdDescription = model.ProdDescription;
            entity.ProdCats = model.ProdCats;
            entity.LineItems = model.LineItems;
            entity.Inventories = model.Inventories;
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

        public IList<ProductModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IEnumerable<Product> items = _context.Find(query);
            IList<ProductModel> result = new List<ProductModel>();
            foreach (Product item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(ProductModel model, List<int> catList)
        {
            if (model == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            var entity = MapModelToEntity(new Product(), model);
            ProdRepo.Create(entity);
            foreach (var item in catList)
            {
                Category cat = ProdRepo.StoreManagerContext.Categories.Single(c => c.Id.Equals(item));
                ProdCat pc = new ProdCat()
                {
                    Prod = entity,
                    Cat = cat
                };
                ProdRepo.StoreManagerContext.ProdCats.Add(pc);
                ProdRepo.StoreManagerContext.SaveChanges();
            }
        }

        public void UpdateModel(ProductModel model)
        {
            if (model.ProdName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            Product entity = ProdRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            ProdRepo.Update(entity);
        }

        public void DeleteModel(ProductModel model)
        {
            Product entity = ProdRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            ProdRepo.Delete(entity);
        }

        public IQueryable<ProdCat> FindProdCatByProdId(int id)
        {
            return ProdRepo.FindProdCatByProdId(id);
        }

        public ICollection<string> GetProdCatNames(List<int> idList)
        {
            return ProdRepo.GetProdCatNames(idList);
        }
    }
}