﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class CompanyServiceDeleteDTO
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }

    public class CompanyServiceDeleteDTOValidator : AbstractValidator<CompanyServiceDeleteDTO>
    {
        public CompanyServiceDeleteDTOValidator()
        {
            RuleFor(m => m.CompanyId).NotEmpty();
            RuleFor(m => m.ServiceId).NotEmpty();
        }
    }
}
