using FluentValidation;
using PetHotel.Application.DTOs.ReservationDTOs;

namespace PetHotel.Application.Validators
{
    public class AddReservationValidator : AbstractValidator<AddReservationDTO>
    {
        public AddReservationValidator()
        {
            RuleFor(reservation => reservation.StartDate).NotEmpty().GreaterThan(DateTime.Today);

            RuleFor(reservation => reservation.EndDate).NotEmpty()
                .GreaterThan(reservation => reservation.StartDate.AddHours(23))
                .WithMessage("Reservation end date must be greater than start date by at least one day")
                .LessThan(reservation => reservation.StartDate.AddDays(14))
                .WithMessage("Maximum reservation duration is 14 days");

            RuleFor(reservation => reservation.PetsId).NotEmpty().NotNull();
        }
    }
}
