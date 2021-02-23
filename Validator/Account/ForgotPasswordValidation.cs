using System;
using FluentValidation;
using ViewModels.Account;

namespace Validator.Account
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordViewModel>
    {
        [Obsolete]
        public ForgotPasswordValidation()
        {
            // *****
            RuleFor(c => c.Email)
                .NotNull().WithMessage("E-mail Is Required.")
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("E-mail Is Not Valid.")
                .MinimumLength(3).WithMessage("Must Be Longer Than 3 Characters")
                .MaximumLength(64).WithMessage("Must Be Less Than Or Equal To 64 Characters");
            // *****
        }
    }
}
