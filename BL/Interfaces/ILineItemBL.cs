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
        IEnumerable<LineItemModel> GetAllModel();
        IList<LineItemModel> FindModel(string query);

        void DeleteModel(LineItemModel model);
    }
}