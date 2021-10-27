using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IEnumerable<Product> Find(string query)
        {
            IEnumerable<Product> dbQuery = (from p in StoreManagerContext.Products
                            where p.ProdName.Contains(query)
                            select p);
            return dbQuery;
        }
    }
}