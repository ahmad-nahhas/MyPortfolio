using MyPortfolio.Shared.Entities;
using System.Collections.Generic;

namespace MyPortfolio.Web.Models
{
    public class HomeViewModel
    {
        public Owner Owner { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public ContactViewModel Contact { get; set; }
    }
}