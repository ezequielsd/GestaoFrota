using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSqlCe.Dal;
using GestaoFrota.Models;

namespace GestaoFrota.DAL
{
    public sealed class MecanicaDAL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static MecanicaDAL _instancia;
        public static MecanicaDAL Instancia
        {
            get { return _instancia ?? (_instancia = new MecanicaDAL()); }
        }

        #endregion

        #region Construtores

        private MecanicaDAL() { }

        #endregion

        /// <summary>
        /// Cadasrar uma mecanica ou elétrica
        /// </summary>
        /// <param name="info">dados da mecanica para cadastro</param>
        public void Insert(Mecanica info)
        {
            using (var context = new Context())
            {
                context.Mecanicas.Add(info);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna lista de mecanicas cadastradas
        /// </summary>
        /// <returns>reorna lista de mecanicas</returns>
        public List<Mecanica> List()
        {
            using (var context = new Context())
            {
                return context.Mecanicas.ToList();
            }
        }

        /// <summary>
        /// Retorna lista de mecanicas para datagridview
        /// </summary>
        /// <returns>lista de mecanicas para datagridview</returns>
        public List<DGridMecanicaInfo> ListDt()
        {
            using (var context = new Context())
            {
                return context.Mecanicas.Select(s => new DGridMecanicaInfo
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Telefone1 = s.Telefone1,
                    Celular = s.Celular1,
                    Email = s.Email
                }).ToList();
            }
        }

        /// <summary>
        /// Busca mecanica pelo Id
        /// </summary>
        /// <param name="id">id da mecanica</param>
        /// <returns>retorna a mecanica solicitada pelo id</returns>
        public Mecanica Get(int id)
        {
            using (var context = new Context())
            {
                return context.Mecanicas.Find(id);
            }
        }
                
        /// <summary>
        /// Salva alterações nos dados da mecanica informada
        /// </summary>
        /// <param name="info">dados da mecanica</param>
        public void Save(Mecanica info)
        {
            using (var context = new Context())
            {
                var mec = context.Mecanicas.Find(info.Id);

                mec.Bairro = info.Bairro;
                mec.CEP = info.CEP;
                mec.Cidade = info.Cidade;
                mec.Complemento = info.Complemento;
                mec.Contatos = info.Contatos;
                mec.Email = info.Email;
                mec.Endereco = info.Endereco;
                mec.Nome = info.Nome;
                mec.Numero = info.Numero;
                mec.Observacao = info.Observacao;
                mec.Site = info.Site;
                mec.Telefone1 = info.Telefone1;
                mec.Telefone2 = info.Telefone2;
                mec.Celular1 = info.Celular1;
                mec.Celular2 = info.Celular2;
                mec.Celular1Operadora = info.Celular1Operadora;
                mec.Celular2Operadora = info.Celular2Operadora;
                mec.UF = info.UF;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca todos os dados cadastrados para exportar
        /// </summary>
        /// <returns>retorna lista de dados cadastados</returns>
        public List<Mecanica> ListExport()
        {
            using (var context = new Context())
            {
                return context.Mecanicas.ToList();
            }
        }
    }
}
