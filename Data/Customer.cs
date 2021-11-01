using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Customer
    {
        public Customer()
        {
            SOrders = new HashSet<SOrder>();
        }

        public int CustNumber { get; set; }
        public string CustEmail { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public int CustPhone { get; set; }

        public virtual ICollection<SOrder> SOrders { get; set; }
    }
}
