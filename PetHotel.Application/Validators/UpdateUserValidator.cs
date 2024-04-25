using FluentValidation;
using PetHotel.Application.DTOs.UserDTOs;

namespace PetHotel.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator() 
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.UserName).NotEmpty().Length(5, 15);
            RuleFor(user => user.FirstName).NotEmpty().Length(3, 15);
            RuleFor(user => user.LastName).NotEmpty().Length(3, 30);

            RuleFor(user => user.PhoneNumber).NotEmpty().Length(7, 15).Matches(@"^\+?[0-9]+$")
                .WithMessage("Phone number must contain only digits and may start with '+'");
        }
    }
}
