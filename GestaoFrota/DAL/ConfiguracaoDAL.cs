using CFSqlCe.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public sealed class ConfiguracaoDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static ConfiguracaoDAL _instancia;
        public static ConfiguracaoDAL Instancia
        {
            get { return _instancia ?? (_instancia = new ConfiguracaoDAL()); }
        }

        #endregion

        #region Construtores

        private ConfiguracaoDAL() { }

        #endregion

        public Configuracao Get()
        {
            using (var context = new Context())
            {
                return context.Configuracaos.ToList().FirstOrDefault();
            }
        }

        public void Insert(Configuracao config)
        {
            using(var context = new Context())
            {
                context.Configuracaos.Add(config);
                context.SaveChanges();
            }
        }
    }
}
