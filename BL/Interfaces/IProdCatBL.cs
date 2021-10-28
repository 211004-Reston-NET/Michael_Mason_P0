using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public interface IProdCatBL : IBusinessLogic<ProdCat>
    {
        ProdCatModel MapEntityToModel(ProdCat entity, ProdCatModel model);
        ProdCat MapModelToEntity(ProdCat entity, ProdCatModel model);
        void CreateModel(ProdCatModel model);
        void UpdateModel(ProdCatModel model);
        ProdCatModel GetModel(int id);
        IEnumerable<ProdCatModel> GetAllModel();
        IList<ProdCatModel> FindModel(string query);
        void DeleteModel(ProdCatModel model);
        IQueryable<string> FindAndJoinCategories(int id);
        string FindProductName(int id);
    }
}