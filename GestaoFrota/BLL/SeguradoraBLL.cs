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
    public class SeguradoraBLL
    {        
        public void Insert(Seguradora info)
        {
            new SeguradoraDAL().Insert(info);
        }
       
        public List<Seguradora> List()
        {
            return new SeguradoraDAL().List();
        }
        
        public List<DGridSeguradoraInfo> ListDt()
        {
            return new SeguradoraDAL().ListDt();
        }
        
        public Seguradora Get(int id)
        {
            return new SeguradoraDAL().Get(id);
        }
        
        public void Save(Seguradora info)
        {
            new SeguradoraDAL().Save(info);
        }
       
        public List<Seguradora> ListExport()
        {
            return new SeguradoraDAL().ListExport();
        }
    }
}
