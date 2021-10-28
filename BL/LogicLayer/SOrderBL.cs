using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class SOrderBL : BusinessLogic<SOrder>, ISOrderBL
    {
        public SOrderBL(SOrderRepository context) : base(context)
        {
        }

        public SOrderRepository SOrderRepo
        {
            get { return _context as SOrderRepository; }
        }

        public SOrderModel MapEntityToModel(SOrder entity, SOrderModel model)
        {
            model.Id = entity.Id;
            model.StoreId = entity.StoreId;
            model.CustId = entity.CustId;
            model.OrderNumber = entity.OrderNumber;
            model.TotalPrice = entity.TotalPrice;
            model.Cust = entity.Cust;
            model.Store = entity.Store;
            model.LineItems = entity.LineItems;
            return model;
        }

        public SOrder MapModelToEntity(SOrder entity, SOrderModel model)
        {
            entity.Id = model.Id;
            entity.StoreId = model.StoreId;
            entity.CustId = model.CustId;
            entity.OrderNumber = model.OrderNumber;
            entity.TotalPrice = model.TotalPrice;
            entity.Cust = model.Cust;
            entity.Store = model.Store;
            entity.LineItems = model.LineItems;
            return entity;
        }

        public SOrderModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new SOrderModel());
                return model;
        }

        public IEnumerable<SOrderModel> GetAllModel()
        {
            IEnumerable<SOrder> items = _context.GetAll();
            IList<SOrderModel> result = new List<SOrderModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public IList<SOrderModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IQueryable<SOrder> items = _context.Find(query);
            IList<SOrderModel> result = new List<SOrderModel>();
            foreach (SOrder item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(SOrderModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            var entity = MapModelToEntity(new SOrder(), model);
            SOrderRepo.Create(entity);
        }

        public void UpdateModel(SOrderModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            SOrder entity = SOrderRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            SOrderRepo.Update(entity);
        }
    }
}