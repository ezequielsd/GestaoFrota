using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSqlCe.Dal;
using GestaoFrota.DAL;

namespace GestaoFrota.BLL
{
    public sealed class CombustivelBLL
    {
        #region Variaveis

        CombustivelDAL dal = CombustivelDAL.Instancia;

        #endregion

        #region Propriedades

        static CombustivelBLL _instancia;
        public static CombustivelBLL Instancia
        {
            get { return _instancia ?? (_instancia = new CombustivelBLL()); }
        }

        #endregion

        #region Construtores

        private CombustivelBLL() { }

        #endregion

        /// <summary>
        /// Lista tipos de combustiveis
        /// </summary>
        /// <returns>Lista de tipos de combustiveis</returns>
        public List<Combustivel> GetList()
        {
            return dal.List();
        }

        /// <summary>
        /// Lista tipos de combustiveis
        /// </summary>
        /// <returns>Lista de tipos de combustiveis</returns>
        public List<Combustivel> GetList(Veiculo veiculo)
        {
            return dal.List(veiculo);
        }

        /// <summary>
        /// Busca combustivel pelo id
        /// </summary>
        /// <param name="id">id do combustivel</param>
        /// <returns>retorna o tipo de combustivel</returns>
        public Combustivel GetCombustivel(int id)
        {
            return dal.Get(id);
        }

        /// <summary>
        /// Busca id do combustivel
        /// </summary>
        /// <param name="combustivel">Tipo combustivel</param>
        /// <returns>id do combustivel</returns>
        public int GetIdCombustivel(string combustivel)
        {
            return dal.GetIdCombustivel(combustivel);
        }
    }
}
