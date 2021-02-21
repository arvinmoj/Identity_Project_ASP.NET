using System;
using FluentValidation;
using ViewModels.Account;

namespace Validator.Account
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordViewModel>
    {
        [Obsolete]
        public ResetPasswordValidation()
        {

            // *****
            RuleFor(c => c.Password)
                .NotNull().WithMessage("Password is Required.")
                .NotEmpty()
                .MinimumLength(8).WithMessage("Must Be Longer Than 8 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****

            // *****
            RuleFor(c => c.ConfirmPassword)
                .NotNull().WithMessage("ConfirmPassword is Required.")
                .NotEmpty()
                .MinimumLength(8).WithMessage("Must Be Longer Than 8 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters")
                .Equal(c => c.Password).WithMessage("ConfirmPassword");
            // *****

            // *****
            RuleFor(c => c.Username)
                .NotNull().WithMessage("Username Is Required.")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****

            // *****
            RuleFor(c => c.Token)
                .NotNull().WithMessage("Token Is Required.")
                .NotEmpty();
            // *****

        }
    }
}
