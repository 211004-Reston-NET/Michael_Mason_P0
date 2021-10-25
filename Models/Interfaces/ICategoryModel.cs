using System;

namespace Models
{
    public interface ICategoryModel : IModel<CategoryModel>
    {
        int CatNumber { get; set; }
        string CatName { get; set; }
    }
}
