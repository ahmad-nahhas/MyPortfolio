using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Web.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}