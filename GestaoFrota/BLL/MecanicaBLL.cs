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
    public class MecanicaBLL
    {       
        public void Insert(Mecanica info)
        {
            new MecanicaDAL().Insert(info);
        }
       
        public List<Mecanica> List()
        {
            return new MecanicaDAL().List();
        }
      
        public List<DGridMecanicaInfo> ListDt()
        {
            return new MecanicaDAL().ListDt();
        }

        public Mecanica Get(int id)
        {
            return new MecanicaDAL().Get(id);
        }
        
        public void Save(Mecanica info)
        {
            new MecanicaDAL().Save(info);
        }
       
        public List<Mecanica> ListExport()
        {
            return new MecanicaDAL().ListExport();
        }
    }
}
