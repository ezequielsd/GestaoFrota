using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public sealed class ContratoSeguradoraDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static ContratoSeguradoraDAL _instancia;
        public static ContratoSeguradoraDAL Instancia
        {
            get { return _instancia ?? (_instancia = new ContratoSeguradoraDAL()); }
        }

        #endregion

        #region Construtores

        private ContratoSeguradoraDAL() { }

        #endregion

        public void Insert(ContratoSeguro info)
        {
            using (var context = new Context())
            {
                info.Veiculo = context.Veiculos.Find(info.Veiculo.Placa);
                info.Seguradora = context.Seguradoras.Find(info.SeguradoraId);

                context.ContratoSeguros.Add(info);
                context.SaveChanges();
            }
        }

        public ContratoSeguro GetSeguroAtivo()
        {
            using (var context = new Context())
            {
                ContratoSeguro contrato = context.ContratoSeguros.Where(w => w.DataFinalContrato >= DateTime.Now && w.Ativo).FirstOrDefault();

                if (contrato != null)
                {
                    contrato.Seguradora = context.Seguradoras.Find(contrato.Id);
                    contrato.Veiculo = context.Veiculos.Find(contrato.VeiculoID);
                }

                return contrato;
            }
        }

        public void EncerrarContrato(ContratoSeguro info)
        {
            using (var context = new Context())
            {
                var con = context.ContratoSeguros.Find(info.Id);

                con.Ativo = info.Ativo;

                context.SaveChanges();
            }
        }

        public void EditarAnexos(ContratoSeguro info)
        {
            using (var context = new Context())
            {
                var con = context.ContratoSeguros.Find(info.Id);

                con.PathCartaoPDF = info.PathCartaoPDF;
                con.PathContratoPDF = info.PathContratoPDF;
                con.PathOrcamentoPDF = info.PathOrcamentoPDF;

                context.SaveChanges();
            }
        }

        public void InsertPagamento(PagamentosSeguro info)
        {
            using (var context = new Context())
            {
                info.Veiculo = context.Veiculos.Find(info.VeiculoID);
                info.ContratoSeguro = context.ContratoSeguros.Find(info.ContratoSeguroId);

                context.PagamentosSeguro.Add(info);
                context.SaveChanges();
            }
        }

        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            using (var context = new Context())
            {
                return context.PagamentosSeguro.Where(w => (w.DataPagamento >= contrato.DataInicialContrato && w.DataPagamento <= contrato.DataFinalContrato) && w.ContratoSeguroId.Equals(contrato.Id) && w.VeiculoID.Equals(veiculo.Placa)).
                    Select(s => new DGridPagamentoSeguroInfo
                    {
                        Id = s.Id,
                        Data = s.DataPagamento,
                        Valor = s.Valor,
                        Apolice = context.ContratoSeguros.Where(w => w.Id == s.ContratoSeguroId).Select(s2 => s2.NumeroApolice).FirstOrDefault(),
                        PathComprovantePDF = s.PathPagamentoPDF
                    }).ToList();
            }
        }

        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.PagamentosSeguro.Where(w => (w.DataPagamento >= dtInicial && w.DataPagamento <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridPagamentoSeguroInfo
                    {
                        Id = s.Id,
                        Data = s.DataPagamento,
                        Valor = s.Valor,
                        Apolice = context.ContratoSeguros.Where(w => w.Id == s.ContratoSeguroId).Select(s2 => s2.NumeroApolice).FirstOrDefault(),
                        PathComprovantePDF = s.PathPagamentoPDF
                    }).ToList();
            }
        }

        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.PagamentosSeguro.Where(w => w.Veiculo.Placa == veiculo.Placa && w.ContratoSeguro.SeguradoraId.Equals(seguradoraId)).
                    Select(s => new DGridPagamentoSeguroInfo
                    {
                        Id = s.Id,
                        Data = s.DataPagamento,
                        Valor = s.Valor,
                        Apolice = context.ContratoSeguros.Where(w => w.Id == s.ContratoSeguroId).Select(s2 => s2.NumeroApolice).FirstOrDefault(),
                        PathComprovantePDF = s.PathPagamentoPDF
                    }).ToList();
            }
        }

        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            using (var context = new Context())
            {
                return context.PagamentosSeguro.Where(w => (w.DataPagamento >= contrato.DataInicialContrato && w.DataPagamento <= contrato.DataFinalContrato)
                && w.ContratoSeguroId == contrato.Id && w.VeiculoID == veiculo.Placa && w.ContratoSeguro.SeguradoraId.Equals(seguradoraId)).
                    Select(s => new DGridPagamentoSeguroInfo
                    {
                        Id = s.Id,
                        Data = s.DataPagamento,
                        Valor = s.Valor,
                        Apolice = context.ContratoSeguros.Where(w => w.Id == s.ContratoSeguroId).Select(s2 => s2.NumeroApolice).FirstOrDefault(),
                        PathComprovantePDF = s.PathPagamentoPDF
                    }).ToList();
            }
        }

        public decimal GetPagamentoSeguroAnual(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.PagamentosSeguro.Where(w => w.DataPagamento.Year.Equals(dtAtual.Year) && w.VeiculoID.Equals(veiculo.Placa)).Select(s => (decimal?)s.Valor).Sum() ?? 0;
            }
        }
    }
}
