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
    public class ManutencaoBLL
    {
       
        public void Insert(Manutencao info)
        {
            info.DataS = info.Data.ToShortDateString();
            new ManutencaoDAL().Insert(info);
        }
     
        public List<DGridManutencaoInfo> List(Veiculo veiculo)
        {
           return new ManutencaoDAL().List(veiculo);            
        }
       
        public List<DGridManutencaoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new ManutencaoDAL().List(dtInicial, dtFinal, veiculo);            
        }
       
        public GastoManutencaoInfo GetGasto(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new ManutencaoDAL().GetGasto(dtInicial, dtFinal, veiculo);
        }

        public GastoManutencaoInfo GetGastoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return new ManutencaoDAL().GetGastoAnual(dtAtual, veiculo);
        }

        public GastoManutencaoInfo GetGasto(Veiculo veiculo)
        {
            return new ManutencaoDAL().GetGasto(veiculo);
        }

        public List<Manutencao> ListExport()
        {
            return new ManutencaoDAL().ListExport();
        }
       
        public void AnexarComprovante(int id, string pathComprovante)
        {
            new ManutencaoDAL().AnexarComprovante(id, pathComprovante);
        }
    }
}
