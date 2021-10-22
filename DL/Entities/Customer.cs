using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Customer
    {
        public Customer()
        {
            SOrders = new HashSet<SOrder>();
        }

        public int Id { get; private set; }
        public int CustNumber { get; private set; }
        public string CustName { get; private set; }
        public string CustAddress { get; private set; }
        public string CustEmail { get; private set; }
        public int CustPhone { get; private set; }

        public virtual ICollection<SOrder> SOrders { get; private set; }
    }
}
