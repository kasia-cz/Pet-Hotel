﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Constants;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;
using PetHotel.Domain.Models;
using System.Security.Claims;

namespace PetHotel.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly PetHotelDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(PetHotelDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetCurrentUser()
        {
            return await _context.Users.FindAsync(GetCurrentUserId());
        }

        public async Task<User> UpdateUser(User requestUser)
        {
            var user = await _context.Users.FindAsync(GetCurrentUserId());

            user.Email = requestUser.Email;
            user.UserName = requestUser.UserName;
            user.FirstName = requestUser.FirstName;
            user.LastName = requestUser.LastName;
            user.PhoneNumber = requestUser.PhoneNumber;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> SetUserRole(string id, string requestUserRole)
        {
            var user = await _context.Users.FindAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, requestUserRole);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> GetUserRole(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.FirstOrDefault();
        }

        public async Task Register(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, UserConstants.UserRoles.User);
        }

        public async Task Login(LoginModel model)
        {
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
