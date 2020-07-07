using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogSystem.Entities
{
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(25)]
        public string ServiceName { get; set; }

        [Required]
        [MaxLength(255)]
        public string ServiceUrl { get; set; }

        [MaxLength(255)]
        public string ServiceDesc { get; set; }
        public virtual ICollection<CompanyService> CompanyServices { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
