using System;

namespace Models
{
    public interface IProductModel : IModel<ProductModel>
    {
        int PKey { get; set;}
        int ProdNumber { get; set;}
        string ProdName { get; set;}
        decimal ProdPrice { get; set;}
        string ProdDesc { get; set;}
    }
}
