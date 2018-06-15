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
    public class DGridCNHInfo
    {        
        public string NumeroRegistro { get; set; }
             
        public string Nome { get; set; }               

        public DateTime Validade { get; set; }
    }
}
