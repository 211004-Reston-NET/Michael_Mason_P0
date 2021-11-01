using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Business
{
    public interface IInventoryBl : IBaseBL<Inventory>
    {

        IEnumerable<Inventory> GetInventoryByProduct(Product entity);
        IEnumerable<Inventory> GetInventoryByStore(Storefront entity);
        Storefront GetStorefrontByStoreId(int storeName);
        Product GetProductByProdId(int prodId);
    }

    public class InventoryBl : BaseBL<Inventory>, IInventoryBl
    {
        public InventoryBl(IRepository<Inventory> context) : base(context)
        {
        }

        public IEnumerable<Inventory> GetInventoryByStore(Storefront entity)
        {
            return base.GetAll().Where(i => i.StoreNumber.Equals(entity.StoreNumber));
        }

        public IEnumerable<Inventory> GetInventoryByProduct(Product entity)
        {
            return base.GetAll().Where(i => i.ProdId.Equals(entity.ProdId));
        }

        public Storefront GetStorefrontByStoreId(int storeNumber)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration

            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                .Options;

            StoreManagerContext storeBL = new StoreManagerContext(options);
            return storeBL.Storefronts.Single(p => p.StoreNumber.Equals(storeNumber));
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
    }
}