using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogSystem.Entities
{
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        [Required]
        public int CompanyServiceId { get; set; }
        public virtual CompanyService CompanyService { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual RequestBody RequestBody { get; set; }
    }
}
