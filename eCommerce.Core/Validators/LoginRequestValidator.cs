using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //Rules for Email
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("Invalid Email Address");

            //Password
            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password is Required");
        }
    }
}
