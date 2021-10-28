using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class StorefrontRepository : Repository<Storefront>, IStorefrontRepository
    {
        public StorefrontRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<Storefront> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<Storefront> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}