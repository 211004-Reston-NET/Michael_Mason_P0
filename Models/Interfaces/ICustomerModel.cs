using System;
using System.Collections.Generic;

namespace Models
{
    public interface ICustomerModel : IModel<CustomerModel>
    {
        int Id { get; set; }
        int CustNumber { get; set; }
        string CustName { get; set; }
        string CustAddress { get; set; }
        string CustEmail { get; set; }
        int CustPhone { get; set; }

        ICollection<SOrderModel> SOrders { get; set; }
    }
}
