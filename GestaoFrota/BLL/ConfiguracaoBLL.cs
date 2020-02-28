using CFSqlCe.Dal;
using GestaoFrota.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.BLL
{
    public sealed class ConfiguracaoBLL
    {
        #region Variaveis

        ConfiguracaoDAL configuracaoDAL = ConfiguracaoDAL.Instancia;

        #endregion

        #region Propriedades

        //Aplicando o Pattern Singleton
        static ConfiguracaoBLL _instancia;
        public static ConfiguracaoBLL Instancia
        {
            get { return _instancia ?? (_instancia = new ConfiguracaoBLL()); }
        }

        #endregion

        #region Construtores

        private ConfiguracaoBLL() { }

        #endregion

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
