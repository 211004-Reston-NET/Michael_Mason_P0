using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public interface ISOrderBL : IBaseBL<SOrder>
    {
        IEnumerable<SOrder> GetOrdersByCustomer(Customer entity);
        IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity);
        IEnumerable<Storefront> ListAllStores();
        Customer GetCustomerByEmail(string email);
    }

    public class SOrderBL : BaseBL<SOrder>, ISOrderBL
    {
        public SOrderBL(IRepository<SOrder> context) : base(context)
        {
        }

        public IEnumerable<SOrder> GetOrdersByStorefront(Storefront entity)
        {
            return base.GetAll().Where(s => s.StoreNumber.Equals(entity.StoreNumber));
        }

        public IEnumerable<SOrder> GetOrdersByCustomer(Customer entity)
        {
            return base.GetAll().Where(s => s.CustNumber.Equals(entity.CustNumber));
        }

        public IEnumerable<Storefront> ListAllStores()
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext storeBL = new StoreManagerContext(options);
            return storeBL.Set<Storefront>();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext custBL = new StoreManagerContext(options);
            return custBL.Customers.Single(c => c.CustEmail.ToLower().Equals(email.ToLower()));
        }
    }
}