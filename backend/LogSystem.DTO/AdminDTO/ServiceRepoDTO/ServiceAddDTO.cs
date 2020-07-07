using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogSystem.DTO.AdminDTO.ServiceRepoDTO
{
    public class ServiceAddDTO
    {
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }
        public string ServiceDesc { get; set; }
    }

    public class ServiceAddDTOValidator : AbstractValidator<ServiceAddDTO>
    {
        public ServiceAddDTOValidator()
        {
            RuleFor(m => m.ServiceName).NotEmpty().Length(2, 25);
            RuleFor(m => m.ServiceUrl).NotEmpty().Length(6, 255);
            RuleFor(m => m.ServiceDesc).MaximumLength(255);
        }
    }
}
