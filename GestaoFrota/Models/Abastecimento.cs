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
        public decimal QuantidadeGasolina { get; set; } = 0;

        public decimal QuantidadeGNV { get; set; } = 0;

        public decimal QuantidadeAlcool { get; set; } = 0;

        public decimal QuantidadeDiesel { get; set; } = 0;

        public decimal ValorGasolina { get; set; } = 0;

        public decimal ValorGNV { get; set; } = 0;

        public decimal ValorAlcool { get; set; } = 0;

        public decimal ValorDiesel { get; set; } = 0;

        public long KM { get; set; } = 0;
    }

    /// <summary>
    /// Classe modelo para informra a autonomia 
    /// </summary>
    public class AutonomiaInfo
    {   
        public string Mes { get; set; }
        public string MediaAlcool { get; set; }
        public string MediaGasolina { get; set; }
        public string MediaGNV { get; set; }
        public string MediaDiesel { get; set; }
    }

    /// <summary>
    /// Classe modelo para informar custo diario
    /// </summary>
    public class CustoDiario
    {
        public int DiasAlcool { get; set; }

        public int DiasGasolina { get; set; }

        public int DiasGNV { get; set; }

        public int DiasDiesel { get; set; }

        public decimal CustoAlcool { get; set; }

        public decimal CustoGasolina { get; set; }

        public decimal CustoGNV { get; set; }

        public decimal CustoDiesel { get; set; }

        public decimal TotalDiasRegistro { get; set; }
    }
}
