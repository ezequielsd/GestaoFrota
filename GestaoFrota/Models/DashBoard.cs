using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    public class graficoPizzaInfo
    {
        public decimal Total { get; set; }

        public decimal TotalCombustivel { get; set; }

        public decimal TotalManutencao { get; set; }
            
        public decimal TotalMulta { get; set; }

        public decimal TotalSeguro { get; set; }

        public decimal TotalDocumento { get; set; }
    }
}
