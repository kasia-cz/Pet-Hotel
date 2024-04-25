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

            RuleFor(user => user.PhoneNumber).NotEmpty().Length(7, 15).Matches(@"^\+?[0-9]+$")
                .WithMessage("Phone number must contain only digits and may start with '+'");

            RuleFor(user => user.Password).NotEmpty().Length(8, 30)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).*$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
            
            RuleFor(user => user.ConfirmPassword).NotEmpty().Length(8, 30)
                .Equal(user => user.Password).WithMessage("Passwords do not match");
        }
    }
}
