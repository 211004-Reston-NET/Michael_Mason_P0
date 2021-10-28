using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IStorefrontBL : IBusinessLogic<Storefront>
    {
        StorefrontModel MapEntityToModel(Storefront entity, StorefrontModel model);
        Storefront MapModelToEntity(Storefront entity, StorefrontModel model);
        void CreateModel(StorefrontModel model);
        void UpdateModel(StorefrontModel model);
        StorefrontModel GetModel(int id);
        IEnumerable<StorefrontModel> GetAllModel();
        IList<StorefrontModel> FindModel(string query);
        void DeleteModel(StorefrontModel model);
    }
}