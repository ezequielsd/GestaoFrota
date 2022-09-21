using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public sealed class CNHDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static CNHDAL _instancia;
        public static CNHDAL Instancia
        {
            get { return _instancia ?? (_instancia = new CNHDAL()); }
        }

        #endregion

        #region Construtores

        private CNHDAL() { }

        #endregion

        public List<DGridCNHInfo> ListGrid()
        {
            using (var context = new Context())
            {
                return context.CNHs.Select(s => new DGridCNHInfo
                {
                    NumeroRegistro = s.NumeroRegistro,
                    Nome = s.Nome,
                    Validade = s.Validade
                }).ToList();
            }
        }
             
        public List<CNH> List()
        {
            using (var context = new Context())
            {
                return context.CNHs.ToList();
            }
        }
     
        public CNH Get(string reg)
        {
            using (var context = new Context())
            {
                return context.CNHs.Find(reg);
            }
        }
                
        public void Insert(CNH info)
        {
            using (var context = new Context())
            {
                context.CNHs.Add(info);
                context.SaveChanges();
            }
        }
                
        public void Alterar(CNH info)
        {
            using (var context = new Context())
            {
                var cnh = context.CNHs.Find(info.NumeroRegistro);
               
                cnh.Categoria = info.Categoria;
                cnh.CPF = info.CPF;                
                cnh.Emissao = info.Emissao;
                cnh.Filiacao = info.Filiacao;
                cnh.Local = info.Local;
                cnh.Nascimento = info.Nascimento;
                cnh.Nome = info.Nome;                
                cnh.PathDocumentoPDF = info.PathDocumentoPDF;
                cnh.PrimeiraHabilitacao = info.PrimeiraHabilitacao;
                cnh.Validade = info.Validade;
                cnh.Aivo = info.Aivo;

                context.SaveChanges();
            }
        }
    }
}
