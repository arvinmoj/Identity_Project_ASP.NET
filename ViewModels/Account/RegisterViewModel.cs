using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel() : base()
        {
        }

        [MaxLength(64)]
        [Display(Name = "Username")]
        [Remote("IsUsernameInUse","Account")]
        public string Username { get; set; }

        [MaxLength(64)]
        [Display(Name = "EmailAddress")]
        [Remote("IsEmailInUse","Account")]
        public string Email { get; set; }

        [MaxLength(64)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(64)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

    }
}
