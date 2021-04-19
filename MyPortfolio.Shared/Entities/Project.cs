using MyPortfolio.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Shared.Entities
{
    public class Project : EntityBase
    {
        [Required(ErrorMessage = "Project Name is required")]
        [StringLength(65, MinimumLength = 2, ErrorMessage = "Name Should be minimum 2 characters and a maximum of 65 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project Description is required")]
        [StringLength(1024, MinimumLength = 8, ErrorMessage = "Description Should be minimum 8 characters and a maximum of 1024 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Project Image is required")]
        public string ImagePath { get; set; }

        public string Link { get; set; }
    }
}