using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public sealed class PagamentoDocumentoDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static PagamentoDocumentoDAL _instancia;
        public static PagamentoDocumentoDAL Instancia
        {
            get { return _instancia ?? (_instancia = new PagamentoDocumentoDAL()); }
        }

        #endregion

        #region Construtores

        private PagamentoDocumentoDAL() { }

        #endregion

        public void Insert(PagamentoDocumento info)
        {
            using (var context = new Context())
            {
                info.Veiculo = context.Veiculos.Find(info.Veiculo.Placa);
                
                context.PagamentoDocumentos.Add(info);
                context.SaveChanges();
            }
        }

        public List<DGridPagamentoDocumentoInfo> List(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.PagamentoDocumentos.Where(w => w.DataVencimento.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridPagamentoDocumentoInfo
                {           
                    Id = s.Id,
                    DataVencimento = s.DataVencimento,
                    DataVencimentoS = s.DataVencimentoS,
                    Data = s.DataPagamento,
                    DataS = s.DataPagamentoS,                                      
                    Valor = s.Valor,    
                    Descricao = s.Descricao
                }).OrderByDescending(o => o.Id).ToList();
            }
        }

        public decimal GetoPagamentoDocumentoTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.PagamentoDocumentos.Where(w => (w.DataPagamento.Year.Equals(dataAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa))).Select(s => (decimal?)s.Valor).Sum() ?? 0;
            }
        }

        public int GetPagamentoDocumentoLancadoDoAno(DateTime dataAtual, string veiculoPlaca)
        {
            using (var context = new Context())
            {
                return context.PagamentoDocumentos.Where(w => w.DataVencimento.Year.Equals(dataAtual.Year) && w.Veiculo.Placa.Equals(veiculoPlaca)).Count();
            }
        }

        public List<PagamentoDocumento> GetDocumentoNaoPago(DateTime dataAtual, string veiculoPlaca)
        {
            using (var context = new Context())
            {
                return context.PagamentoDocumentos.Where(w => w.DataPagamento.Year.Equals(2000) && w.Veiculo.Placa.Equals(veiculoPlaca)).ToList();
            }
        }

        public void InformarPagamento(int id, DateTime dataPagamento)
        {
            using (var context = new Context())
            {
                var pagamento = context.PagamentoDocumentos.Find(id);
                pagamento.DataPagamento = dataPagamento;
                pagamento.DataPagamentoS = dataPagamento.ToShortDateString();

                context.SaveChanges();
            }
        }
    }
}
