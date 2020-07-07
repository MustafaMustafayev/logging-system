using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogSystem.Entities
{
    public class CompanyService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CompanyServiceId { get; set; }

        [Column(Order = 1)]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Column(Order = 2)]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [Column(Order = 3)]
        [Required]
        [MaxLength(500)]
        public string SecretKey { get; set; }

        [Column(Order = 5)]
        [MaxLength(255)]
        public string CompanyServiceDesc { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
