using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSqlCe.Dal
{
    public class Combustivel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Tipo { get; set; }
    }
}
