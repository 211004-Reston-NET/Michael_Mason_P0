using System;
using DL;
using Models;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var categoryUnitOfWork = new CategoryUnitOfWork(new StoreManagerContext()))
            {
                /*
                ICategoryModel newCat = new MCategory();
                newCat.CatNumber = 3;
                newCat.CatName = "Books";

                Category catDTO = new Category();
                catDTO.CatNumber = newCat.CatNumber;
                catDTO.CatName = newCat.CatName;

                ICategoryModel newCat1 = new MCategory();
                newCat1.CatNumber = 4;
                newCat1.CatName = "Home Goods";

                Category catDTO1 = new Category();
                catDTO1.CatNumber = newCat1.CatNumber;
                catDTO1.CatName = newCat1.CatName;

                categoryUnitOfWork.categories.Create(catDTO);
                categoryUnitOfWork.categories.Create(catDTO1);
                categoryUnitOfWork.Complete();
                */

                /*
                var categories = categoryUnitOfWork.categories.GetAll();
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.CatNumber} | {item.CatName}");
                }
                */

                /*
                var del = categoryUnitOfWork.categories.Get(7);
                categoryUnitOfWork.categories.Delete(del);
                categoryUnitOfWork.Complete();
                */

                var category = categoryUnitOfWork.categories.Get(1);
                Console.WriteLine($"item: {category.CatNumber} | {category.CatName}");

                var categories1 = categoryUnitOfWork.categories.GetAll();
                Console.WriteLine("list:");
                foreach (var item in categories1)
                {
                    Console.WriteLine($"{item.CatNumber} | {item.CatName}");
                }

                var matching = categoryUnitOfWork.categories.Find("t");
                foreach (var item in matching)
                {
                    Console.WriteLine($"search result: {item.CatNumber} | {item.CatName}");
                }
            }
        }
    }
}
