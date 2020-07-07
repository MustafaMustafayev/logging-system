using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.UserRepoDTO
{
    public class UpdatePasswordDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UpdatePasswordDTOValidator : AbstractValidator<UpdatePasswordDTO>
    {
        public UpdatePasswordDTOValidator()
        {
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => m.Password).NotEmpty().Length(3, 400);
            RuleFor(m => m.ConfirmPassword).NotEmpty().Equal(m => m.Password);
        }
    }
}
