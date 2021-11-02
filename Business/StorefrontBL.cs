using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public interface IStorefrontBL : IBaseBL<Storefront>
    {
        IEnumerable<Storefront> SearchStorefrontsByName(string query);
        IEnumerable<Storefront> SearchStorefrontsByAddress(string query);
        IEnumerable<Inventory> GetInventoryByStore(int storeId);
        Product GetProductByProdId(int prodId);
        string UpdateInventory(int invId, int quantity);
        IEnumerable<SOrder> GetOrdersByStore(Storefront entity);
        Customer GetCustomerByOrder(SOrder entity);
    }

    public class StorefrontBL : BaseBL<Storefront>, IStorefrontBL
    {
        public StorefrontBL(IRepository<Storefront> context) : base(context)
        {
        }

        public IEnumerable<Storefront> SearchStorefrontsByAddress(string query)
        {
            return base.GetAll().Where(s => s.StoreAddress.ToLower().Contains(query.ToLower()));
        }

        public IEnumerable<Storefront> SearchStorefrontsByName(string query)
        {
            return base.GetAll().Where(s => s.StoreName.ToLower().Contains(query.ToLower()));
        }

        public IEnumerable<Inventory> GetInventoryByStore(int storeId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext invBL = new StoreManagerContext(options);
            return invBL.Inventories.Where(p => p.StoreNumber.Equals(storeId));
        }

        public Product GetProductByProdId(int prodId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext prodBL = new StoreManagerContext(options);
            return prodBL.Products.Single(p => p.ProdId.Equals(prodId));
        }

        public string UpdateInventory(int invId, int quantity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext invBL = new StoreManagerContext(options);
            var inv = invBL.Inventories.Single(p => p.InvId.Equals(invId));
            inv.Quantity = quantity;
            invBL.SaveChanges();
            return "Quantity updated";
        }

        public IEnumerable<SOrder> GetOrdersByStore(Storefront entity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext storeBL = new StoreManagerContext(options);
            return storeBL.SOrders.Where(o => o.StoreNumber.Equals(entity.StoreNumber));
        }
        public Customer GetCustomerByOrder(SOrder entity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext custBL = new StoreManagerContext(options);
            return custBL.Customers.Single(o => o.CustNumber.Equals(entity.CustNumber));
        }
    }
}
