using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public interface IProductBL : IBusinessLogic<Product>
    {
        ProductModel MapEntityToModel(Product entity, ProductModel model);
        Product MapModelToEntity(Product entity, ProductModel model);
        void CreateModel(ProductModel model, List<int> catList);
        void UpdateModel(ProductModel model);
        ProductModel GetModel(int id);
        List<ProductModel> GetAllModel();
        IList<ProductModel> FindModel(string query);
        void DeleteModel(ProductModel model);
        IQueryable<ProdCat> FindProdCatByProdId(int id);
        ICollection<string> GetProdCatNames(List<int> idList);

    }
}