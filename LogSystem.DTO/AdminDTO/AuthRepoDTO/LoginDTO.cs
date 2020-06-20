using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace LogSystem.DTO.AdminDTO.AuthRepoDTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(m => m.Username).NotEmpty().MaximumLength(50);
            RuleFor(m => m.Password).NotEmpty().MaximumLength(400);
        }
    }
}
