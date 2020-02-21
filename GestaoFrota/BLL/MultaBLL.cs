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
    public class MultaBLL
    {
        MultaDAL dal = MultaDAL.Instancia;

        public void Insert(Multa multa)
        {
            multa.DataOcorrenciaS = multa.DataOcorrencia.ToShortDateString();
            multa.DataVencimentoS = multa.DataVencimento.ToShortDateString();
            dal.Insert(multa);
        }

        public List<DGridMultaInfo> List(Veiculo veiculo)
        {
            return dal.List(veiculo);
        }

        public List<DGridMultaInfo> List(DateTime dataInicial, DateTime dataFinal, int tipoMulta, int tipoDataFiltro, Veiculo veiculo)
        {
            return dal.List(dataInicial, dataFinal, tipoMulta, tipoDataFiltro, veiculo);
        }

        public List<Multa> List()
        {
            return dal.List();
        }

        public decimal GetMultaTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            return dal.GetMultaTotalAnual(dataAtual, veiculo);
        }

        public decimal GetMultaPorPeriodo(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.GetMultaPorPeriodo(dtInicial, dtFinal, veiculo);
        }

        public void SetPagamento(int id, DateTime dataPagamento)
        {
            dal.SetPagamento(id, dataPagamento);
        }

        public void AnexarComprovante(int id, string pathComprovante)
        {
            dal.AnexarComprovante(id, pathComprovante);
        }
    }
}
