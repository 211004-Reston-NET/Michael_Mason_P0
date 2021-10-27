using System;

namespace Models
{
    public interface ILineItemModel : IModel<LineItemModel>
    {
        int PKey { get; set; }
        int OrderId { get; set; }
        int ProdId { get; set; }
        int Quantity { get; set; }
        SOrderModel Order { get; set; }
        ProductModel Prod { get; set; }
    }
}
