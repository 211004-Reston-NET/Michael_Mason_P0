using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ILineItemBL : IBusinessLogic<LineItem>
    {
        LineItemModel MapEntityToModel(LineItem entity, LineItemModel model);
        LineItem MapModelToEntity(LineItem entity, LineItemModel model);
        void CreateModel(LineItemModel model);
        void UpdateModel(LineItemModel model);
        LineItemModel GetModel(int id);
        List<LineItemModel> GetAllModel();
        List<LineItemModel> FindModel(string query);
    }
}