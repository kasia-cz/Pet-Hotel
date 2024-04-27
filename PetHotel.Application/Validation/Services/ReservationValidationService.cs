using PetHotel.Application.Validation.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Exceptions;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Validation.Services
{
    public class ReservationValidationService : IReservationValidationService
    {
        private readonly IReservationService _reservationService;
        private readonly IPetTypeService _petTypeService;

        public ReservationValidationService(IReservationService reservationService, IPetTypeService petTypeService)
        {
            _reservationService = reservationService;
            _petTypeService = petTypeService;
        }

        public async Task ValidateReservation(Reservation requestReservation)
        {
            var requestPetTypeDict = CountPetTypesInReservation(requestReservation);
            var confirmedReservations = await _reservationService.GetAllReservations(ReservationStatus.Confirmed.ToString(), requestReservation.StartDate, requestReservation.EndDate);

            foreach (var requestPetType in requestPetTypeDict)
            {
                var requestPetTypeName = requestPetType.Key;
                var requestPetTypeNumber = requestPetType.Value;

                var petType = await _petTypeService.GetPetTypeByName(requestPetTypeName);
                var limitOfPlaces = petType.LimitOfPlaces;

                if (limitOfPlaces < requestPetTypeNumber)
                {
                    throw new BadRequestException($"Number of pets in request reservation above the limit of places, type: {requestPetTypeName}");
                }

                var dateDict = new Dictionary<DateTime, int>();
                for (DateTime date = requestReservation.StartDate; date <= requestReservation.EndDate; date = date.AddDays(1))
                {
                    dateDict[date] = 0;
                }

                foreach (Reservation confirmedReservation in confirmedReservations)
                {
                    var confirmedPetTypeDict = CountPetTypesInReservation(confirmedReservation);
                    if (confirmedPetTypeDict.ContainsKey(requestPetTypeName))
                    {
                        foreach (var date in dateDict)
                        {
                            if (date.Key >= confirmedReservation.StartDate && date.Key <= confirmedReservation.EndDate)
                            {
                                dateDict[date.Key] += confirmedPetTypeDict[requestPetTypeName];
                            }

                            if (dateDict[date.Key] + requestPetTypeNumber > limitOfPlaces)
                            {
                                throw new BadRequestException($"Number of pets in request reservation and confirmed reservations above the limit of places, type: {requestPetTypeName}");
                            }
                        }
                    }
                }
            }
        }

        private static Dictionary<string, int> CountPetTypesInReservation(Reservation reservation)
        {
            var petTypeDict = new Dictionary<string, int>();

            foreach (Pet pet in reservation.Pets)
            {
                var petType = pet.Type;

                if (petTypeDict.ContainsKey(petType))
                {
                    petTypeDict[petType] += 1;
                }
                else
                {
                    petTypeDict[petType] = 1;
                }
            }
            return petTypeDict;
        }
    }
}
