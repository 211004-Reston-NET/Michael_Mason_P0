using System;

namespace Models
{
    public interface IProdCatModel : IModel<ProdCatModel>
    {
        int PKey { get; set; }
        int ProdId { get; set; }
        int CatId { get; set; }
        CategoryModel Cat { get; set; }
        ProductModel Prod { get; set; }
    }
}
