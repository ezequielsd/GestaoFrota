using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class ContratoSeguro
    {
        [Key]
        public int Id { get; set; }

        public string NumeroApolice { get; set; }

        public DateTime DataInicialContrato { get; set; }

        public DateTime DataFinalContrato { get; set; }

        public bool Ativo { get; set; }

        public string PathOrcamentoPDF { get; set; }

        public string PathContratoPDF { get; set; }

        public string PathCartaoPDF { get; set; }

        public int SeguradoraId { get; set; }

        [ForeignKey("SeguradoraId")]
        public virtual Seguradora Seguradora { get; set; }

        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
