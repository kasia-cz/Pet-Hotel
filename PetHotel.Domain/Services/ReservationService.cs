﻿using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Exceptions;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly PetHotelDbContext _context;
        private readonly IUserService _userService;

        public ReservationService(PetHotelDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            reservation.UserId = _userService.GetCurrentUserId();
            reservation.ReservationStatus = ReservationStatus.Pending;
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> CancelReservation(int id)
        {
            var reservation = await GetReservationByIdForUser(id);
            reservation.ReservationStatus = ReservationStatus.Cancelled;
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> ConfirmReservation(int id)
        {
            var reservation = await GetReservationByIdForAdmin(id);
            reservation.ReservationStatus = ReservationStatus.Confirmed;
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> DeclineReservation(int id)
        {
            var reservation = await GetReservationByIdForAdmin(id);
            reservation.ReservationStatus = ReservationStatus.Declined;
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<List<Reservation>> GetUserReservations()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var userReservations = await _context.Reservations
                .Where(r => r.UserId == currentUserId).Include(r => r.Pets).ToListAsync();

            return userReservations;
        }

        public async Task<Reservation> GetReservationByIdForUser(int id)
        {
            var reservation = await _context.Reservations.Include(r => r.Pets).FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                throw new BadRequestException("Invalid reservation ID");
            }
            return reservation;
        }

        public async Task<Reservation> GetReservationByIdForAdmin(int id)
        {
            var reservation = await _context.Reservations.Include(r => r.User).Include(r => r.Pets).FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                throw new BadRequestException("Invalid reservation ID");
            }
            return reservation;
        }

        public async Task<List<Reservation>> GetAllReservations(string? reservationStatus, DateTime startDate, DateTime endDate)
        {
            var reservations = await _context.Reservations.Where(r =>
                    (String.IsNullOrEmpty(reservationStatus) || r.ReservationStatus == Enum.Parse<ReservationStatus>(reservationStatus)) &&
                    (startDate.Equals(DateTime.MinValue) || r.EndDate >= startDate) &&
                    (endDate.Equals(DateTime.MinValue) || r.StartDate <= endDate))
                .Include(r => r.User).Include(r => r.Pets)
                .ToListAsync();

            return reservations;
        }
    }
}
