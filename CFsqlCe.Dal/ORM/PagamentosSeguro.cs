using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class PagamentosSeguro
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public string PathPagamentoPDF { get; set; }

        public int ContratoSeguroId { get; set; }

        [ForeignKey("ContratoSeguroId")]
        public virtual ContratoSeguro ContratoSeguro { get; set; }

        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
