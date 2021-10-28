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
        IEnumerable<CustomerModel> GetAllModel();
        IList<CustomerModel> FindModel(string query);

        void DeleteModel(CustomerModel model);
        
    }
}