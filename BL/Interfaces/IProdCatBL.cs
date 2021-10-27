using System;
using System.Collections.Generic;
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
        List<ProdCatModel> GetAllModel();
        List<ProdCatModel> FindModel(string query);
    }
}