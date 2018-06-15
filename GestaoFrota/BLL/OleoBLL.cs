using CFSqlCe.Dal;
using GestaoFrota.DAL;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.BLL
{
    public class OleoBLL
    {        
        public void Insert(Veiculo veiculo, Oleo oleo)
        {
            oleo.DataS = oleo.Data.ToShortDateString();
            new OleoDAL().Insert(veiculo, oleo);
        }

        public List<DGridOleoInfo> List(DateTime dataAtual, Veiculo veiculo)
        {
            return new OleoDAL().List(dataAtual, veiculo);            
        }

        public List<DGridOleoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new OleoDAL().List(dtInicial, dtFinal, veiculo);
        }

        public GastoOleoInfo GetGasto(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new OleoDAL().GetGasto(dtInicial, dtFinal, veiculo);
        }

        public GastoOleoInfo GetGastoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return new OleoDAL().GetGastoAnual(dtAtual, veiculo);
        }

        public void AnexarComprovante(int id, string pathComprovante)
        {
            new OleoDAL().AnexarComprovante(id, pathComprovante);
        }

        public List<Oleo> ListExport()
        {
            return new OleoDAL().ListExport();
        }
    }
}
