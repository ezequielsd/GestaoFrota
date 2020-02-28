using CFSqlCe.Dal;
using GestaoFrota.BLL;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota
{
    public class Avisos
    {
        CNHBLL cNHBLL = CNHBLL.Instancia;
        MultaBLL multaBLL = MultaBLL.Instancia;
        VeiculoBLL veiculoBLL = VeiculoBLL.Instancia;
        PagamentoDocumentoBLL pagamentoDocumentoBLL = PagamentoDocumentoBLL.Instancia;

        public List<string> AvisosCNH()
        {
            List<string> list = new List<string>();

            var listCNH = cNHBLL.List();

            foreach (CNH item in listCNH)
            {
                if (item.Validade < DateTime.Now.AddMonths(2))
                {
                    list.Add($"A CNH do(a) {item.Nome}, vencerá em {item.Validade.ToShortDateString()}");
                }
            }

            return list;
        }

        public List<string> AvisoMulta()
        {
            List<string> list = new List<string>();

            var lisMulta = multaBLL.List();

            foreach (Multa item in lisMulta)
            {
                if (item.DataVencimento < DateTime.Now.AddMonths(2))
                {
                    list.Add($"Vencimento de multa no dia {item.DataVencimento.ToShortDateString()} para o veículo {item.VeiculoID}");
                }
            }

            return list;
        }

        public List<string> AvisoDocumento()
        {
            List<string> list = new List<string>();

            List<VeiculosTreeViewInfo> listVeiculos = veiculoBLL.GetListTreeView();

            foreach (var item in listVeiculos)
            {
                //aviso de conta pagamento de documento não lançado para ano corrente
                var quantidadePagamentoDocumentoNoAno = pagamentoDocumentoBLL.GetPagamentoDocumentoLancadoDoAno(DateTime.Now, item.Placa);

                if (quantidadePagamentoDocumentoNoAno == 0)
                    list.Add($"Não há pagamento de documento lançado para o veículo: {item.Placa}, para o ano de {DateTime.Now.Year}");

                //Aviso de documento a vencer e vencido
                List<PagamentoDocumento> documentosNaoPago = pagamentoDocumentoBLL.GetDocumentoNaoPago(DateTime.Now, item.Placa);

                foreach (PagamentoDocumento pagamento in documentosNaoPago)
                {
                    if (pagamento.DataVencimento < DateTime.Now)
                    {
                        list.Add($"Há pagamento de documento vencido em {pagamento.DataVencimentoS} para o veículo: {item.Placa}");
                        continue;
                    }

                    // Pagamento a vencer
                    if (pagamento.DataVencimento.AddMonths(-3) < DateTime.Now)
                    {
                        list.Add($"Há pagamento de documento à vencer em {pagamento.DataVencimentoS} para o veículo: {item.Placa}");                        
                    }                    
                }   
            }

            return list;
        }
    }
}
