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
    public sealed class PagamentoDocumentoBLL
    {
        #region Variaveis

        PagamentoDocumentoDAL dal = PagamentoDocumentoDAL.Instancia;

        #endregion

        #region Propriedades

        //Aplicando o Pattern Singleton
        static PagamentoDocumentoBLL _instancia;
        public static PagamentoDocumentoBLL Instancia
        {
            get { return _instancia ?? (_instancia = new PagamentoDocumentoBLL()); }
        }

        #endregion

        #region Construtores

        private PagamentoDocumentoBLL() { }

        #endregion


        public void Insert(PagamentoDocumento info)
        {
            if (info.DataPagamento.Year > 2000)
                info.DataPagamentoS = info.DataPagamento.ToShortDateString();
            if (info.DataVencimento.Year > 2000)
                info.DataVencimentoS = info.DataVencimento.ToShortDateString();

            dal.Insert(info);
        }

        public List<DGridPagamentoDocumentoInfo> List(DateTime dtAtual, Veiculo veiculo)
        {
            return dal.List(dtAtual, veiculo);
        }

        public decimal GetoPagamentoDocumentoTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            return dal.GetoPagamentoDocumentoTotalAnual(dataAtual, veiculo);
        }

        public int GetPagamentoDocumentoLancadoDoAno(DateTime dataAtual, string veiculoPlaca)
        {
            return dal.GetPagamentoDocumentoLancadoDoAno(dataAtual, veiculoPlaca);
        }

        public List<PagamentoDocumento> GetDocumentoNaoPago(DateTime dataAtual, string veiculoPlaca)
        {
            return dal.GetDocumentoNaoPago(dataAtual, veiculoPlaca);
        }

        public void InformarPagamento(int id, DateTime dataPagamento)
        {
            dal.InformarPagamento(id, dataPagamento);
        }
    }
}
