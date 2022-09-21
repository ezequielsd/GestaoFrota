using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public class ManutencaoDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static ManutencaoDAL _instancia;
        public static ManutencaoDAL Instancia
        {
            get { return _instancia ?? (_instancia = new ManutencaoDAL()); }
        }

        #endregion

        #region Construtores

        private ManutencaoDAL() { }

        #endregion

        public void Insert(Manutencao manutencao)
        {
            using (var context = new Context())
            {                
                manutencao.MecanicaID = manutencao.MecanicaID;
                manutencao.Veiculo = context.Veiculos.Find(manutencao.Veiculo.Placa);
                context.Manutencoes.Add(manutencao);
                context.SaveChanges();                
            }
        }
                
        public List<DGridManutencaoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Manutencoes.Where(w => w.Data.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridManutencaoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,
                    KM = s.KM,
                    Valor = s.Valor,
                    //Descricao = context.Mecanicas.Where(w => w.Id.Equals(s.Mecanica.Id)).Select(s2 => s2.Nome).FirstOrDefault(),
                    Descricao = s.Descricao,
                    PathComprovantePDF = (String.IsNullOrEmpty(s.PathComprovantePDF)) ? "Não" : "sim"
                }).OrderByDescending(o => o.Data).ToList();
            }
        }
                
        public List<DGridManutencaoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Manutencoes.Where(w => w.Data >= dtInicial && w.Data <= dtFinal && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridManutencaoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,  
                    KM = s.KM,
                    Valor = s.Valor,
                    //Mecanica = context.Mecanicas.Where(w => w.Id.Equals(s.Mecanica.Id)).Select(s2 => s2.Nome).FirstOrDefault(),
                    Descricao = s.Descricao,
                    PathComprovantePDF = (String.IsNullOrEmpty(s.PathComprovantePDF)) ? "Não" : "sim"
                }).OrderByDescending(o => o.Data).ToList();
            }
        }

        public Manutencao Get(int id)
        {
            using (var context = new Context())
            {
                Manutencao manutencao = context.Manutencoes.Find(id);
                manutencao.Mecanica = context.Mecanicas.Find(manutencao.MecanicaID);
                manutencao.TipoManutencao = (manutencao.TipoManutencaoID == null) ? "" : context.TipoManutencaos.Find(manutencao.TipoManutencaoID).Descricao;

                return manutencao;
            }
        }
                
        public GastoManutencaoInfo GetGasto(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            GastoManutencaoInfo gasto = new GastoManutencaoInfo
            {
                TotalValor = 0
            };

            using (var context = new Context())
            {
                //busca o abastecimento do veiculo conforme range de data 
                List<DGridManutencaoInfo> list = context.Manutencoes.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridManutencaoInfo
                    {
                        Id = s.Id,
                        Data = s.Data,
                        DataS = s.DataS,
                        KM = s.KM,
                        Valor = s.Valor,
                        //Mecanica = context.Mecanicas.Where(w => w.Id.Equals(s.Mecanica.Id)).Select(s2 => s2.Nome).FirstOrDefault(),
                        Descricao = s.Descricao,
                        PathComprovantePDF = (String.IsNullOrEmpty(s.PathComprovantePDF)) ? "Não" : "sim"
                    }).ToList();

                gasto.TotalValor = list.Select(s => s.Valor).Sum();                
            }

            return gasto;
        }
          
        public GastoManutencaoInfo GetGastoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            GastoManutencaoInfo gasto = new GastoManutencaoInfo
            {
                TotalValor = 0
            };

            using (var context = new Context())
            {
                //busca o abastecimento do veiculo conforme range de data 
                List<DGridManutencaoInfo> list = context.Manutencoes.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa) && w.Data.Year.Equals(dtAtual.Year)).
                    Select(s => new DGridManutencaoInfo
                    {
                        Id = s.Id,
                        Data = s.Data,
                        DataS = s.DataS,
                        KM = s.KM,
                        Valor = s.Valor,
                        Descricao = s.Descricao,
                        PathComprovantePDF = (String.IsNullOrEmpty(s.PathComprovantePDF)) ? "Não" : "sim"
                    }).ToList();

                gasto.TotalValor = list.Select(s => s.Valor).Sum();
            }

            return gasto;
        }

        public GastoManutencaoInfo GetGasto(Veiculo veiculo)
        {
            GastoManutencaoInfo gasto = new GastoManutencaoInfo
            {
                TotalValor = 0
            };

            using (var context = new Context())
            {
                //busca o abastecimento do veiculo conforme range de data 
                List<DGridManutencaoInfo> list = context.Manutencoes.Where(w => w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridManutencaoInfo
                    {
                        Id = s.Id,
                        Data = s.Data,
                        DataS = s.DataS,
                        KM = s.KM,
                        Valor = s.Valor,
                        Descricao = s.Descricao,
                        PathComprovantePDF = (String.IsNullOrEmpty(s.PathComprovantePDF)) ? "Não" : "Sim"
                    }).ToList();

                gasto.TotalValor = list.Select(s => s.Valor).Sum();
            }

            return gasto;
        }
                
        public List<Manutencao> ListExport()
        {
            using (var context = new Context())
            {
                return context.Manutencoes.ToList();
            }
        }
                
        public void AnexarComprovante(int id, string pathComprovante)
        {
            using (var context = new Context())
            {
                var manu = context.Manutencoes.Find(id);
                manu.PathComprovantePDF = pathComprovante;
                context.SaveChanges();
            }
        }             

        public List<TipoManutencao> ListTipoManutencao()
        {
            using (var context = new Context())
            {
                return context.TipoManutencaos.ToList();
            }
        }

        public void InsertTipoManutencao(TipoManutencao tipoManutencao)
        {
            using (var context = new Context())
            {
                context.TipoManutencaos.Add(tipoManutencao);
                context.SaveChanges();
            }
        }

        public TipoManutencao GetTipoManutencao(int id)
        {
            using (var context = new Context())
            {
                return context.TipoManutencaos.Find(id);
            }
        }

        public void DeleteTipoManutencao(int id)
        {
            using (var context = new Context())
            {
                var tipo = context.TipoManutencaos.Find(id);
                context.TipoManutencaos.Remove(tipo);
                context.SaveChanges();
            }
        }
    }
}
