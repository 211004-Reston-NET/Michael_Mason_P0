using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class InventoryBL : BusinessLogic<Inventory>, IInventoryBL
    {
        public InventoryBL(InventoryRepository context) : base(context)
        {
        }

        public InventoryRepository InvRepo
        {
            get { return _context as InventoryRepository; }
        }

        public InventoryModel MapEntityToModel(Inventory entity, InventoryModel model)
        {
            model.Id = entity.Id;
            model.StoreId = entity.StoreId;
            model.ProdId = entity.ProdId;
            model.Quantity = entity.Quantity;
            //model.Prod = entity.Prod;
            //model.Store = entity.Store;
            return model;
        }

        public Inventory MapModelToEntity(Inventory entity, InventoryModel model)
        {

            entity.Id = model.Id;
            entity.StoreId = model.StoreId;
            entity.ProdId = model.ProdId;
            entity.Quantity = model.Quantity;
            //entity.Prod = model.Prod;
            //entity.Store = model.Store;
            return entity;
        }

        public InventoryModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new InventoryModel());
                return model;
        }

        public List<InventoryModel> GetAllModel()
        {
            IEnumerable<Inventory> items = _context.GetAll();
            List<InventoryModel> result = new List<InventoryModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<InventoryModel> FindModel(string query)
        {   /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IEnumerable<Inventory> items = _context.Find(query);
            List<InventoryModel> result = new List<InventoryModel>();
            foreach (Inventory item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(InventoryModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            var entity = MapModelToEntity(new Inventory(), model);
            InvRepo.Create(entity);
        }

        public void UpdateModel(InventoryModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            Inventory entity = InvRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            InvRepo.Update(entity);
        }
    }
}