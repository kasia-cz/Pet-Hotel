using FluentValidation;
using PetHotel.Application.DTOs.PetDTOs;

namespace PetHotel.Application.Validators
{
    public class PetTypeValidator : AbstractValidator<PetTypeDTO>
    {
        public PetTypeValidator()
        {
            RuleFor(petType => petType.Name).NotEmpty().Length(3, 20);
            RuleFor(petType => petType.LimitOfPlaces).NotEmpty().GreaterThan(0);
        }
    }
}
