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
    public class AbastecimentoBLL
    { 
        public void Insert(Abastecimento info)
        {
            info.DataS = info.Data.ToShortDateString();
            new AbastecimentoDAL().Insert(info);
        }

        public List<DGridAbastecimentoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new AbastecimentoDAL().List(dtInicial, dtFinal, veiculo);
        }

        public List<DGridAbastecimentoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return new AbastecimentoDAL().ListParcialAnual(dtAtual, veiculo);           
        }
      
        public List<DGridAbastecimentoInfo> ListPorFiltro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, int combustivel)
        {
           return new AbastecimentoDAL().ListPorFiltro(dtInicial, dtFinal, veiculo, combustivel);            
        }
      
        public ConsumoInfo GetConsumo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new AbastecimentoDAL().GetConsumo(dtInicial, dtFinal, veiculo);
        }

        public ConsumoInfo GetConsumoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return new AbastecimentoDAL().GetConsumoAnual(dtAtual, veiculo);
        }

        public CustoDiario GetDiasRegistroParcialAnual(DateTime dtAtual, Veiculo veiculo) 
        {
            return new AbastecimentoDAL().GetDiasRegistroParcialAnual(dtAtual, veiculo);
        }

        public CustoDiario GetDiasRegistro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new AbastecimentoDAL().GetDiasRegistro(dtInicial, dtFinal, veiculo);
        }

        public List<Abastecimento> ListExport()
        {
            return new AbastecimentoDAL().ListExport();
        }
       
        public void AnexarComprovante(int id, string pathComprovante)
        {
            new AbastecimentoDAL().AnexarComprovante(id, pathComprovante);
        }

        public List<AutonomiaInfo> GetAutonomia(DateTime dataMes, Veiculo veiculo)
        {
            return new AbastecimentoDAL().GetAutonomia(dataMes, veiculo);
        }
    }
}
