namespace DL
{
    public class CategoryUnitOfWork : ICategoryUnitOfWork
    {
        private readonly StoreManagerContext _context;
        public CategoryUnitOfWork(StoreManagerContext context)
        {
            _context = context;
            categories = new CategoryRepository(_context);
        }

        public ICategoryRepository categories { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}