﻿using FluentValidation;

namespace LogSystem.DTO.AdminDTO.UserRepoDTO
{
    public class UsersDTO
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserMail { get; set; }
        public string RoleName { get; set; }
    }
}
