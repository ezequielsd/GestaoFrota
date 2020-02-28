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
    public sealed class SeguradoraBLL
    {
        #region Propriedades

        //Aplicando o Pattern Singleton
        static SeguradoraBLL _instancia;
        public static SeguradoraBLL Instancia
        {
            get { return _instancia ?? (_instancia = new SeguradoraBLL()); }
        }

        #endregion

        #region Construtores

        private SeguradoraBLL() { }

        #endregion

        SeguradoraDAL dal = SeguradoraDAL.Instancia;

        public void Insert(Seguradora info)
        {
            dal.Insert(info);
        }
       
        public List<Seguradora> List()
        {
            return dal.List();
        }
        
        public List<DGridSeguradoraInfo> ListDt()
        {
            return dal.ListDt();
        }
        
        public Seguradora Get(int id)
        {
            return dal.Get(id);
        }
        
        public void Save(Seguradora info)
        {
            dal.Save(info);
        }
       
        public List<Seguradora> ListExport()
        {
            return dal.ListExport();
        }
    }
}
