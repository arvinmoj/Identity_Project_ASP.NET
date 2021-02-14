using System.ComponentModel.DataAnnotations;

namespace ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel() : base()
        {
        }

        [MaxLength(64)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }

        [EmailAddress]
        [MaxLength(64)]
        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "Email Is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Is Not Valid")]
        public string Email { get; set; }

        [MaxLength(64)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [MaxLength(64)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "ConfirmPassword Is Required")]
        public string ConfirmPassword { get; set; }
    }
}
