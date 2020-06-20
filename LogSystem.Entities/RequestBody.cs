using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogSystem.Entities
{
    public class RequestBody
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestBodyId { get; set; }
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
