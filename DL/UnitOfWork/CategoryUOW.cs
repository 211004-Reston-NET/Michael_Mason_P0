namespace DL
{
    public class CategoryUOW : UnitOfWork<Category>, ICategoryUOW
    {
        public CategoryUOW(CategoryRepository context) : base(context)
        {
            categories = new CategoryRepository(new StoreManagerContext());
        }

        public ICategoryRepository categories { get; set; }
    }
}