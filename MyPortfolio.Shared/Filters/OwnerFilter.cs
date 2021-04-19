using MyPortfolio.Shared.Entities;
using MyPortfolio.Shared.Filters.Base;
using MyPortfolio.Shared.Filters.Interfaces;
using System.Linq;

namespace MyPortfolio.Shared.Filters
{
    public class OwnerFilter : PagingFilter<Owner>, IFilter<Owner>
    {
        public string Name { get; set; }
        public string Profile { get; set; }

        public IQueryable<Owner> Build(IQueryable<Owner> initialSet, bool applayPaging = true)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                initialSet = initialSet.Where(o => o.FullName.ToLower().Contains(Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(Profile))
                initialSet = initialSet.Where(o => o.Profile.ToLower().Contains(Profile.ToLower()));

            return applayPaging ? ConfigurePaging(initialSet) : initialSet;
        }
    }
}