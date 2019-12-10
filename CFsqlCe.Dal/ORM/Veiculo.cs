using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSqlCe.Dal
{
    public class Veiculo
    {
        [Key]
        [StringLength(100)]
        public string Placa { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        [StringLength(200)]
        public string FipeNameMarca { get; set; }      

        [StringLength(200)]
        public string FIPEModelo { get; set; }  

        [StringLength(200)]
        public string FipeNameAno { get; set; }       
        
        [StringLength(100)]
        public string Renavam { get; set; }

        [StringLength(200)]
        public string Chassi { get; set; }
                                
        public int Combustivel { get; set; }

        [StringLength(50)]
        public string AnoFab { get; set; }

        [StringLength(50)]
        public string AnoModelo { get; set; }

        [StringLength(100)]
        public string Capacidade { get; set; }

        [StringLength(200)]
        public string Cor { get; set; }

        [StringLength(300)]
        public string Cidade { get; set; }

        [StringLength(50)]
        public string UF { get; set; }

        [StringLength(100)]
        public string CPFCNPJ { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        public long? KM { get; set; }

        [StringLength(500)]
        public string NomeEndereco { get; set; }

        [StringLength(40)]
        public string DataAquisicao { get; set; }

        [StringLength(500)]
        public string Observacao { get; set; }

        [StringLength(200)]
        public string Potencia { get; set; }

        [StringLength(25)]
        public string CultureInfo { get; set; }

        [StringLength(200)]
        public string MedidasPneus { get; set; }

        [StringLength(25)]
        public string CodigoPostal { get; set; }

        public string PathDocumentoPDF { get; set; }

        public DateTime DataVencimentoIPVA { get; set; }

        public bool? Ativo { get; set; }
                        
        public List<Abastecimento> Abastecimentos { get; set; }

        public List<Manutencao> Manutencoes { get; set; }
    }
}
