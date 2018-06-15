using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public class OleoDAL
    {        
        public void Insert(Veiculo veiculo, Oleo oleo)
        {
            using (var context = new Context())
            {
                oleo.Veiculo = context.Veiculos.Find(veiculo.Placa);

                context.Oleos.Add(oleo);
                context.SaveChanges();
            }
        }
             
        public List<DGridOleoInfo> List(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Oleos.Where(w => w.Data.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridOleoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,
                    Quantidade = s.Quantidade,
                    TipoOleo = s.TipoOleo,
                    TipoOperacao = s.TipoOperacao,
                    Valor = s.Valor,
                    KM = s.KM,
                    PathComprovantePDF = s.PathComprovantePDF
                }).OrderByDescending(o => o.Data).ToList();
            }
        }

        public List<DGridOleoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Oleos.Where(w => w.Data >= dtInicial && w.Data <= dtFinal && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridOleoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,
                    Quantidade = s.Quantidade,
                    TipoOleo = s.TipoOleo,
                    TipoOperacao = s.TipoOperacao,
                    Valor = s.Valor,
                    KM = s.KM,
                    PathComprovantePDF = s.PathComprovantePDF
                }).OrderByDescending(o => o.Data).ToList();
            }
        }
                
        public GastoOleoInfo GetGasto(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            GastoOleoInfo consumo = new GastoOleoInfo
            {
                TotalQuantidadeCompletarOleo = 0,
                TotalValorCompletarOleo = 0,
                TotalValorTrocaOleo = 0,
                TotalValor = 0
            };

            using (var context = new Context())
            {
                
                //busca o abastecimento do veiculo conforme range de data 
                List<DGridOleoInfo> list = context.Oleos.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridOleoInfo
                    {
                        Data = s.Data,
                        TipoOperacao = s.TipoOperacao,                        
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).ToList();

                consumo.TotalQuantidadeCompletarOleo = list.Where(w => w.TipoOperacao.Equals("Completar o nível do óleo")).Select(s => s.Quantidade).Sum();
                consumo.TotalValorCompletarOleo = list.Where(w => w.TipoOperacao.Equals("Completar o nível do óleo")).Select(s => s.Valor).Sum();
                consumo.TotalValorTrocaOleo = list.Where(w => w.TipoOperacao.Equals("Troca de óleo")).Select(s => s.Valor).Sum();
                consumo.TotalValor = list.Select(s => s.Valor).Sum();                
            }

            return consumo;
        }

        public GastoOleoInfo GetGastoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            GastoOleoInfo consumo = new GastoOleoInfo
            {
                TotalQuantidadeCompletarOleo = 0,
                TotalValorCompletarOleo = 0,
                TotalValorTrocaOleo = 0,
                TotalValor = 0
            };

            using (var context = new Context())
            {

                //busca o abastecimento do veiculo conforme range de data 
                List<DGridOleoInfo> list = context.Oleos.Where(w => w.Data.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridOleoInfo
                    {
                        Data = s.Data,
                        TipoOperacao = s.TipoOperacao,
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).ToList();

                consumo.TotalQuantidadeCompletarOleo = list.Where(w => w.TipoOperacao.Equals("Completar o nível do óleo")).Select(s => s.Quantidade).Sum();
                consumo.TotalValorCompletarOleo = list.Where(w => w.TipoOperacao.Equals("Completar o nível do óleo")).Select(s => s.Valor).Sum();
                consumo.TotalValorTrocaOleo = list.Where(w => w.TipoOperacao.Equals("Troca de óleo")).Select(s => s.Valor).Sum();
                consumo.TotalValor = list.Select(s => s.Valor).Sum();
            }

            return consumo;
        }
                
        public void AnexarComprovante(int id, string pathComprovante)
        {
            using (var context = new Context())
            {
                var oleo = context.Oleos.Find(id);
                oleo.PathComprovantePDF = pathComprovante;
                context.SaveChanges();
            }
        }

        public List<Oleo> ListExport()
        {
            using (var context = new Context())
            {
                return context.Oleos.ToList();
            }
        }
    }
}
