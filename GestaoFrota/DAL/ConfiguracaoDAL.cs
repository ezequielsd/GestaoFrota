using CFSqlCe.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public class ConfiguracaoDAL
    {
        public Configuracao Get()
        {
            using (var context = new Context())
            {
                return context.Configuracaos.ToList().FirstOrDefault();
            }
        }
    }
}
