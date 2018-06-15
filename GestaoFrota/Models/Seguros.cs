using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    public class DGridPagamentoSeguroInfo
    {
        public int Id { get; set; }

        public string Apolice { get; set; }

        public DateTime Data { get; set; }
               
        public decimal Valor { get; set; }

        public string PathComprovantePDF { get; set; }
    }
}
