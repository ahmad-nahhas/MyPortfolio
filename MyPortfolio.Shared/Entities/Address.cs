using MyPortfolio.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Shared.Entities
{
    public class Address : EntityBase
    {
        [Required]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Street Should be minimum 2 characters and a maximum of 255 characters")]
        public string Street { get; set; }

        [Required]
        [StringLength(65, MinimumLength = 2, ErrorMessage = "City Should be minimum 2 characters and a maximum of 65 characters")]
        public string City { get; set; }

        [Range(0, 100000, ErrorMessage = "Address Number must be between 0 and 100000.")]
        public int Number { get; set; }
    }
}