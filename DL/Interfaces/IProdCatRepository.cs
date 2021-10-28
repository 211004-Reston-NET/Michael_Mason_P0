using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public interface IProdCatRepository : IRepository<ProdCat>
    {
        ICollection<ProdCat> FindProdCatsByProdId(int query);
        IQueryable<string> FindAndJoinCategories(int query);
        IQueryable<string> FindAndJoinProducts(int query);
        string FindProductName(int id);
    }
}