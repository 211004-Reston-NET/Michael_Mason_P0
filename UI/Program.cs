using System;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var categoryUnitOfWork = new CategoryUnitOfWork(new StoreManagerContext()))
            {
                var category = categoryUnitOfWork.categories.Get(1);
                Console.WriteLine(category.CatName);

                var categories = categoryUnitOfWork.categories.GetAll();
                foreach (var item in categories)
                {
                    Console.WriteLine(item.CatName);
                }
            }
        }
    }
}
