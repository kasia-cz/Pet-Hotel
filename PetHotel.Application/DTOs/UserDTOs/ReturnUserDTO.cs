﻿using PetHotel.Data.Enums;

namespace PetHotel.Application.DTOs.UserDTOs
{
    public class ReturnUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}