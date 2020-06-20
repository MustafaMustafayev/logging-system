using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogSystem.Entities
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int RoleId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string RoleName { get; set; }

        [MaxLength(255)]
        public string RoleDesc { get; set; }

        public virtual ICollection<User> Users { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
