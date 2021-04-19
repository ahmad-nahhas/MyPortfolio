using MyPortfolio.Shared.Repositories.Interfaces;
using System.Threading.Tasks;

namespace MyPortfolio.Shared.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Repository { get; }
        Task<int> Save();
    }
}