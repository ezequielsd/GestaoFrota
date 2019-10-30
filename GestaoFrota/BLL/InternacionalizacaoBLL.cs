using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.BLL
{
    public static class InternacionalizacaoBLL
    {
        /// <summary>
        /// Referencia https://lonewolfonline.net/list-net-culture-country-codes/
        /// </summary>
        /// <returns></returns>
        public static List<Internacionalizacao> ListInternacionalizacao()
        {
            return new List<Internacionalizacao>
            {
                new Internacionalizacao{Pais = "Brazil", CodPais = "BRA", Idioma = "Portuguese", CodCultura = "pt-BR"},
                new Internacionalizacao{Pais = "Portugal", CodPais = "PRT", Idioma = "Portuguese", CodCultura = "pt-PT"}
            };
        }
    }
}
