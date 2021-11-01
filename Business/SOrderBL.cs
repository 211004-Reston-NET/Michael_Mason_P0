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
        IEnumerable<LineItem> GetLineItemsByOrder(SOrder entity);
        Customer GetCustomerById(int custId);
        Storefront GetStorefrontById(int custId);
        Product GetProductById(int prodId);
        void UpdateInventoryOnCancel(int orderId);
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

        public Customer GetCustomerById(int custId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext custBL = new StoreManagerContext(options);
            return custBL.Customers.Single(c => c.CustNumber.Equals(custId));
        }
        public Product GetProductById(int prodId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext pBL = new StoreManagerContext(options);
            return pBL.Products.Single(p => p.ProdId.Equals(prodId));
        }

        public IEnumerable<LineItem> GetLineItemsByOrder(SOrder entity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext liBL = new StoreManagerContext(options);
            return liBL.LineItems.Where(l => l.OrderId.Equals(entity.OrderId));
        }

        public Storefront GetStorefrontById(int storeId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
                    
            StoreManagerContext sBL = new StoreManagerContext(options);
            return sBL.Storefronts.Single(c => c.StoreNumber.Equals(storeId));
        }

        public void UpdateInventoryOnCancel(int orderId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
            StoreManagerContext invBL = new StoreManagerContext(options);
            StoreManagerContext ordBL = new StoreManagerContext(options);
            var lines = ordBL.LineItems.Where(l => l.OrderId.Equals(orderId));
            foreach (var item in lines)
            {
                var inv = invBL.Inventories.Single(i => i.ProdId.Equals(item.ProdId));
                inv.Quantity += item.Quantity;
            }
            invBL.SaveChanges();
        }
    }
}