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
    public sealed class AbastecimentoBLL
    {

        #region Propriedades

        //Aplicando o Pattern Singleton
        static AbastecimentoBLL _instancia;
        public static AbastecimentoBLL Instancia
        {
            get { return _instancia ?? (_instancia = new AbastecimentoBLL()); }
        }

        #endregion

        #region Construtores

        private AbastecimentoBLL() { }

        #endregion

        AbastecimentoDAL dal = AbastecimentoDAL.Instancia;

        public void Insert(Abastecimento info)
        {
            info.DataS = info.Data.ToShortDateString();
            dal.Insert(info);            
        }

        public List<DGridAbastecimentoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.List(dtInicial, dtFinal, veiculo);
        }

        public List<DGridAbastecimentoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return dal.ListParcialAnual(dtAtual, veiculo);           
        }
      
        public List<DGridAbastecimentoInfo> ListPorFiltro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, int combustivel)
        {
           return dal.ListPorFiltro(dtInicial, dtFinal, veiculo, combustivel);            
        }
      
        public ConsumoInfo GetConsumo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.GetConsumo(dtInicial, dtFinal, veiculo);
        }

        public ConsumoInfo GetConsumoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return dal.GetConsumoAnual(dtAtual, veiculo);
        }

        public CustoDiario GetDiasRegistroParcialAnual(DateTime dtAtual, Veiculo veiculo) 
        {
            return dal.GetDiasRegistroParcialAnual(dtAtual, veiculo);
        }

        public CustoDiario GetDiasRegistro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.GetDiasRegistro(dtInicial, dtFinal, veiculo);
        }

        public List<Abastecimento> ListExport()
        {
            return dal.ListExport();
        }
       
        public void AnexarComprovante(int id, string pathComprovante)
        {
            dal.AnexarComprovante(id, pathComprovante);
        }

        public List<AutonomiaInfo> GetAutonomia(DateTime dataMes, Veiculo veiculo)
        {
            return dal.GetAutonomia(dataMes, veiculo);
        }
    }
}
