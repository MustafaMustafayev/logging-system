using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyRepoDTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyAbbr { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
    }
    public class CompanyDTOValidator : AbstractValidator<CompanyDTO>
    {
        public CompanyDTOValidator()
        {
            RuleFor(m => m.CompanyId).NotEmpty();
            RuleFor(m => m.CompanyAbbr).NotEmpty().Length(2, 25);
            RuleFor(m => m.CompanyName).NotEmpty().Length(3, 255);
            RuleFor(m => m.CompanyDesc).MaximumLength(255);
        }
    }
}
