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
     
        public List<DGridManutencaoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
           return new ManutencaoDAL().ListParcialAnual(dtAtual, veiculo);            
        }
       
        public List<DGridManutencaoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new ManutencaoDAL().List(dtInicial, dtFinal, veiculo);            
        }
       
        public Manutencao Get(int id)
        {
            return new ManutencaoDAL().Get(id);
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

        public List<TipoManutencao> ListTipoManutencao()
        {
            return new ManutencaoDAL().ListTipoManutencao();
        }

        public void InsertTipoManutencao(TipoManutencao tipoManutencao)
        {
            new ManutencaoDAL().InsertTipoManutencao(tipoManutencao);
        }

        public TipoManutencao GetTipoManutencao(int id)
        {
            return new ManutencaoDAL().GetTipoManutencao(id);
        }

        public void DeleteTipoManutencao(int id)
        {
            new ManutencaoDAL().DeleteTipoManutencao(id);
        }
    }
}
