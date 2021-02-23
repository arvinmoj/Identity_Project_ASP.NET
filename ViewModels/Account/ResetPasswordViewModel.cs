using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        public ResetPasswordViewModel() : base()
        {
        }

        // *****
        [MaxLength(64)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // *****

        // *****
        [MaxLength(64)]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        // *****

        // *****
        [MaxLength(64)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        // *****

        // *****
        [DataType(DataType.Text)]
        [Display(Name = "Token")]
        public string Token { get; set; }
        // *****
    }
}
