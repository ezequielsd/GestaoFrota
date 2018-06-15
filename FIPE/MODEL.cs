using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPE
{
    public class TipoFIPEinfo
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }

    public class MarcaFIPEinfo
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
    }

    public class CarroFIPEinfo
    {
        public long id { get; set; }
        public string fipe_marca { get; set; }
        public string name { get; set; }
        public string marca { get; set; }
        public string key { get; set; }
        public string fipe_name { get; set; }
    }

    public class CarroAnoFIPEinfo
    {
        public string id { get; set; }
        public string fipe_marca { get; set; }
        public string fipe_codigo { get; set; }
        public string name { get; set; }
        public string marca { get; set; }
        public string key { get; set; }
        public string veiculo { get; set; }
    }

    public class ConsultaFIPEinfo
    {
        public string fipe_codigo { get; set; }
        public string combustivel { get; set; }
        public string marca { get; set; }
        public string ano_modelo { get; set; }
        public string preco { get; set; }
        public string key { get; set; }
        public string veiculo { get; set; }
        public int id { get; set; }
        public string referencia { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }
}
