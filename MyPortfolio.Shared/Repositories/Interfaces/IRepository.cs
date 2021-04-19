using MyPortfolio.Shared.Filters.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPortfolio.Shared.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(IFilter<T> filter);
        Task<T> Get(object id);
        Task<T> Add(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(object id);
    }
}