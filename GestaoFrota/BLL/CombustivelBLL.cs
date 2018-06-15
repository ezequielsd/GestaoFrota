using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSqlCe.Dal;
using GestaoFrota.DAL;

namespace GestaoFrota.BLL
{
    public class CombustivelBLL
    {
        /// <summary>
        /// Lista tipos de combustiveis
        /// </summary>
        /// <returns>Lista de tipos de combustiveis</returns>
        public List<Combustivel> GetList()
        {
            return new CombustivelDAL().GetList();
        }

        /// <summary>
        /// Lista tipos de combustiveis
        /// </summary>
        /// <returns>Lista de tipos de combustiveis</returns>
        public List<Combustivel> GetList(Veiculo veiculo)
        {
            return new CombustivelDAL().GetList(veiculo);
        }

        /// <summary>
        /// Busca combustivel pelo id
        /// </summary>
        /// <param name="id">id do combustivel</param>
        /// <returns>retorna o tipo de combustivel</returns>
        public Combustivel GetCombustivel(int id)
        {
            return new CombustivelDAL().GetCombustivel(id);
        }

        /// <summary>
        /// Busca id do combustivel
        /// </summary>
        /// <param name="combustivel">Tipo combustivel</param>
        /// <returns>id do combustivel</returns>
        public int GetIdCombustivel(string combustivel)
        {
            return new CombustivelDAL().GetIdCombustivel(combustivel);
        }
    }
}
