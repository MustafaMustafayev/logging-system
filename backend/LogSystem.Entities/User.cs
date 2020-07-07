using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogSystem.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name is required wiht 50")]
        [MaxLength(50)]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string UserMail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Column(Order = 7)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
