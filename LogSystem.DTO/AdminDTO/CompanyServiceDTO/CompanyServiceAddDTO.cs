using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class CompanyServiceAddDTO
    {
        public int CompanyId { get; set; }
        public int ServiceId { get; set; }
        public string SecretKey { get; set; }
        public string CompanyServiceDesc { get; set; }
    }

    public class CompanyServiceAddDTOValidator : AbstractValidator<CompanyServiceAddDTO>
    {
        public CompanyServiceAddDTOValidator()
        {
            RuleFor(m => m.CompanyId).NotEmpty();
            RuleFor(m => m.ServiceId).NotEmpty();
            RuleFor(m => m.SecretKey).NotEmpty().Length(1, 50);
            RuleFor(m => m.CompanyServiceDesc).MaximumLength(255);
        }
    }
}
