using MyPortfolio.Shared.Entities;
using MyPortfolio.Shared.Filters.Base;
using MyPortfolio.Shared.Filters.Interfaces;
using System.Linq;

namespace MyPortfolio.Shared.Filters
{
    public class AddressFilter : PagingFilter<Address>, IFilter<Address>
    {
        public string Street { get; set; }
        public string City { get; set; }

        public IQueryable<Address> Build(IQueryable<Address> initialSet, bool applayPaging = true)
        {
            if (!string.IsNullOrWhiteSpace(Street))
                initialSet = initialSet.Where(a => a.Street.ToLower().Contains(Street.ToLower()));

            if (!string.IsNullOrWhiteSpace(City))
                initialSet = initialSet.Where(a => a.City.ToLower().Contains(City.ToLower()));

            return applayPaging ? ConfigurePaging(initialSet) : initialSet;
        }
    }
}