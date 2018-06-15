using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSqlCe.Dal
{
    public class Abastecimento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        public int CombustivelId { get; set; }
                
        [Required]
        public decimal Valor { get; set; }

        [Required]
        public long KM { get; set; }

        public string PathComprovantePDF { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public string DataS { get; set; }
                
        public string VeiculoID { get; set; }

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }
    }
}
