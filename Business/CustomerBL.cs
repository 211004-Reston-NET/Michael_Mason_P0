using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public interface ICustomerBL : IBaseBL<Customer>
    {
        IEnumerable<Customer> SearchByAddress(string query);
        IEnumerable<Customer> SearchByName(string query);
        IEnumerable<Customer> SearchByPhone(int query);
        IEnumerable<Customer> SearchByEmail(string query);
        IEnumerable<SOrder> GetOrders(Customer entity);
    }

    public class CustomerBL : BaseBL<Customer>, ICustomerBL
    {
        public CustomerBL(IRepository<Customer> context) : base(context)
        {
        }

        public IEnumerable<Customer> SearchByName(string query)
        {
            return base.GetAll().Where(c => c.CustName.ToLower().Contains(query));
        }

        public IEnumerable<Customer> SearchByAddress(string query)
        {
            return base.GetAll().Where(c => c.CustAddress.ToLower().Contains(query));
        }

        public IEnumerable<Customer> SearchByPhone(int query)
        {
            return base.GetAll().Where(c => c.CustPhone.Equals(query));
        }

        public IEnumerable<Customer> SearchByEmail(string query)
        {
            return base.GetAll().Where(c => c.CustEmail.ToLower().Contains(query));
        }

        public IEnumerable<SOrder> GetOrders(Customer entity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext custBL = new StoreManagerContext(options);
            return custBL.SOrders.Where(o => o.CustNumber.Equals(entity.CustNumber));
        }
    }
}
