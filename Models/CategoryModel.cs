using System;

namespace Models
{
    public class CategoryModel : ICategoryModel
    {
        int pKey;
        int _catNumber;
        string _catName;

        public int PKey { get; set; }
        public string CatName { get; set; }

        public override string ToString()
        {
            return $"{PKey} | {CatName}";
        }
    }
}