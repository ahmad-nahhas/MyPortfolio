using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Web.Models
{
    public class ProjectViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Project Name is required")]
        [StringLength(65, MinimumLength = 2, ErrorMessage = "Name Should be minimum 2 characters and a maximum of 65 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project Description is required")]
        [StringLength(1024, MinimumLength = 8, ErrorMessage = "Description Should be minimum 8 characters and a maximum of 1024 characters")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

        public string Link { get; set; }
    }
}