using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    /// <summary>
    /// Modelo de movimentação de Oleo para o GridView
    /// </summary>
    public class DGridOleoInfo
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string DataS { get; set; }
                
        public string TipoOperacao { get; set; }
                
        public string TipoOleo { get; set; }
        
        public decimal Quantidade { get; set; }

        public long KM { get; set; }

        public decimal Valor { get; set; }

        public string PathComprovantePDF { get; set; }
    }

    /// <summary>
    /// Modelo de totais de movimentação de oleo
    /// </summary>
    public class GastoOleoInfo
    {
        public decimal TotalQuantidadeCompletarOleo { get; set; }

        public decimal TotalValorCompletarOleo { get; set; }
                
        public decimal TotalValorTrocaOleo { get; set; }

        public decimal TotalValor { get; set; }
    }
}
