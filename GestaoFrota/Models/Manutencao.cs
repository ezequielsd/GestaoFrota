using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    /// <summary>
    /// Modelo para grid de manutencoes
    /// </summary>
    public class DGridManutencaoInfo
    {       
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string DataS { get; set; }

        public long KM { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string PathComprovantePDF { get; set; }
    }

    /// <summary>
    /// Modelo de totais de manutenções
    /// </summary>
    public class GastoManutencaoInfo
    {
        public decimal TotalValor { get; set; }
    }
}
