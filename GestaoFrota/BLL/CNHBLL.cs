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
    public class CNHBLL
    {
        CNHDAL dal = CNHDAL.Instancia;

        public List<DGridCNHInfo> ListDt()
        {
            return dal.ListDt();
        }
      
        public List<CNH> List()
        {
            return dal.List();
        }
        
        public CNH Get(string reg)
        {
            return dal.Get(reg);
        }
       
        public void Insert(CNH info)
        {
            info.Aivo = true;

            dal.Insert(info);
        }
      
        public void Alterar(CNH info)
        {
            dal.Alterar(info);
        }
    }
}
