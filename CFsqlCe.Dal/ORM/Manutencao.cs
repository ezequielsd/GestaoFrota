using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class Manutencao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }
                
        public string DataS { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public long KM { get; set; }

        public string PathComprovantePDF { get; set; }

        public string VeiculoID { get; set; }        

        [ForeignKey("VeiculoID")]
        public virtual Veiculo Veiculo { get; set; }

        public int MecanicaID { get; set; }

        [NotMapped]
        public Mecanica Mecanica { get; set; }

        public int? TipoManutencaoID { get; set; }

        [NotMapped]
        public string TipoManutencao { get; set; }
       
        public override string ToString()
        {
            return Data.ToShortDateString();
        }
    }

    public class TipoManutencao
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
