using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    /// <summary>
    /// Classe modelo para informaçoes no grid de pagamento do documento
    /// </summary>
    public class DGridPagamentoDocumentoInfo
    {
        public int Id { get; set; }

        public DateTime DataVencimento { get; set; }

        public string DataVencimentoS { get; set; }

        public DateTime Data { get; set; }

        public string DataS { get; set; }
        
        public decimal Valor { get; set; }    
        
        public string Descricao { get; set; }
    }
}
