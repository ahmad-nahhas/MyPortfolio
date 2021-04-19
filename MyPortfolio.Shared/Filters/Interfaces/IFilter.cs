using System.Linq;

namespace MyPortfolio.Shared.Filters.Interfaces
{
    public interface IFilter<T> where T : class
    {
        IQueryable<T> Build(IQueryable<T> initialSet, bool applayPaging = true);
    }
}