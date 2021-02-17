using System;
using FluentValidation;
using ViewModels.Account;

namespace Validator.Account
{
    public class RegisterValidation : AbstractValidator<RegisterViewModel>
    {
        [Obsolete]
        public RegisterValidation()
        {
            // *****
            RuleFor(c => c.Username)
                .NotNull().WithMessage("Username Is Required.")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****

            // *****
            RuleFor(c => c.Email)
                .NotNull().WithMessage("E-mail Is Required.")
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("E-mail Is Not Valid.")
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(20).WithMessage("Must Be Less Than Or Equal To 20 Characters");
            // *****

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
        }
    }
}