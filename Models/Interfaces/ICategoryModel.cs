using System;

namespace Models
{
    public interface ICategoryModel : IModel<CategoryModel>
    {
        int Id { get; set; }
        string CatName { get; set; }
    }
}
