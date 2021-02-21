using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Account
{
    public class LoginViewModel
    {
        public LoginViewModel() : base()
        {
        }

        // *****
        [MaxLength(64)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        // *****

        // *****
        [MaxLength(64)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // *****

        // *****
        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
        // *****

    }
}
