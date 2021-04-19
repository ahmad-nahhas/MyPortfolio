using MyPortfolio.Shared.Entities;
using MyPortfolio.Shared.Filters.Base;
using MyPortfolio.Shared.Filters.Interfaces;
using System.Linq;

namespace MyPortfolio.Shared.Filters
{
    public class ProjectFilter : PagingFilter<Project>, IFilter<Project>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IQueryable<Project> Build(IQueryable<Project> initialSet, bool applayPaging = true)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                initialSet = initialSet.Where(p => p.Name.ToLower().Contains(Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(Description))
                initialSet = initialSet.Where(p => p.Description.ToLower().Contains(Description.ToLower()));

            return applayPaging ? ConfigurePaging(initialSet) : initialSet;
        }
    }
}