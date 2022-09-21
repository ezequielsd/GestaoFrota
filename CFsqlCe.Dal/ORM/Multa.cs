using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class Multa
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public string DataOcorrenciaS { get; set; }

        [StringLength(400)]
        public string LocalOcorrencia { get; set; }

        public DateTime DataVencimento { get; set; }

        public string DataVencimentoS { get; set; }

        public DateTime DataPagamento { get; set; }

        public string DataPagamentoS { get; set; }

        public decimal Valor { get; set; }

        public string PathAnexoMultaPDF { get; set; }

        public  bool PagamentoRealizado { get; set; }

        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
