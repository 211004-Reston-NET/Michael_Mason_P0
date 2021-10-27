using System;
using System.Collections.Generic;

namespace Models
{
    public interface ISOrderModel : IModel<SOrderModel>
    {
        int Id { get; set; }
        int StoreId { get; set; }
        int CustId { get; set; }
        int OrderNumber { get; set; }
        decimal TotalPrice { get; set; }

        CustomerModel Cust { get; set; }
        StorefrontModel Store { get; set; }
        ICollection<LineItemModel> LineItems { get; set; }
    }
}
