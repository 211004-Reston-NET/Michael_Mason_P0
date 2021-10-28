using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class SOrderRepository : Repository<SOrder>, ISOrderRepository
    {
        public SOrderRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<SOrder> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<SOrder> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}