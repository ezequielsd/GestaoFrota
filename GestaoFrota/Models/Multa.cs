using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    public class DGridMultaInfo
    {
        public int Id { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public string LocalComplemento { get; set; }

        public DateTime DataVencimento { get; set; }

        public string DataOcorrenciaS { get; set; }

        public string DataVencimentoS { get; set; }

        public DateTime DataPagamento { get; set; }

        public string DataPagamentoS { get; set; }

        public decimal Valor { get; set; }

        public string Status { get; set; }

        public string PathComprovantePDF { get; set; }           
        
    }
}
