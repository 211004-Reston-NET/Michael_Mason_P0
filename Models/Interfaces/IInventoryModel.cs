using System;

namespace Models
{
    public interface IInventoryModel : IModel<InventoryModel>
    {
        int Id { get; set; }
        int StoreId { get; set; }
        int ProdId { get; set; }
        int Quantity { get; set; }

        ProductModel Prod { get; set; }
        StorefrontModel Store { get; set; }
    }
}
