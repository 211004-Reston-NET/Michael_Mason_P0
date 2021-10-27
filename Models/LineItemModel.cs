using System;

namespace Models
{
    public class LineItemModel : ILineItemModel
    {
        public int PKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OrderId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ProdId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SOrderModel Order { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ProductModel Prod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}