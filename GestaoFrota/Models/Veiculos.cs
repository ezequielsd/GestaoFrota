using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.Models
{
    /// <summary>
    /// clase para o modelo para clase veiculo
    /// </summary>
    public class VeiculosTreeViewInfo
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public override string ToString()
        {
            return $"{this.Placa}_{this.Marca}_{this.Modelo}" ;
        }
    }
}
