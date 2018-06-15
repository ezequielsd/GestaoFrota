using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class Oleo
    {
        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string DataS { get; set; }

        [StringLength(200)]
        public string TipoOperacao { get; set; }

        [StringLength(100)]
        public string TipoOleo { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }

        public long KM { get; set; }

        public string PathComprovantePDF { get; set; }

        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
