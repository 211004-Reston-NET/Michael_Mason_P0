using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class LineItemBL : BusinessLogic<LineItem>, ILineItemBL
    {
        public LineItemBL(LineItemRepository context) : base(context)
        {
        }

        public LineItemRepository LineItemRepo
        {
            get { return _context as LineItemRepository; }
        }

        public LineItemModel MapEntityToModel(LineItem entity, LineItemModel model)
        {
            model.Id = entity.Id;
            model.OrderId = entity.OrderId;
            model.ProdId = entity.ProdId;
            model.Quantity = entity.Quantity;
            //model.Order = entity.Order;
            //model.Prod = entity.Prod;
            return model;
        }

        public LineItem MapModelToEntity(LineItem entity, LineItemModel model)
        {
            entity.Id = model.Id;
            entity.OrderId = model.OrderId;
            entity.ProdId = model.ProdId;
            entity.Quantity = model.Quantity;
            //entity.Order = model.Order;
            //entity.Prod = model.Prod;
            return entity;
        }

        public LineItemModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new LineItemModel());
                return model;
        }

        public IEnumerable<LineItemModel> GetAllModel()
        {
            IEnumerable<LineItem> items = _context.GetAll();
            IList<LineItemModel> result = new List<LineItemModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public IList<LineItemModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IQueryable<LineItem> items = _context.Find(query);
            IList<LineItemModel> result = new List<LineItemModel>();
            foreach (LineItem item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(LineItemModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            var entity = MapModelToEntity(new LineItem(), model);
            LineItemRepo.Create(entity);
        }

        public void UpdateModel(LineItemModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            LineItem entity = LineItemRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            LineItemRepo.Update(entity);
        }

        public void DeleteModel(LineItemModel model)
        {
            LineItem entity = LineItemRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            LineItemRepo.Delete(entity);
        }
    }
}