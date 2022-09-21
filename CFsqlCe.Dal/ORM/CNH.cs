using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class CNH
    {
        [Key]
        public string NumeroRegistro { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        [StringLength(10)]
        public string Categoria { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [StringLength(300)]
        public string Filiacao { get; set; }

        public DateTime PrimeiraHabilitacao { get; set;}

        public DateTime Emissao { get; set; }

        public DateTime Validade { get; set; }

        [StringLength(200)]
        public string Local { get; set; }

        public string PathDocumentoPDF { get; set; }

        public bool Aivo { get; set; }
    }
}
