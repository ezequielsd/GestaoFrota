using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSqlCe.Dal
{
    public class Seguradora
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Corretor { get; set; }

        public string Endereco { get; set; }

        [StringLength(50)]
        public string Numero { get; set; }

        [StringLength(200)]
        public string Complemento { get; set; }

        [StringLength(50)]
        public string CEP { get; set; }

        [StringLength(100)]
        public string Bairro { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(50)]
        public string UF { get; set; }

        [StringLength(300)]
        public string Site { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Telefone1 { get; set; }

        [StringLength(100)]
        public string Telefone2 { get; set; }

        [StringLength(100)]
        public string Celular1 { get; set; }

        [StringLength(100)]
        public string Celular1Operadora { get; set; }

        [StringLength(100)]
        public string Celular2 { get; set; }

        [StringLength(100)]
        public string Celular2Operadora { get; set; }

        [StringLength(100)]
        public string Contatos { get; set; }
    }
}
