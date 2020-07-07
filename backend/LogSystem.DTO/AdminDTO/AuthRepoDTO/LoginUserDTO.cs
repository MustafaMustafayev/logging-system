
namespace LogSystem.DTO.AdminDTO.AuthRepoDTO
{
    public class LoginUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserMail { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public string TokenExpireDate { get; set; }
    }
}
