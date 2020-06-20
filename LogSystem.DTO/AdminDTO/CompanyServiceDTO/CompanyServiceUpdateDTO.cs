using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class CompanyServiceUpdateDTO
    {
        public int CompanyServiceId { get; set; }
        public int CompanyId { get; set; }
        public int ServiceId { get; set; }
        public string SecretKey { get; set; }
        public string CompanyServiceDesc { get; set; }
    }

    public class CompanyServiceUpdateDTOValidator : AbstractValidator<CompanyServiceUpdateDTO>
    {
        public CompanyServiceUpdateDTOValidator()
        {
            RuleFor(m => m.CompanyServiceId).NotEmpty();
            RuleFor(m => m.CompanyId).NotEmpty();
            RuleFor(m => m.ServiceId).NotEmpty();
            RuleFor(m => m.SecretKey).NotEmpty().Length(1, 50);
            RuleFor(m => m.CompanyServiceDesc).MaximumLength(255);
        }
    }
}
