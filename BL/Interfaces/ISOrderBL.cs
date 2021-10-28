using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ISOrderBL : IBusinessLogic<SOrder>
    {
        SOrderModel MapEntityToModel(SOrder entity, SOrderModel model);
        SOrder MapModelToEntity(SOrder entity, SOrderModel model);
        void CreateModel(SOrderModel model);
        void UpdateModel(SOrderModel model);
        SOrderModel GetModel(int id);
        IEnumerable<SOrderModel> GetAllModel();
        IList<SOrderModel> FindModel(string query);
    }
}