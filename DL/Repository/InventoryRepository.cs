using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<Inventory> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<Inventory> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}