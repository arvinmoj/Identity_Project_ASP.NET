using System;
using FluentValidation;
using ViewModels.Account;

namespace Validator.Account
{
    public class LoginValidation : AbstractValidator<LoginViewModel>
    {
        [Obsolete]
        public LoginValidation() 
        {
            // *****
            RuleFor(c => c.Username)
                .NotNull().WithMessage("Username Is Required.")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****

            // *****
            RuleFor(c => c.Password)
                .NotNull().WithMessage("Password is Required.")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****
        }
    }
}
