using System;

namespace Models
{
    public interface ICategoryModel : IModel<CategoryModel>
    {
        int PKey { get; set; }
        string CatName { get; set; }
    }
}
