using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email Address")
                ;
            //Password
            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password is required")
                .MaximumLength(20).WithMessage("Max length is 20")
                .MinimumLength(6).WithMessage("Min length is 6")
                ;
            //Person Name
            RuleFor(request => request.PersonName)
                .NotEmpty().WithMessage("PersonName is required")
                .Length(1,50)
                ;
            //Gender
            RuleFor(request => request.Gender)
                .NotEmpty().WithMessage("Gender is required")
                .IsInEnum().WithMessage("Gender has to be MALE,FEMALE or Others")
                ;
        }
    }
}
