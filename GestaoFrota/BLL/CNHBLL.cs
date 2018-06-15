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
       
        public List<DGridCNHInfo> ListDt()
        {
            return new CNHDAL().ListDt();
        }
      
        public List<CNH> List()
        {
            return new CNHDAL().List();
        }
        
        public CNH Get(string reg)
        {
            return new CNHDAL().Get(reg);
        }
       
        public void Insert(CNH info)
        {
            info.Aivo = true;

            new CNHDAL().Insert(info);
        }
      
        public void Alterar(CNH info)
        {
            new CNHDAL().Alterar(info);
        }
    }
}
