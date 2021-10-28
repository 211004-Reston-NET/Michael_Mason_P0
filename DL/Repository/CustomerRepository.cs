using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<Customer> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<Customer> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}