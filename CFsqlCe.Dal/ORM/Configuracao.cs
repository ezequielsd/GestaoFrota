using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSqlCe.Dal
{
    public class Configuracao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodPais { get; set; }

        [Required]
        public string Idioma { get; set; }

        [Required]
        public string CultureInfo { get; set; }        
    }
}
