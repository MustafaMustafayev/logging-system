using FluentValidation;

namespace LogSystem.DTO.AdminDTO.UserRepoDTO
{
    public class UserAddDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserMail { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class UserAddDTOValidator : AbstractValidator<UserAddDTO>
    {
        public UserAddDTOValidator()
        {
            RuleFor(m => m.UserName).NotEmpty().Length(2, 50);
            RuleFor(m => m.Name).NotEmpty().Length(3, 50);
            RuleFor(m => m.Surname).NotEmpty().Length(3, 50);
            RuleFor(m => m.UserMail).NotEmpty().Length(7, 50).EmailAddress();
            RuleFor(m => m.PhoneNumber).NotEmpty().Length(7, 50);
            RuleFor(m => m.RoleId).NotEmpty();
            RuleFor(m => m.Password).NotEmpty().Length(3, 400);
            RuleFor(m => m.ConfirmPassword).NotEmpty().Equal(m => m.Password);
        }
    }
}
