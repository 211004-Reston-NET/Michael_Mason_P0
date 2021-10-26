using System;

namespace Models
{
    public class CategoryModel : ICategoryModel
    {
        int pKey;
        int _catNumber;
        string _catName;

        public int PKey { get; set; }
        public string CatName 
        { 
            get { return _catName; }
            set
            {
                if (value.Length == 0 || value.Length > 50)
                {
                    throw new Exception("Category name cannot be empty and must be less than 50 characers");
                }
                
                _catName = value;
            }
        }

        public override string ToString()
        {
            return $"{PKey} | {CatName}";
        }
    }
}