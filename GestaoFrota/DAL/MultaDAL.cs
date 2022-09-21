using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public sealed class MultaDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static MultaDAL _instancia;
        public static MultaDAL Instancia
        {
            get { return _instancia ?? (_instancia = new MultaDAL()); }
        }

        #endregion

        #region Construtores

        private MultaDAL() { }

        #endregion

        public void Insert(Multa multa)
        {
            using (var context = new Context())
            {
                multa.Veiculo = context.Veiculos.Find(multa.Veiculo.Placa);
                context.Multas.Add(multa);
                context.SaveChanges();
            }
        }

        public List<DGridMultaInfo> List(Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridMultaInfo
                {
                    Id = s.Id,
                    DataOcorrencia = s.DataOcorrencia,
                    DataVencimento = s.DataVencimento,
                    DataOcorrenciaS = s.DataOcorrenciaS,
                    DataVencimentoS = s.DataVencimentoS,    
                    DataPagamento = s.DataPagamento,
                    DataPagamentoS = s.DataPagamentoS,
                    Valor = s.Valor,
                    Status = s.PagamentoRealizado ? "Pago" : "", 
                    PathComprovantePDF = s.PathAnexoMultaPDF,                 
                    LocalComplemento = s.LocalOcorrencia
                }).OrderByDescending(o => o.Id).ToList();
            }
        }

        public List<DGridMultaInfo> List(DateTime dataInicial, DateTime dataFinal, int tipoMulta, int tipoDataFiltro, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                if(tipoDataFiltro == 0)
                {
                    switch (tipoMulta)
                    {
                        case 1:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataVencimento >= dataInicial && w.DataVencimento <= dataFinal) && !w.PagamentoRealizado).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                        case 2:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataVencimento >= dataInicial && w.DataVencimento <= dataFinal) && w.PagamentoRealizado == true).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                        default:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataVencimento >= dataInicial && w.DataVencimento <= dataFinal)).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                    }
                }
                else
                {
                    switch (tipoMulta)
                    {
                        case 1:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataOcorrencia >= dataInicial && w.DataOcorrencia <= dataFinal) && !w.PagamentoRealizado).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                        case 2:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataOcorrencia >= dataInicial && w.DataOcorrencia <= dataFinal) && w.PagamentoRealizado == true).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                        default:
                            return context.Multas.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && (w.DataOcorrencia >= dataInicial && w.DataOcorrencia <= dataFinal)).Select(s => new DGridMultaInfo
                            {
                                Id = s.Id,
                                DataOcorrencia = s.DataOcorrencia,
                                DataVencimento = s.DataVencimento,
                                DataOcorrenciaS = s.DataOcorrenciaS,
                                DataVencimentoS = s.DataVencimentoS,
                                Valor = s.Valor,
                                Status = s.PagamentoRealizado ? "Pago" : "",
                                PathComprovantePDF = s.PathAnexoMultaPDF
                            }).ToList();
                    }
                }                         
            }
        }

        public List<Multa> List()
        {
            using (var context = new Context())
            {
                return context.Multas.Where(w => !w.PagamentoRealizado).ToList();
            }
        }

        public decimal GetMultaTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Multas.Where(w => (w.DataPagamento.Year.Equals(dataAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa))).Select(s => (decimal?)s.Valor).Sum() ?? 0;
            }
        }

        public decimal GetMultaPorPeriodo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Multas.Where(w => (w.DataPagamento >= dtInicial && w.DataPagamento <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => (decimal?)s.Valor).Sum() ?? 0;
            }
        }
                
        public void SetPagamento(int id, DateTime dataPagamento)
        {
            using (var context = new Context())
            {
                var info = context.Multas.Find(id);

                info.PagamentoRealizado = true;
                info.DataPagamento = dataPagamento;
                info.DataPagamentoS = dataPagamento.ToShortDateString();

                context.SaveChanges();
            }
        }

        public void AnexarComprovante(int id, string pathComprovante)
        {
            using (var context = new Context())
            {
                var multa = context.Multas.Find(id);
                multa.PathAnexoMultaPDF = pathComprovante;
                context.SaveChanges();
            }
        }
    }
}
