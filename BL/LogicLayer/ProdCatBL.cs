using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class ProdCatBL : BusinessLogic<ProdCat>, IProdCatBL
    {
        public ProdCatBL(ProdCatRepository context) : base(context)
        {
        }

        public ProdCatRepository ProdCatRepo
        {
            get { return _context as ProdCatRepository; }
        }

        public ProdCatModel MapEntityToModel(ProdCat entity, ProdCatModel model)
        {
            model.Id = entity.Id;
            model.ProdId = entity.ProdId;
            model.CatId = entity.CatId;
            model.Prod = entity.Prod;
            model.Cat = entity.Cat;
            return model;
        }

        public ProdCat MapModelToEntity(ProdCat entity, ProdCatModel model)
        {
            entity.Id = model.Id;
            entity.ProdId = model.ProdId;
            entity.CatId = model.CatId;
            entity.Prod = model.Prod;
            entity.Cat = model.Cat;
            return entity;
        }

        public ProdCatModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new ProdCatModel());
                return model;
        }

        public IEnumerable<ProdCatModel> GetAllModel()
        {
            IEnumerable<ProdCat> items = _context.GetAll();
            IList<ProdCatModel> result = new List<ProdCatModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public IList<ProdCatModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IQueryable<ProdCat> items = _context.Find(query);
            IList<ProdCatModel> result = new List<ProdCatModel>();
            foreach (ProdCat item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(ProdCatModel model)
        {
            //if (model. == null)
            //{
            //    throw new NullReferenceException("You must enter a name");
            //}
            var entity = MapModelToEntity(new ProdCat(), model);
            ProdCatRepo.Create(entity);
        }

        public void UpdateModel(ProdCatModel model)
        {
            //if (model.CatName == null)
            //{
            //    throw new NullReferenceException("You must enter a name");
            //}
            ProdCat entity = ProdCatRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            ProdCatRepo.Update(entity);
        }

        public void DeleteModel(ProdCatModel model)
        {
            ProdCat entity = ProdCatRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            ProdCatRepo.Delete(entity);
        }

        public IQueryable<string> FindAndJoinCategories(int id)
        {
            return ProdCatRepo.FindAndJoinCategories(id);
        }

        public string FindProductName(int id)
        {
            return ProdCatRepo.FindProductName(id);
        }
    }
}