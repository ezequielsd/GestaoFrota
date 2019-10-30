using CFSqlCe.Dal;
using GestaoFrota.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.BLL
{
    public class ConfiguracaoBLL
    {
        public Configuracao Get()
        {
            return new ConfiguracaoDAL().Get();
        }
    }
}
