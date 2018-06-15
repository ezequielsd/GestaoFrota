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
        public void Insert(ContratoSeguro info)
        {
            new ContratoSeguradoraDAL().Insert(info);
        }
             
        public ContratoSeguro GetSeguroAtivo()
        {
            return new ContratoSeguradoraDAL().GetSeguroAtivo();
        }
                
        public void EncerrarContrato(ContratoSeguro info)
        {
            info.Ativo = false;
            new ContratoSeguradoraDAL().EncerrarContrato(info);
        }
                
        public void EditarAnexos(ContratoSeguro info)
        {
            new ContratoSeguradoraDAL().EditarAnexos(info);
        }
                
        public void InsertPagamento(PagamentosSeguro info)
        {
            new ContratoSeguradoraDAL().InsertPagamento(info);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            return new ContratoSeguradoraDAL().ListPagamentos(dtInicial, dtFinal, veiculo, contrato);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(DateTime dtInicial, DateTime dtFinal, Veiculo veiculo)
        {
            return new ContratoSeguradoraDAL().ListPagamentos(dtInicial, dtFinal, veiculo);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, Veiculo veiculo)
        {
            return new ContratoSeguradoraDAL().ListPagamentos(seguradoraId, veiculo);
        }
                
        public List<DGridPagamentoSeguroInfo> ListPagamentos(int seguradoraId, DateTime dtInicial, DateTime dtFinal, Veiculo veiculo, ContratoSeguro contrato)
        {
            return new ContratoSeguradoraDAL().ListPagamentos(seguradoraId, dtInicial, dtFinal, veiculo, contrato);
        }

        public decimal GetPagamentoSeguroAnual(DateTime dtAtual, Veiculo veiculo)
        {
            return new ContratoSeguradoraDAL().GetPagamentoSeguroAnual(dtAtual, veiculo);
        }
    }
}
