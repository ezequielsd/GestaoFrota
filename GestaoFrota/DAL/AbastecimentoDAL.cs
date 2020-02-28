using CFSqlCe.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoFrota.Models;
using System.Globalization;

namespace GestaoFrota.DAL
{
    public sealed class AbastecimentoDAL
    {
        #region Variaveis

        CombustivelDAL combustivelDAL = CombustivelDAL.Instancia;

        #endregion

        #region Propriedades

        //Aplicando o Pattern Singleton
        static AbastecimentoDAL _instancia;
        public static AbastecimentoDAL Instancia
        {
            get { return _instancia ?? (_instancia = new AbastecimentoDAL()); }
        }

        #endregion

        #region Construtores

        private AbastecimentoDAL() { }

        #endregion

        public void Insert(Abastecimento info)
        {
            using (var context = new Context())
            {
                info.Veiculo = context.Veiculos.Find(info.Veiculo.Placa);
                context.Abastecimentos.Add(info);
                context.SaveChanges();
            }
        }

        public List<DGridAbastecimentoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Abastecimentos.Where(w => w.Data >= dtInicial
                && w.Data <= dtFinal
                && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,
                    Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                    KM = s.KM,
                    Quantidade = s.Quantidade,
                    Valor = s.Valor,
                    PathComprovantePDF = s.PathComprovantePDF
                }).OrderByDescending(o => o.Data).ToList();
            }
        }

        public List<DGridAbastecimentoInfo> ListParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Abastecimentos.Where(w => w.Data.Year.Equals(dtAtual.Year)
                && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
                {
                    Id = s.Id,
                    Data = s.Data,
                    DataS = s.DataS,
                    Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                    KM = s.KM,
                    Quantidade = s.Quantidade,
                    Valor = s.Valor,
                    PathComprovantePDF = s.PathComprovantePDF
                }).OrderByDescending(o => o.Data).ToList();
            }
        }

        public List<DGridAbastecimentoInfo> ListPorFiltro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, int combustivel)
        {
            using (var context = new Context())
            {
                if (combustivel == -1)
                    return context.Abastecimentos.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal)
                    && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
                    {
                        Id = s.Id,
                        Data = s.Data,
                        DataS = s.DataS,
                        Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor,
                        PathComprovantePDF = s.PathComprovantePDF
                    }).OrderByDescending(o => o.Data).ToList();
                else
                    return context.Abastecimentos.Where(w => (w.Data >= dtInicial
                    && w.Data <= dtFinal)
                    && w.Veiculo.Placa.Equals(veiculo.Placa)
                    && w.CombustivelId.Equals(combustivel)).Select(s => new DGridAbastecimentoInfo
                    {
                        Id = s.Id,
                        Data = s.Data,
                        DataS = s.DataS,
                        Combustivel = combustivelDAL.Get(s.CombustivelId).Tipo,
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor,
                        PathComprovantePDF = s.PathComprovantePDF
                    }).OrderByDescending(o => o.Data).ToList();
            }
        }

        public ConsumoInfo GetConsumo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            Combustivel combustivelVeiculo;
            List<DGridAbastecimentoInfo> abastecimento;

            using (var context = new Context())
            {
                combustivelVeiculo = combustivelDAL.Get(veiculo.Combustivel);

                //busca o abastecimento do veiculo conforme range de data 
                abastecimento = context.Abastecimentos.Where(w => (w.Data >= dtInicial
                && w.Data <= dtFinal)
                && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridAbastecimentoInfo
                    {
                        Data = s.Data,
                        Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).OrderBy(or => or.Data).ToList();
            }

            return ExtratificaConsumo(veiculo, combustivelVeiculo, abastecimento);
        }

        public ConsumoInfo GetConsumoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            ConsumoInfo consumo = new ConsumoInfo();
            List<DGridAbastecimentoInfo> abastecimento;
            Combustivel combustivelVeiculo;

            //TODO: Refatorar esse switch
            using (var context = new Context())
            {
                combustivelVeiculo = combustivelDAL.Get(veiculo.Combustivel);

                //busca o abastecimento do veiculo conforme range de data 
                abastecimento = context.Abastecimentos.Where(w => w.Data.Year.Equals(dtAtual.Year)
                && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridAbastecimentoInfo
                    {
                        Data = s.Data,
                        Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).OrderBy(or => or.Data).ToList();
            }

            return ExtratificaConsumo(veiculo, combustivelVeiculo, abastecimento);
        }

        public CustoDiario GetDiasRegistroParcialAnual(DateTime dtAtual, Veiculo veiculo)
        {
            var combustivel = combustivelDAL.Get(veiculo.Combustivel);
            var list = this.ListParcialAnual(dtAtual, veiculo);

            if (list.Count() >= 2)
            {
                var dataInicialRegistro = list.OrderBy(or => or.Data).First().Data;

                return CalculoCustoDiario(veiculo, combustivel, list, dataInicialRegistro, dtAtual);
            }
            else
                return new CustoDiario { DiasAlcool = 1, DiasDiesel = 1, DiasGasolina = 1, DiasGNV = 1, TotalDiasRegistro = 1 };
        }

        public CustoDiario GetDiasRegistro(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            var combustivel = combustivelDAL.Get(veiculo.Combustivel);
            var list = this.List(dtInicial, dtFinal, veiculo);

            if (list.Count() >= 2)
            {
                var dataInicialRegistro = list.OrderBy(or => or.Data).First().Data;

                return CalculoCustoDiario(veiculo, combustivel, list, dataInicialRegistro, dtFinal);
            }
            else
                return new CustoDiario { DiasAlcool = 1, DiasDiesel = 1, DiasGasolina = 1, DiasGNV = 1, TotalDiasRegistro = 1 };
        }

        private ConsumoInfo ExtratificaConsumo(Veiculo veiculo, Combustivel combustivel, List<DGridAbastecimentoInfo> abastecimento)
        {
            ConsumoInfo consumo = new ConsumoInfo();

            //TODO: Refatorar esse switch
            switch (combustivel.Tipo)
            {
                case "Gasolina":
                    if (abastecimento.Count() >= 2)
                    {
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).First().KM;
                    }
                    break;

                case "Alcool":
                    if (abastecimento.Count() >= 2)
                    {
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Alcool")).First().KM;
                    }
                    break;

                case "Flex":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //Alcool
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                    }
                    break;

                case "GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("GNV")).First().KM;
                    }
                    break;

                case "Gasolina/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                    }
                    break;

                case "Flex/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //Alcool
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                    }
                    break;

                case "Diesel":
                    if (abastecimento.Count() >= 2)
                    {
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Diesel")).First().KM;
                    }
                    break;

                case "Tri-Combustivel":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //Alcool
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                    }
                    break;

                case "Diesel/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Diesel
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                    }
                    break;
                default:
                    break;
            }

            return consumo;
        }

        private CustoDiario CalculoCustoDiario(Veiculo veiculo, Combustivel combustivel, List<DGridAbastecimentoInfo> list, DateTime dtInicial, DateTime dtFinal)
        {
            CustoDiario custoDiario = new CustoDiario { DiasAlcool = 1, DiasDiesel = 1, DiasGasolina = 1, DiasGNV = 1, TotalDiasRegistro = 1 };

            custoDiario.TotalDiasRegistro = (int)dtFinal.Subtract(dtInicial).TotalDays;

            switch (combustivel.Tipo)
            {
                case "Gasolina":
                    var listGasolina = list.Where(w => w.Combustivel.Equals("Gasolina"));
                    if (listGasolina.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolina.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolina.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGasolina = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Alcool":
                    var listAlcool = list.Where(w => w.Combustivel.Equals("Alcool"));
                    if (listAlcool.Count() >= 2)
                    {
                        var dataInicialRegistro = listAlcool.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listAlcool.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasAlcool = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Flex":
                    //Gasolina
                    var listGasolinaFlex = list.Where(w => w.Combustivel.Equals("Gasolina"));
                    if (listGasolinaFlex.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaFlex.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaFlex.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGasolina = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //Alcool
                    var listAlcoolFlex = list.Where(w => w.Combustivel.Equals("Alcool"));
                    if (listAlcoolFlex.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaFlex.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaFlex.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasAlcool = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "GNV":
                    var listGNV = list.Where(w => w.Combustivel.Equals("GNV"));
                    if (listGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGNV = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Gasolina/GNV":

                    //Gasolina
                    var listGasolinaGasolinGNV = list.Where(w => w.Combustivel.Equals("Gasolina"));
                    if (listGasolinaGasolinGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaGasolinGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaGasolinGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGasolina = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //GNV
                    var listGasolinaGNV = list.Where(w => w.Combustivel.Equals("GNV"));
                    if (listGasolinaGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGNV = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }

                    break;

                case "Flex/GNV":

                    //Gasolina
                    var listGasolinaFlexGNV = list.Where(w => w.Combustivel.Equals("Gasolina"));
                    if (listGasolinaFlexGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaFlexGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaFlexGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGasolina = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //Alcool
                    var listAlcoolFlexGNV = list.Where(w => w.Combustivel.Equals("Alcool"));
                    if (listAlcoolFlexGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listAlcoolFlexGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listAlcoolFlexGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasAlcool = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //GNV
                    var listGNVGNV = list.Where(w => w.Combustivel.Equals("GNV"));
                    if (listGNVGNV.Count() >= 2)
                    {
                        var dataInicialRegistro = listGNVGNV.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGNVGNV.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGNV = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Diesel":
                    var listDiesel = list.Where(w => w.Combustivel.Equals("Diesel"));
                    if (listDiesel.Count() >= 2)
                    {
                        var dataInicialRegistro = listDiesel.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listDiesel.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasDiesel = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Tri-Combustivel":
                    //Gasolina
                    var listGasolinaTRI = list.Where(w => w.Combustivel.Equals("Gasolina"));
                    if (listGasolinaTRI.Count() >= 2)
                    {
                        var dataInicialRegistro = listGasolinaTRI.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listGasolinaTRI.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasGasolina = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //Alcool
                    var listAlcoolTRI = list.Where(w => w.Combustivel.Equals("Alcool"));
                    if (listAlcoolTRI.Count() >= 2)
                    {
                        var dataInicialRegistro = listAlcoolTRI.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listAlcoolTRI.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasAlcool = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    //Diesel
                    var listDieselTRI = list.Where(w => w.Combustivel.Equals("Diesel"));
                    if (listDieselTRI.Count() >= 2)
                    {
                        var dataInicialRegistro = listDieselTRI.OrderBy(or => or.Data).First().Data;
                        var dataFinalRegistro = listDieselTRI.OrderByDescending(or => or.Data).First().Data;
                        custoDiario.DiasDiesel = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                    }
                    break;

                case "Diesel/GNV":
                    if (list.Count() >= 2)
                    {
                        //Diesel
                        var listDieselGNV = list.Where(w => w.Combustivel.Equals("Diesel"));
                        if (listDieselGNV.Count() >= 2)
                        {
                            var dataInicialRegistro = listDieselGNV.OrderBy(or => or.Data).First().Data;
                            var dataFinalRegistro = listDieselGNV.OrderByDescending(or => or.Data).First().Data;
                            custoDiario.DiasDiesel = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                        }
                        //GNV
                        var listGNVDiesel = list.Where(w => w.Combustivel.Equals("GNV"));
                        if (listGNVDiesel.Count() >= 2)
                        {
                            var dataInicialRegistro = listGNVDiesel.OrderBy(or => or.Data).First().Data;
                            var dataFinalRegistro = listGNVDiesel.OrderByDescending(or => or.Data).First().Data;
                            custoDiario.DiasGNV = (int)dataFinalRegistro.Subtract(dataInicialRegistro).TotalDays;
                        }
                    }
                    break;
                default:
                    break;
            }

            return custoDiario;
        }

        public void AnexarComprovante(int id, string pathComprovante)
        {
            using (var context = new Context())
            {
                var abasteci = context.Abastecimentos.Find(id);
                abasteci.PathComprovantePDF = pathComprovante;
                context.SaveChanges();
            }
        }

        public List<Abastecimento> ListExport()
        {
            using (var context = new Context())
            {
                return context.Abastecimentos.ToList();
            }
        }

        public List<AutonomiaInfo> GetAutonomia(DateTime dataMes, Veiculo veiculo)
        {
            //retrocede 3 meses
            DateTime dataMesInicial = dataMes.AddMonths(-3);

            List<AutonomiaInfo> list = new List<AutonomiaInfo>();


            // Loop para buscar abastecimento de 3 meses anteriores
            for (int i = 0; i < 3; i++)
            {
                using (var context = new Context())
                {
                    Combustivel combustivelVeiculo = context.Combustiveis.Where(w => w.Id.Equals(veiculo.Combustivel)).FirstOrDefault();

                    //busca o abastecimento do veiculo conforme range de data 
                    List<DGridAbastecimentoInfo> abastecimento = context.Abastecimentos.Where(w => (w.Data.Month.Equals(dataMesInicial.Month) && w.Data.Year.Equals(dataMesInicial.Year) && w.Veiculo.Placa.Equals(veiculo.Placa))).
                        Select(s => new DGridAbastecimentoInfo
                        {
                            Data = s.Data,
                            Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                            KM = s.KM,
                            Quantidade = s.Quantidade,
                            Valor = s.Valor
                        }).OrderBy(or => or.Data).ToList();

                    list.Add(CalculoAutonomiaDoMes(dataMesInicial, abastecimento, combustivelVeiculo.Tipo));

                    dataMesInicial = dataMesInicial.AddMonths(1);
                }
            }

            return list;
        }

        private AutonomiaInfo CalculoAutonomiaDoMes(DateTime data, List<DGridAbastecimentoInfo> abastecimento, string combustivelTipo)
        {
            long km = 0;
            AutonomiaInfo autonomia = new AutonomiaInfo();

            var kmInicial = abastecimento.Select(s => s.KM).FirstOrDefault();
            var kmFinal = abastecimento.Select(s => s.KM).LastOrDefault();

            km = kmFinal - kmInicial;

            switch (combustivelTipo)
            {
                case "Gasolina":
                    if (abastecimento.Count() >= 2)
                    {
                        var quantidadeGasolina1 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        var mediaGasolina1 = (quantidadeGasolina1 > 0 ? km / quantidadeGasolina1 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGasolina = $"{Math.Round(mediaGasolina1, 2)} km/l";
                    }
                    break;
                case "Alcool":
                    if (abastecimento.Count() >= 2)
                    {
                        var quantidadeAlcool1 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        var mediaAlcool1 = (quantidadeAlcool1 > 0 ? km / quantidadeAlcool1 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaAlcool = $"{Math.Round(mediaAlcool1, 2)} km/l";
                    }
                    break;
                case "Flex":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        var quantidadeGasolina2 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        var mediaGasolina2 = (quantidadeGasolina2 > 0 ? km / quantidadeGasolina2 : 0);
                        //Alcool
                        var quantidadeAlcool2 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        var mediaAlcool2 = (quantidadeAlcool2 > 0 ? km / quantidadeAlcool2 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGasolina = $"{Math.Round(mediaGasolina2, 2)} km/l";
                        autonomia.MediaAlcool = $"{Math.Round(mediaAlcool2, 2)} km/l";
                    }
                    break;
                case "GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        var quantidadeGNV1 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        var mediaGNV1 = (quantidadeGNV1 > 0 ? km / quantidadeGNV1 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGNV = $"{Math.Round(mediaGNV1, 2)} km/m³";
                    }
                    break;
                case "Gasolina/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        var quantidadeGasolina3 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        var mediaGasolina3 = (quantidadeGasolina3 > 0 ? km / quantidadeGasolina3 : 0);
                        //GNV
                        var quantidadeGNV2 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        var mediaGNV2 = (quantidadeGNV2 > 0 ? km / quantidadeGNV2 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGasolina = $"{Math.Round(mediaGasolina3, 2)} km/l";
                        autonomia.MediaGNV = $"{Math.Round(mediaGNV2, 2)} km/m³";
                    }
                    break;
                case "Flex/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Gasolina
                        var quantidadeGasolina4 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        var mediaGasolina4 = (quantidadeGasolina4 > 0 ? km / quantidadeGasolina4 : 0);
                        //Alcool
                        var quantidadeAlcool3 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        var mediaAlcool3 = (quantidadeAlcool3 > 0 ? km / quantidadeAlcool3 : 0);
                        //GNV
                        var quantidadeGNV3 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        var mediaGNV3 = (quantidadeGNV3 > 0 ? km / quantidadeGNV3 : 1);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGasolina = $"{Math.Round(mediaGasolina4, 2)} km/l";
                        autonomia.MediaAlcool = $"{Math.Round(mediaAlcool3, 2)} km/l";
                        autonomia.MediaGNV = $"{Math.Round(mediaGNV3, 2)} km/m³";
                    }
                    break;
                case "Diesel":
                    if (abastecimento.Count() >= 2)
                    {
                        var quantidadeDiesel1 = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        var mediaDiesel1 = (quantidadeDiesel1 > 0 ? km / quantidadeDiesel1 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaDiesel = $"{Math.Round(mediaDiesel1, 2)} km/l";
                    }
                    break;
                case "Tri-Combustivel":
                    if (abastecimento.Count() >= 2)
                    {                            //Gasolina
                        var quantidadeGasolina5 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        var mediaGasolina5 = (quantidadeGasolina5 > 0 ? km / quantidadeGasolina5 : 0);
                        //Alcool
                        var quantidadeAlcool4 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        var mediaAlcool4 = (quantidadeAlcool4 > 0 ? km / quantidadeAlcool4 : 0);
                        //GNV
                        var quantidadeGNV4 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        var mediaGNV4 = quantidadeGNV4 > 0 ? km / quantidadeGNV4 : 3;
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaGasolina = $"{Math.Round(mediaGasolina5, 2)} km/l";
                        autonomia.MediaAlcool = $"{Math.Round(mediaAlcool4, 2)} km/l";
                        autonomia.MediaGNV = $"{Math.Round(mediaGNV4, 2)} km/m³";
                    }
                    break;
                case "Diesel/GNV":
                    if (abastecimento.Count() >= 2)
                    {
                        //Diesel
                        var quantidadeDiesel2 = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        var mediaDiesel2 = (quantidadeDiesel2 > 0 ? km / quantidadeDiesel2 : 0);
                        //GNV
                        var quantidadeGNV5 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        var mediaGNV5 = (quantidadeGNV5 > 0 ? km / quantidadeGNV5 : 0);
                        autonomia.Mes = GetMesPacalCase(data.Month);
                        autonomia.MediaDiesel = $"{Math.Round(mediaDiesel2, 2)} km/l";
                        autonomia.MediaGNV = $"{Math.Round(mediaGNV5, 2)} km/m³";
                    }
                    break;
                default:
                    break;
            }

            return autonomia;
        }

        /// <summary>
        /// Devolve o nome do Mes por extenso em Pascal Case, por exempo: Agosto
        /// </summary>
        /// <param name="mes">Numero do mês desejado</param>
        /// <returns>Nome do mês</returns>
        private string GetMesPacalCase(int mes)
        {
            //Com primeira letra maiúscula.
            string month = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(mes);
            return (char.ToUpper(month[0]) + month.Substring(1));
        }
    }
}
