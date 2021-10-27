using System;
using System.Collections.Generic;

namespace Models
{
    public class CustomerModel : ICustomerModel
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CustNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CustPhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<SOrderModel> SOrders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}