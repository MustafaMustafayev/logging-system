using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogSystem.Entities
{
        public class Company
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key, Column(Order = 0)]
            public int CompanyId { get; set; }

            [Required]
            [MaxLength(25)]
            public string CompanyAbbr { get; set; }

            [Required]
            [MaxLength(255)]
            public string CompanyName { get; set; }

            [MaxLength(255)]
            public string CompanyDesc { get; set; }

            public virtual ICollection<CompanyService> CompanyServices { get; set; }

            [DefaultValue(typeof(DateTime), "")]
            public DateTime? CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public DateTime? DeletedDate { get; set; }
        }
}
