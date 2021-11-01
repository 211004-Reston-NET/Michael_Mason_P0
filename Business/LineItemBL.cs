using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public interface ILineItemBL : IBaseBL<LineItem>
    {
        IEnumerable<LineItem> GetLineItemByOrder(SOrder entity);
        Product GetProductByProdId(int prodId);
        IEnumerable<Product> ListAllProducts(int storeId);
        IEnumerable<Storefront> ListAllStores();
        string CreateOrder(SOrder order);
        void UpdateInventory(int orderId);
        void UpdateTotalPrice(int orderId);
        int CheckInventory(int storeId, int prodId, int quantity);
    }

    public class LineItemBL : BaseBL<LineItem>, ILineItemBL
    {
        public LineItemBL(IRepository<LineItem> context) : base(context)
        {
        }

        public IEnumerable<LineItem> GetLineItemByOrder(SOrder entity)
        {
            return base.GetAll().Where(l => l.OrderId.Equals(entity.OrderId));
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

        public IEnumerable<Product> ListAllProducts(int storeId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;

            StoreManagerContext prodBL = new StoreManagerContext(options);
            return (from prod in prodBL.Products
                    join inv in prodBL.Inventories
                    on prod.ProdId equals inv.ProdId
                    where storeId == inv.StoreNumber
                    select prod);
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

        public Storefront GetStorefrontById(int storeId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;

            StoreManagerContext storeBL = new StoreManagerContext(options);
            return storeBL.Storefronts.Single(s => s.StoreNumber.Equals(storeId));
        }

        public string CreateOrder(SOrder order)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;

            StoreManagerContext sOrderBL = new StoreManagerContext(options);
            sOrderBL.Add(order);
            return "order created";
        }

        public void UpdateTotalPrice(int orderId)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;

            StoreManagerContext sOrderBL = new StoreManagerContext(options);
            StoreManagerContext prodBL = new StoreManagerContext(options);
            var order = sOrderBL.SOrders.Single(o => o.OrderId.Equals(orderId));
            var lines = base.GetAll().Where(l => l.OrderId.Equals(orderId));
            foreach (var item in lines)
            {
                var prod = prodBL.Products.Single(p => p.ProdId.Equals(item.ProdId));
                order.TotalPrice += item.Quantity * prod.ProdPrice;
            }
            sOrderBL.SaveChanges();
        }

        public void UpdateInventory(int orderId)
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
                inv.Quantity -= item.Quantity;
            }
            invBL.SaveChanges();
        }

        public int CheckInventory(int storeId, int prodId, int quantity)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration
            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                    .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                    .Options;
            StoreManagerContext invBL = new StoreManagerContext(options);
            var query =  invBL.Inventories.Single(c => c.StoreNumber.Equals(storeId) && c.ProdId.Equals(prodId));
            return query.Quantity;
        }
    }
}