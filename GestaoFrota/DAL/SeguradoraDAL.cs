using CFSqlCe.Dal;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota.DAL
{
    public class SeguradoraDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static SeguradoraDAL _instancia;
        public static SeguradoraDAL Instancia
        {
            get { return _instancia ?? (_instancia = new SeguradoraDAL()); }
        }

        #endregion

        #region Construtores

        private SeguradoraDAL() { }

        #endregion

        public void Insert(Seguradora info)
        {
            using (var context = new Context())
            {
                context.Seguradoras.Add(info);
                context.SaveChanges();
            }
        }
             
        public List<Seguradora> List()
        {
            using (var context = new Context())
            {
                return context.Seguradoras.ToList();
            }
        }
                
        public List<DGridSeguradoraInfo> ListDt()
        {
            using (var context = new Context())
            {
                return context.Seguradoras.Select(s => new DGridSeguradoraInfo
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Telefone1 = s.Telefone1,
                    Celular = s.Celular1,
                    Email = s.Email
                }).ToList();
            }
        }
                
        public Seguradora Get(int id)
        {
            using (var context = new Context())
            {
                return context.Seguradoras.Find(id);
            }
        }
                
        public void Save(Seguradora info)
        {
            using (var context = new Context())
            {
                var seguradora = context.Seguradoras.Find(info.Id);

                seguradora.Bairro = info.Bairro;
                seguradora.CEP = info.CEP;
                seguradora.Cidade = info.Cidade;
                seguradora.Complemento = info.Complemento;
                seguradora.Contatos = info.Contatos;
                seguradora.Email = info.Email;
                seguradora.Endereco = info.Endereco;
                seguradora.Nome = info.Nome;
                seguradora.Numero = info.Numero;                
                seguradora.Site = info.Site;
                seguradora.Telefone1 = info.Telefone1;
                seguradora.Telefone2 = info.Telefone2;
                seguradora.Celular1 = info.Celular1;
                seguradora.Celular2 = info.Celular2;
                seguradora.Celular1Operadora = info.Celular1Operadora;
                seguradora.Celular2Operadora = info.Celular2Operadora;
                seguradora.UF = info.UF;

                context.SaveChanges();
            }
        }
                
        public List<Seguradora> ListExport()
        {
            using (var context = new Context())
            {
                return context.Seguradoras.ToList();
            }
        }
    }
}
