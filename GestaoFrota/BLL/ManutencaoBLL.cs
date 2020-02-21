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
        ManutencaoDAL dal = ManutencaoDAL.Instancia;

        public void Insert(Manutencao info)
        {
            info.DataS = info.Data.ToShortDateString();
            dal.Insert(info);
        }
     
        public List<DGridManutencaoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
           return  dal.ListParcialAnual(dtAtual, veiculo);            
        }
       
        public List<DGridManutencaoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.List(dtInicial, dtFinal, veiculo);            
        }
       
        public Manutencao Get(int id)
        {
            return dal.Get(id);
        }

        public GastoManutencaoInfo GetGasto(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.GetGasto(dtInicial, dtFinal, veiculo);
        }

        public GastoManutencaoInfo GetGastoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return dal.GetGastoAnual(dtAtual, veiculo);
        }

        public GastoManutencaoInfo GetGasto(Veiculo veiculo)
        {
            return dal.GetGasto(veiculo);
        }

        public List<Manutencao> ListExport()
        {
            return dal.ListExport();
        }
       
        public void AnexarComprovante(int id, string pathComprovante)
        {
            dal.AnexarComprovante(id, pathComprovante);
        }

        public List<TipoManutencao> ListTipoManutencao()
        {
            return dal.ListTipoManutencao();
        }

        public void InsertTipoManutencao(TipoManutencao tipoManutencao)
        {
            dal.InsertTipoManutencao(tipoManutencao);
        }

        public TipoManutencao GetTipoManutencao(int id)
        {
            return dal.GetTipoManutencao(id);
        }

        public void DeleteTipoManutencao(int id)
        {
            dal.DeleteTipoManutencao(id);
        }
    }
}
