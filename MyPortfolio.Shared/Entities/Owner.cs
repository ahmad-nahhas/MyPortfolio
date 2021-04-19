using MyPortfolio.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Shared.Entities
{
    public class Owner : EntityBase
    {
        [Required(ErrorMessage = "Owner Name is required")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Name Should be minimum 2 characters and a maximum of 255 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Owner Profile is required")]
        [StringLength(513, MinimumLength = 6, ErrorMessage = "Profile Should be minimum 6 characters and a maximum of 513 characters")]
        public string Profile { get; set; }

        [Required(ErrorMessage = "About text is required")]
        [StringLength(1024, MinimumLength = 6, ErrorMessage = "About text Should be minimum 6 characters and a maximum of 1024 characters")]
        public string About { get; set; }

        [Required(ErrorMessage = "Owner Description is required")]
        [StringLength(1024, MinimumLength = 6, ErrorMessage = "Description Should be minimum 6 characters and a maximum of 1024 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Owner Avatar is required")]
        public string AvatarPath { get; set; }

        [Required(ErrorMessage = "Owner CV is required")]
        public string CVPath { get; set; }

        [Required(ErrorMessage = "Owner Address is required")]
        public Address Address { get; set; }
    }
}