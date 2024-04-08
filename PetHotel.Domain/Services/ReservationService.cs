﻿using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
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
            var reservation = await GetReservationById(id);
            reservation.ReservationStatus = ReservationStatus.Cancelled;
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<List<Reservation>> GetUserReservations()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var usersReservations = await _context.Reservations
                .Where(r => r.UserId == currentUserId).Include(r => r.Pets).ToListAsync();

            return usersReservations;
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservations.Include(r => r.Pets).FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
