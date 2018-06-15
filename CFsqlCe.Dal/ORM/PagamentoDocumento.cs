using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class PagamentoDocumento
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPagamento { get; set; }

        public string DataPagamentoS { get; set; }

        public DateTime DataVencimento { get; set; }

        public string DataVencimentoS { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
