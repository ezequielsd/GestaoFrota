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
    public class ContratoSeguradoraBLL
    {
        ContratoSeguradoraDAL dal = ContratoSeguradoraDAL.Instancia;

        public void Insert(ContratoSeguro info)
        {
            dal.Insert(info);
        }
             
        public ContratoSeguro GetSeguroAtivo()
        {
            return dal.GetSeguroAtivo();
        }
                
        public void EncerrarContrato(ContratoSeguro info)
        {
            info.Ativo = false;
            dal.EncerrarContrato(info);
        }
                
        public void EditarAnexos(ContratoSeguro info)
        {
            dal.EditarAnexos(info);
        }
                
        public void InsertPagamento(PagamentosSeguro info)
        {
            dal.InsertPagamento(info);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            return dal.ListPagamentos(dtInicial, dtFinal, veiculo, contrato);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return dal.ListPagamentos(dtInicial, dtFinal, veiculo);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, Veiculo veiculo)
        {
            return dal.ListPagamentos(seguradoraId, veiculo);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            return dal.ListPagamentos(seguradoraId, dtInicial, dtFinal, veiculo, contrato);
        }

        public decimal GetPagamentoSeguroAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return dal.GetPagamentoSeguroAnual(dtAtual, veiculo);
        }
    }
}
