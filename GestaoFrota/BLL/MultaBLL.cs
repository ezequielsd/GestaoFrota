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
        public void Insert(Multa multa)
        {
            multa.DataOcorrenciaS = multa.DataOcorrencia.ToShortDateString();
            multa.DataVencimentoS = multa.DataVencimento.ToShortDateString();
            new MultaDAL().Insert(multa);
        }

        public List<DGridMultaInfo> List(Veiculo veiculo)
        {
            return new MultaDAL().List(veiculo);
        }

        public List<DGridMultaInfo> List(DateTime dataInicial, DateTime dataFinal, int tipoMulta, int tipoDataFiltro, Veiculo veiculo)
        {
            return new MultaDAL().List(dataInicial, dataFinal, tipoMulta, tipoDataFiltro, veiculo);
        }

        public List<Multa> List()
        {
            return new MultaDAL().List();
        }

        public decimal GetMultaTotalAnual(DateTime dataAtual, Veiculo veiculo)
        {
            return new MultaDAL().GetMultaTotalAnual(dataAtual, veiculo);
        }

        public void SetPagamento(int id, DateTime dataPagamento)
        {
            new MultaDAL().SetPagamento(id, dataPagamento);
        }

        public void AnexarComprovante(int id, string pathComprovante)
        {
            new MultaDAL().AnexarComprovante(id, pathComprovante);
        }
    }
}
