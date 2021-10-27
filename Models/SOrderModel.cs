using System;
using System.Collections.Generic;

namespace Models
{
    public class SOrderModel : ISOrderModel
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int StoreId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CustId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OrderNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal TotalPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CustomerModel Cust { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StorefrontModel Store { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<LineItemModel> LineItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}