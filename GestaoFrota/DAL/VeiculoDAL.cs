using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSqlCe.Dal;
using GestaoFrota.Models;

namespace GestaoFrota.DAL
{
    public sealed class VeiculoDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static VeiculoDAL _instancia;
        public static VeiculoDAL Instancia
        {
            get { return _instancia ?? (_instancia = new VeiculoDAL()); }
        }

        #endregion

        #region Construtores

        private VeiculoDAL() { }

        #endregion

        public void Insert(Veiculo info)
        {
            using (var context = new Context())
            {                
                context.Veiculos.Add(info);
                context.SaveChanges();
            }
        }
             
        public List<VeiculosTreeViewInfo> ListTreeView()
        {
            using (var context = new Context())
            {
                return context.Veiculos.Select( s =>  new VeiculosTreeViewInfo { Marca = s.FipeNameMarca, Modelo = s.FIPEModelo, Placa = s.Placa }).ToList();
            }
        }
                
        public Veiculo GetPorPlaca(string placa)
        {
            using (var context = new Context())
            {
                return context.Veiculos.Find(placa);
            }                 
        }
                
        public void Alter(Veiculo info)
        {
            using (var context = new Context())
            {
                Veiculo veiculo = context.Veiculos.Find(info.Placa);

                veiculo.AnoFab = info.AnoFab;
                veiculo.AnoModelo = info.AnoModelo;
                veiculo.Ativo = info.Ativo;
                veiculo.Capacidade = info.Capacidade;
                veiculo.Categoria = info.Categoria;
                veiculo.Chassi = info.Chassi;
                veiculo.Cidade = info.Cidade;
                veiculo.Combustivel = info.Combustivel;
                veiculo.Cor = info.Cor;
                veiculo.CPFCNPJ = info.CPFCNPJ;
                veiculo.DataAquisicao = info.DataAquisicao;
                veiculo.KM = info.KM;
                veiculo.FipeNameMarca = info.FipeNameMarca;
                veiculo.FIPEModelo = info.FIPEModelo;
                veiculo.NomeEndereco = info.NomeEndereco;
                veiculo.Observacao = info.Observacao;               
                veiculo.Renavam = info.Renavam;
                veiculo.Tipo = info.Tipo;
                veiculo.UF = info.UF;
                veiculo.Potencia = info.Potencia;
                veiculo.PathDocumentoPDF = info.PathDocumentoPDF;
                veiculo.MedidasPneus = info.MedidasPneus;
                
                context.SaveChanges();
            }
        }
                
        public List<Veiculo> ListExport()
        {
            using (var context = new Context())
            {
                return context.Veiculos.ToList();
            }
        }
    }
}
