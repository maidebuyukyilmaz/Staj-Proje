
using FluentValidation;
using stajProje.UI.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.UserValidationRules
{
    public class UserRegisterValidator:AbstractValidator<UserRegistrationDto>
    {
        public UserRegisterValidator() { 
        
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords do not match");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Enter a valid email address");

        }
    }
}
