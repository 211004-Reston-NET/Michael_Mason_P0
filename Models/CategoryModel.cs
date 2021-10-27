using System;

namespace Models
{
    public class CategoryModel : ICategoryModel
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CatName
        {
            get => throw new NotImplementedException();
            set {

                if (value.Length == 0 || value.Length > 50)
                {
                    throw new Exception("Category name cannot be empty and must be less than 50 characers");
                }

                CatName = value;
            }
        }
    }
}