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
        ConfiguracaoDAL configuracaoDAL = ConfiguracaoDAL.Instancia;

        public Configuracao Get()
        {
            try
            {
                return configuracaoDAL.Get();
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        public void Insert(Configuracao config)
        {
            try
            {
                configuracaoDAL.Insert(config);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
