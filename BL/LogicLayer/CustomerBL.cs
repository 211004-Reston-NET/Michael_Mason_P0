using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class CustomerBL : BusinessLogic<Customer>, ICustomerBL
    {
        public CustomerBL(CustomerRepository context) : base(context)
        {
        }

        public CustomerRepository CustRepo
        {
            get { return _context as CustomerRepository; }
        }

        public CustomerModel MapEntityToModel(Customer entity, CustomerModel model)
        {
            model.Id = entity.Id;
            model.CustNumber = entity.CustNumber;
            model.CustName = entity.CustName;
            model.CustAddress = entity.CustAddress;
            model.CustEmail = entity.CustEmail;
            model.CustPhone = entity.CustPhone;
            //model.SOrders = entity.SOrders;
            return model;
        }

        public Customer MapModelToEntity(Customer entity, CustomerModel model)
        {

            entity.Id = model.Id;
            entity.CustNumber = model.CustNumber;
            entity.CustName = model.CustName;
            entity.CustAddress = model.CustAddress;
            entity.CustEmail = model.CustEmail;
            entity.CustPhone = model.CustPhone;
            //entity.SOrders = model.SOrders;
            return entity;
        }

        public CustomerModel GetModel(int id)
        {
                var entity = _context.Get(id);
                var model = MapEntityToModel(entity, new CustomerModel());
                return model;
        }

        public List<CustomerModel> GetAllModel()
        {
            IEnumerable<Customer> items = _context.GetAll();
            List<CustomerModel> result = new List<CustomerModel>();
            foreach (var item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public List<CustomerModel> FindModel(string query)
        {
            /*
            if (query == null)
            {
                throw new NullReferenceException("You must enter a search term");
            }
            */
            IEnumerable<Customer> items = _context.Find(query);
            List<CustomerModel> result = new List<CustomerModel>();
            foreach (Customer item in items)
            {
                result.Add(GetModel(item.Id));
            }
            return result;
        }

        public void CreateModel(CustomerModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            var entity = MapModelToEntity(new Customer(), model);
            CustRepo.Create(entity);
        }

        public void UpdateModel(CustomerModel model)
        {
            /*
            if (model.CatName == null)
            {
                throw new NullReferenceException("You must enter a name");
            }
            */
            Customer entity = CustRepo.Get(model.Id);
            entity = MapModelToEntity(entity, model);
            CustRepo.Update(entity);
        }
    }
}