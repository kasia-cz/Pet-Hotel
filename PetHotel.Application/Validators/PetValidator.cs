using FluentValidation;
using PetHotel.Application.DTOs.PetDTOs;

namespace PetHotel.Application.Validators
{
    public class PetValidator : AbstractValidator<AddPetDTO>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.Name).NotEmpty().MaximumLength(30);
            RuleFor(pet => pet.Type).NotEmpty();
            RuleFor(pet => pet.Breed).MaximumLength(50);
            RuleFor(pet => pet.DateOfBirth).NotEmpty().LessThan(DateTime.Today);
            RuleFor(pet => pet.Weight).NotEmpty().ExclusiveBetween(0, 121);
            RuleFor(pet => pet.Diseases).MaximumLength(250);
            RuleFor(pet => pet.NutritionalRequirements).MaximumLength(250);
            RuleFor(pet => pet.AnotherInformations).MaximumLength(250);
        }
    }
}
