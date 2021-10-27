using System;
using System.Collections.Generic;

namespace Models
{
    public class StorefrontModel : IStorefrontModel
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string StoreName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string StoreAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int StorePhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<InventoryModel> Inventories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<SOrderModel> SOrders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}