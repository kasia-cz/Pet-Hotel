using FluentValidation;
using PetHotel.Application.DTOs.UserDTOs;

namespace PetHotel.Application.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.UserName).NotEmpty().Length(5, 15);
            RuleFor(user => user.FirstName).NotEmpty().Length(3, 15);
            RuleFor(user => user.LastName).NotEmpty().Length(3, 30);
            RuleFor(user => user.PhoneNumber).NotEmpty().Length(7, 15);
            RuleFor(user => user.Password).NotEmpty().Length(8, 30);
            RuleFor(user => user.ConfirmPassword).NotEmpty().Length(8, 30)
                .Equal(user => user.Password).WithMessage("Passwords do not match");
        }
    }
}
