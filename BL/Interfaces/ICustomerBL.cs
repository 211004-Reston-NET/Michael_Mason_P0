using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ICustomerBL : IBusinessLogic<Customer>
    {
        CustomerModel MapEntityToModel(Customer entity, CustomerModel model);
        Customer MapModelToEntity(Customer entity, CustomerModel model);
        void CreateModel(CustomerModel model);
        void UpdateModel(CustomerModel model);
        CustomerModel GetModel(int id);
        List<CustomerModel> GetAllModel();
        List<CustomerModel> FindModel(string query);
    }
}