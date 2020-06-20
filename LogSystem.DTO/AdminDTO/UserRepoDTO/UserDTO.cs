using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.UserRepoDTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserMail { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
    }

    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(m => m.UserName).NotEmpty().Length(2, 50);
            RuleFor(m => m.Name).NotEmpty().Length(3, 50);
            RuleFor(m => m.Surname).NotEmpty().Length(3, 50);
            RuleFor(m => m.UserMail).NotEmpty().Length(7, 50).EmailAddress();
            RuleFor(m => m.PhoneNumber).NotEmpty().Length(7, 50);
            RuleFor(m => m.RoleId).NotEmpty();
        }
    }
}
