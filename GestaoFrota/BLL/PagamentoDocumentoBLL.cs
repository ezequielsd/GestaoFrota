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
    public class PagamentoDocumentoBLL
    {
        public void Insert(PagamentoDocumento info)
        {
            if (info.DataPagamento.Year > 2000)
                info.DataPagamentoS = info.DataPagamento.ToShortDateString();
            if (info.DataVencimento.Year > 2000)
                info.DataVencimentoS = info.DataVencimento.ToShortDateString();

            new PagamentoDocumentoDAL().Insert(info);
        }

        public List<DGridPagamentoDocumentoInfo> List(DateTime dtAtual, Veiculo veiculo)
        {
            return new PagamentoDocumentoDAL().List(dtAtual, veiculo);
        }

        public decimal GetoPagamentoDocumentoTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            return new PagamentoDocumentoDAL().GetoPagamentoDocumentoTotalAnual(dataAtual, veiculo);
        }

        public int GetPagamentoDocumentoLancadoDoAno(DateTime dataAtual, string veiculoPlaca)
        {
            return new PagamentoDocumentoDAL().GetPagamentoDocumentoLancadoDoAno(dataAtual, veiculoPlaca);
        }

        public List<PagamentoDocumento> GetDocumentoNaoPago(DateTime dataAtual, string veiculoPlaca)
        {
            return new PagamentoDocumentoDAL().GetDocumentoNaoPago(dataAtual, veiculoPlaca);
        }

        public void InformarPagamento(int id, DateTime dataPagamento)
        {
            new PagamentoDocumentoDAL().InformarPagamento(id, dataPagamento);
        }
    }
}
