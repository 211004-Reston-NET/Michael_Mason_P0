using System;

namespace Models
{
    public class CategoryModel : ICategoryModel
    {
        int _catNumber;
        string _catName;

        public int CatNumber { get; set; }
        public string CatName { get; set; }

        public override string ToString()
        {
            return $"{CatNumber} | {CatName}";
        }
    }
}