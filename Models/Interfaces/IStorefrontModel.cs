using System;
using System.Collections.Generic;

namespace Models
{
    public interface IStorefrontModel : IModel<StorefrontModel>
    {
        int Id { get; set; }
        string StoreName { get; set; }
        string StoreAddress { get; set; }
        int StorePhone { get; set; }

        ICollection<InventoryModel> Inventories { get; set; }
        ICollection<SOrderModel> SOrders { get; set; }
    }
}
