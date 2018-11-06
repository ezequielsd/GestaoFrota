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
    public class AbastecimentoDAL
    {
        public void Insert(Abastecimento info)
        {
            using (var context = new Context())
            {
                info.Veiculo = context.Veiculos.Find(info.Veiculo.Placa);
                context.Abastecimentos.Add(info);
                context.SaveChanges();
            }
        }

        public List<DGridAbastecimentoInfo> List(DateTime dtAtual, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Abastecimentos.Where(w => w.Data.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
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

        public List<DGridAbastecimentoInfo> List(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            using (var context = new Context())
            {
                return context.Abastecimentos.Where(w => w.Data >= dtInicial && w.Data <= dtFinal && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
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
                    return context.Abastecimentos.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).Select(s => new DGridAbastecimentoInfo
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
                    return context.Abastecimentos.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa) && w.CombustivelId.Equals(combustivel)).Select(s => new DGridAbastecimentoInfo
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

        public ConsumoInfo GetConsumo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            ConsumoInfo consumo = new ConsumoInfo
            {
                QuantidadeAlcool = 0,
                QuantidadeDiesel = 0,
                QuantidadeGasolina = 0,
                QuantidadeGNV = 0,
                ValorAlcool = 0,
                ValorDiesel = 0,
                ValorGasolina = 0,
                ValorGNV = 0,
                KM = 0
            };

            using (var context = new Context())
            {
                Combustivel combustivelVeiculo = context.Combustiveis.Where(w => w.Id.Equals(veiculo.Combustivel)).FirstOrDefault();

                //busca o abastecimento do veiculo conforme range de data 
                List<DGridAbastecimentoInfo> abastecimento = context.Abastecimentos.Where(w => (w.Data >= dtInicial && w.Data <= dtFinal) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridAbastecimentoInfo
                    {
                        Data = s.Data,
                        Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).OrderBy(or => or.Data).ToList();

                switch (combustivelVeiculo.Tipo)
                {
                    case "Gasolina":
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).First().KM;
                        break;

                    case "Alcool":
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Alcool")).First().KM;
                        break;

                    case "Flex":
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //Alcool
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;

                    case "GNV":
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("GNV")).First().KM;
                        break;

                    case "Gasolina/GNV":
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        if (abastecimento.Count > 0)
                            consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;

                    case "Flex/GNV":
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
                        break;

                    case "Diesel":
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Diesel")).First().KM;
                        break;

                    case "Tri-Combustivel":
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
                        break;

                    case "Diesel/GNV":
                        //Diesel
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;
                    default:
                        break;
                }
            }


            return consumo;
        }

        public ConsumoInfo GetConsumoAnual(DateTime dtAtual, Veiculo veiculo)
        {
            ConsumoInfo consumo = new ConsumoInfo
            {
                QuantidadeAlcool = 0,
                QuantidadeDiesel = 0,
                QuantidadeGasolina = 0,
                QuantidadeGNV = 0,
                ValorAlcool = 0,
                ValorDiesel = 0,
                ValorGasolina = 0,
                ValorGNV = 0,
                KM = 0
            };

            using (var context = new Context())
            {
                Combustivel combustivelVeiculo = context.Combustiveis.Where(w => w.Id.Equals(veiculo.Combustivel)).FirstOrDefault();

                //busca o abastecimento do veiculo conforme range de data 
                List<DGridAbastecimentoInfo> abastecimento = context.Abastecimentos.Where(w => w.Data.Year.Equals(dtAtual.Year) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                    Select(s => new DGridAbastecimentoInfo
                    {
                        Data = s.Data,
                        Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                        KM = s.KM,
                        Quantidade = s.Quantidade,
                        Valor = s.Valor
                    }).OrderBy(or => or.Data).ToList();

                switch (combustivelVeiculo.Tipo)
                {
                    case "Gasolina":
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).First().KM;
                        break;

                    case "Alcool":
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Alcool")).First().KM;
                        break;

                    case "Flex":
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //Alcool
                        consumo.QuantidadeAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                        consumo.ValorAlcool = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;

                    case "GNV":
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("GNV")).First().KM;
                        break;

                    case "Gasolina/GNV":
                        //Gasolina
                        consumo.QuantidadeGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGasolina = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        if (abastecimento.Count > 0)
                            consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;

                    case "Flex/GNV":
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
                        break;

                    case "Diesel":
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Last().KM - abastecimento.Where(w => w.Combustivel.Equals("Diesel")).First().KM;
                        break;

                    case "Tri-Combustivel":
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
                        break;

                    case "Diesel/GNV":
                        //Diesel
                        consumo.QuantidadeDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                        consumo.ValorDiesel = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Valor).Sum();
                        //GNV
                        consumo.QuantidadeGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                        consumo.ValorGNV = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Valor).Sum();
                        consumo.KM = abastecimento.Last().KM - abastecimento.First().KM;
                        break;
                    default:
                        break;
                }
            }

            return consumo;
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

            long km = 0;

            // Loop para buscar abastecimento de 3 meses anteriores
            for (int i = 0; i < 3; i++)
            {
                using (var context = new Context())
                {
                    Combustivel combustivelVeiculo = context.Combustiveis.Where(w => w.Id.Equals(veiculo.Combustivel)).FirstOrDefault();

                    //busca o abastecimento do veiculo conforme range de data 
                    List<DGridAbastecimentoInfo> abastecimento = context.Abastecimentos.Where(w => (w.Data.Month.Equals(dataMesInicial.Month)) && w.Veiculo.Placa.Equals(veiculo.Placa)).
                        Select(s => new DGridAbastecimentoInfo
                        {
                            Data = s.Data,
                            Combustivel = context.Combustiveis.Where(w2 => w2.Id.Equals(s.CombustivelId)).Select(s2 => s2.Tipo).FirstOrDefault(),
                            KM = s.KM,
                            Quantidade = s.Quantidade,
                            Valor = s.Valor
                        }).OrderBy(or => or.Data).ToList();


                    var kmInicial = abastecimento.Select(s => s.KM).FirstOrDefault();
                    var kmFinal = abastecimento.Select(s => s.KM).LastOrDefault();

                    km = kmFinal - kmInicial;

                    AutonomiaInfo autonomia = new AutonomiaInfo();

                    switch (combustivelVeiculo.Tipo)
                    {
                        case "Gasolina":
                            var quantidadeGasolina1 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                            var mediaGasolina1 = km / quantidadeGasolina1;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGasolina = $"{Math.Round(mediaGasolina1, 2)} km/l";
                            break;
                        case "Alcool":
                            var quantidadeAlcool1 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                            var mediaAlcool1 = km / quantidadeAlcool1;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaAlcool = $"{Math.Round(mediaAlcool1, 2)} km/l";
                            break;
                        case "Flex":
                            //Gasolina
                            var quantidadeGasolina2 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                            var mediaGasolina2 = km / quantidadeGasolina2;
                            //Alcool
                            var quantidadeAlcool2 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                            var mediaAlcool2 = km / quantidadeAlcool2;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGasolina = $"{Math.Round(mediaGasolina2, 2)} km/l";
                            autonomia.MediaAlcool = $"{Math.Round(mediaAlcool2, 2)} km/l";
                            break;
                        case "GNV":
                            var quantidadeGNV1 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                            var mediaGNV1 = km / quantidadeGNV1;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGNV = $"{Math.Round(mediaGNV1, 2)} km/m³";
                            break;
                        case "Gasolina/GNV":
                            //Gasolina
                            var quantidadeGasolina3 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                            var mediaGasolina3 = km / quantidadeGasolina3;
                            //GNV
                            var quantidadeGNV2 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                            var mediaGNV2 = km / quantidadeGNV2;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGasolina = $"{Math.Round(mediaGasolina3, 2)} km/l";
                            autonomia.MediaGNV = $"{Math.Round(mediaGNV2, 2)} km/m³";
                            break;
                        case "Flex/GNV":
                            //Gasolina
                            var quantidadeGasolina4 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                            var mediaGasolina4 = km / quantidadeGasolina4;
                            //Alcool
                            var quantidadeAlcool3 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                            var mediaAlcool3 = km / quantidadeAlcool3;
                            //GNV
                            var quantidadeGNV3 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                            var mediaGNV3 = km / quantidadeGNV3;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGasolina = $"{Math.Round(mediaGasolina4, 2)} km/l";
                            autonomia.MediaAlcool = $"{Math.Round(mediaAlcool3, 2)} km/l";
                            autonomia.MediaGNV = $"{Math.Round(mediaGNV3, 2)} km/m³";
                            break;
                        case "Diesel":
                            var quantidadeDiesel1 = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                            var mediaDiesel1 = km / quantidadeDiesel1;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaDiesel = $"{Math.Round(mediaDiesel1, 2)} km/l";
                            break;
                        case "Tri-Combustivel":
                            //Gasolina
                            var quantidadeGasolina5 = abastecimento.Where(w => w.Combustivel.Equals("Gasolina")).Select(s => s.Quantidade).Sum();
                            var mediaGasolina5 = km / quantidadeGasolina5;
                            //Alcool
                            var quantidadeAlcool4 = abastecimento.Where(w => w.Combustivel.Equals("Alcool")).Select(s => s.Quantidade).Sum();
                            var mediaAlcool4 = km / quantidadeAlcool4;
                            //GNV
                            var quantidadeGNV4 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                            var mediaGNV4 = km / quantidadeGNV4;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaGasolina = $"{Math.Round(mediaGasolina5, 2)} km/l";
                            autonomia.MediaAlcool = $"{Math.Round(mediaAlcool4, 2)} km/l";
                            autonomia.MediaGNV = $"{Math.Round(mediaGNV4, 2)} km/m³";
                            break;
                        case "Diesel/GNV":
                            //Diesel
                            var quantidadeDiesel2 = abastecimento.Where(w => w.Combustivel.Equals("Diesel")).Select(s => s.Quantidade).Sum();
                            var mediaDiesel2 = km / quantidadeDiesel2;
                            //GNV
                            var quantidadeGNV5 = abastecimento.Where(w => w.Combustivel.Equals("GNV")).Select(s => s.Quantidade).Sum();
                            var mediaGNV5 = km / quantidadeGNV5;
                            autonomia.Mes = GetMesPacalCase(dataMesInicial.Month);
                            autonomia.MediaDiesel = $"{Math.Round(mediaDiesel2, 2)} km/l";
                            autonomia.MediaGNV = $"{Math.Round(mediaGNV5, 2)} km/m³";
                            break;
                        default:
                            break;
                    }

                    dataMesInicial = dataMesInicial.AddMonths(1);

                    list.Add(autonomia);
                }
            }

            return list;
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
