using MyPortfolio.Shared.Repositories.Base;
using MyPortfolio.Shared.Repositories.Interfaces;
using MyPortfolio.Shared.UnitOfWorks.Interfaces;
using System.Threading.Tasks;

namespace MyPortfolio.Shared.UnitOfWorks.Base
{
    public class UnitOfWorkBase<T> : IUnitOfWork<T> where T : class
    {
        private readonly MyPortfolioDbContext _context;
        private IRepository<T> _repository;

        public UnitOfWorkBase(MyPortfolioDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository => _repository ??= new RepositoryBase<T>(_context);

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}