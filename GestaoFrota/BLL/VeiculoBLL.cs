using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSqlCe.Dal;
using GestaoFrota.DAL;
using GestaoFrota.Models;

namespace GestaoFrota.BLL
{
    public class VeiculoBLL
    {       
        public void Insert(Veiculo info)
        { 
            new VeiculoDAL().Insert(info);                             
        }
       
        public List<VeiculosTreeViewInfo> GetListTreeView()
        {
            return new VeiculoDAL().ListTreeView();
        }
               
        public Veiculo GetPorPlaca(string placa)
        {
            return new VeiculoDAL().GetPorPlaca(placa);
        }
               
        public void Salvar(Veiculo info)
        {            
            try
            {
                new VeiculoDAL().Alter(info);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<Veiculo> ListExport()
        {
            return new VeiculoDAL().ListExport();
        }
    }
}
