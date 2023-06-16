using System.ComponentModel.DataAnnotations;

namespace Kidney.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
