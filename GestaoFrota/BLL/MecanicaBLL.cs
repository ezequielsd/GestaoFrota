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
    public sealed class MecanicaBLL
    {
        MecanicaDAL dal = MecanicaDAL.Instancia;

        #region Propriedades

        //Aplicando o Pattern Singleton
        static MecanicaBLL _instancia;
        public static MecanicaBLL Instancia
        {
            get { return _instancia ?? (_instancia = new MecanicaBLL()); }
        }

        #endregion

        #region Construtores

        private MecanicaBLL() { }

        #endregion

        public void Insert(Mecanica info)
        {
            dal.Insert(info);
        }
       
        public List<Mecanica> List()
        {
            return dal.List();
        }
      
        public List<DGridMecanicaInfo> ListDt()
        {
            return dal.ListDt();
        }

        public Mecanica Get(int id)
        {
            return dal.Get(id);
        }
        
        public void Save(Mecanica info)
        {
            dal.Save(info);
        }
       
        public List<Mecanica> ListExport()
        {
            return dal.ListExport();
        }
    }
}
