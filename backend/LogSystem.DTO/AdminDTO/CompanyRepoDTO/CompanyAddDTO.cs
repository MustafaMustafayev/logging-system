using FluentValidation;

namespace LogSystem.DTO.AdminDTO.CompanyRepoDTO
{
    public class CompanyAddDTO
    {
        public string CompanyAbbr { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
    }

    public class CompanyAddDTOValidator : AbstractValidator<CompanyAddDTO>
    {
        public CompanyAddDTOValidator()
        {
            RuleFor(m => m.CompanyAbbr).NotEmpty().Length(2, 25);
            RuleFor(m => m.CompanyName).NotEmpty().Length(3, 255);
            RuleFor(m => m.CompanyDesc).MaximumLength(255);
        }
    }
}
