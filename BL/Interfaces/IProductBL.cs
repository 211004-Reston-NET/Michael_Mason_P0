using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IProductBL : IBusinessLogic<Product>
    {
        ProductModel MapEntityToModel(Product entity, ProductModel model);
        Product MapModelToEntity(Product entity, ProductModel model);
        void CreateModel(ProductModel model);
        void UpdateModel(ProductModel model);
        ProductModel GetModel(int id);
        List<ProductModel> GetAllModel();
        List<ProductModel> FindModel(string query);
    }
}