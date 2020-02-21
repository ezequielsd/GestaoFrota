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
        VeiculoDAL dal = VeiculoDAL.Instancia;

        public void Insert(Veiculo info)
        {
            dal.Insert(info);                             
        }
       
        public List<VeiculosTreeViewInfo> GetListTreeView()
        {
            return dal.ListTreeView();
        }
               
        public Veiculo GetPorPlaca(string placa)
        {
            return dal.GetPorPlaca(placa);
        }
               
        public void Salvar(Veiculo info)
        {            
            try
            {
                dal.Alter(info);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<Veiculo> ListExport()
        {
            return dal.ListExport();
        }
    }
}
