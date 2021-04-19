using Microsoft.EntityFrameworkCore;
using MyPortfolio.Shared.Filters.Interfaces;
using MyPortfolio.Shared.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPortfolio.Shared.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly MyPortfolioDbContext _context;
        private readonly DbSet<T> _table;

        public RepositoryBase(MyPortfolioDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get() => await _table.ToListAsync();

        public async Task<IEnumerable<T>> Get(IFilter<T> filter) => await filter.Build(_table).ToListAsync();

        public async Task<T> Get(object id) => await _table.FindAsync(id);

        public async Task<T> Add(T Entity) => (await _table.AddAsync(Entity)).Entity;

        public async Task<T> Delete(object id) => _table.Remove(await Get(id)).Entity;

        public async Task<T> Update(T Entity)
        {
            await _table.AddAsync(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            return Entity;
        }
    }
}