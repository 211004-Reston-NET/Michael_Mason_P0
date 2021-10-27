using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class StorefrontBL : BusinessLogic<Storefront>, IStorefrontBL
    {
        public StorefrontBL(StorefrontRepository context) : base(context)
        {
        }

        public StorefrontRepository StoreRepo
        {
            get { return _context as StorefrontRepository; }
        }

        public StorefrontModel MapEntityToModel(Storefront entity, StorefrontModel model)
        {
            model.Id = entity.Id;
            model.StoreName = entity.StoreAddress;
            model.StorePhone = entity.StorePhone;
            //model.Inventories = entity.Inventories;
            //model.SOrders = entity.SOrders;
            return model;
        }

        public Storefront MapModelToEntity(Storefront entity, StorefrontModel model)
        {
            entity.Id = model.Id;
            entity.StoreName = model.StoreAddress;
            entity.StorePhone = model.StorePhone;
            //entity.Inventories = model.Inventories;
            //entity.SOrders = model.SOrders;
            return entity;
        }

        public StorefrontModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new StorefrontModel());
                return model;
        }

        public List<StorefrontModel> GetAllModel()
        {
            IEnumerable<Storefront> items = _context.GetAll();
            List<StorefrontModel> result = new List<StorefrontModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<StorefrontModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IEnumerable<Storefront> items = _context.Find(query);
            List<StorefrontModel> result = new List<StorefrontModel>();
            foreach (Storefront item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(StorefrontModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            var entity = MapModelToEntity(new Storefront(), model);
            StoreRepo.Create(entity);
        }

        public void UpdateModel(StorefrontModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            Storefront entity = StoreRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            StoreRepo.Update(entity);
        }
    }
}