using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    /// <summary>
    /// Classe modelo para informaçoes no grid de abastecimento
    /// </summary>
    public class DGridAbastecimentoInfo
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string DataS { get; set; }

        public long KM { get; set; }

        public string Combustivel { get; set; }

        public decimal Quantidade { get; set; }
     
        public decimal Valor { get; set; }

        public string PathComprovantePDF { get; set; }
    }

    /// <summary>
    /// Classe modelo para informações de consumo
    /// </summary>
    public class ConsumoInfo
    {
        public decimal QuantidadeGasolina { get; set; }

        public decimal QuantidadeGNV { get; set; }

        public decimal QuantidadeAlcool { get; set; }

        public decimal QuantidadeDiesel { get; set; }

        public decimal ValorGasolina { get; set; }

        public decimal ValorGNV { get; set; }

        public decimal ValorAlcool { get; set; }

        public decimal ValorDiesel { get; set; }

        public long KM { get; set; }
    }

    /// <summary>
    /// Classe modelo para informa a autonomia 
    /// </summary>
    public class AutonomiaInfo
    {   
        public string Mes { get; set; }
        public string MediaAlcool { get; set; }
        public string MediaGasolina { get; set; }
        public string MediaGNV { get; set; }
        public string MediaDiesel { get; set; }
    }

    
}
