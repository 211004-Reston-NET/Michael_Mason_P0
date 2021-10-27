using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IInventoryBL : IBusinessLogic<Inventory>
    {
        InventoryModel MapEntityToModel(Inventory entity, InventoryModel model);
        Inventory MapModelToEntity(Inventory entity, InventoryModel model);
        void CreateModel(InventoryModel model);
        void UpdateModel(InventoryModel model);
        InventoryModel GetModel(int id);
        List<InventoryModel> GetAllModel();
        List<InventoryModel> FindModel(string query);
    }
}