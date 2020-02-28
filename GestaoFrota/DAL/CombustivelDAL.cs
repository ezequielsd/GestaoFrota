using System.Collections.Generic;
using System.Linq;
using CFSqlCe.Dal;

namespace GestaoFrota.DAL
{
    public sealed class CombustivelDAL
    {
        #region Propriedades

        static CombustivelDAL _instancia;
        public static CombustivelDAL Instancia
        {
            get { return _instancia ?? (_instancia = new CombustivelDAL()); }
        }

        #endregion

        #region Construtores

        private CombustivelDAL() { }

        #endregion

        public List<Combustivel> List()
        {
            using (var context = new Context())
            {
                return context.Combustiveis.ToList();
            }
        }
               
        public List<Combustivel> List(Veiculo veiculo)
        {

            switch (veiculo.Combustivel)
            {
                case 2:
                    return new List<Combustivel>
                    {
                        new Combustivel { Tipo = "Gasolina"}
                    };                    
                case 3:
                    return new List<Combustivel>
                     {                        
                        new Combustivel { Tipo = "Alcool"}                      
                     };                    
                case 4:
                    return new List<Combustivel>
                    {                           
                        new Combustivel { Tipo = "Gasolina"},
                        new Combustivel { Tipo = "Alcool"},                        
                    };                    
                case 5:
                    return new List<Combustivel>
                    {
                        new Combustivel { Tipo = "GNV"}
                    };                    
                case 6:
                    return new List<Combustivel>
                    {                        
                        new Combustivel { Tipo = "Gasolina"},
                        new Combustivel { Tipo = "GNV"},
                    };                    
                case 7:
                    return new List<Combustivel>
                    {
                        new Combustivel { Tipo = "Gasolina"},
                        new Combustivel { Tipo = "Alcool"},                        
                        new Combustivel { Tipo = "GNV"}                        
                    };                    
                case 8:
                    return new List<Combustivel>
                    {
                        new Combustivel { Tipo = "Diesel"}                        
                    };                    
                case 9:
                    return new List<Combustivel>
                    {
                        new Combustivel { Tipo = "Gasolina"},
                        new Combustivel { Tipo = "Alcool"},                        
                        new Combustivel { Tipo = "GNV"}                        
                    };
                case 10:
                    return new List<Combustivel>
                    {                        
                        new Combustivel { Tipo = "Diesel"},                        
                        new Combustivel { Tipo = "GNV"}                        
                    };
                default:
                    return new List<Combustivel>();
            }           
        }

        public Combustivel Get(int id)
        {
            using (var context = new Context())
            {
                return context.Combustiveis.Find(id);
            }
        }
                
        public int GetIdCombustivel(string combustivel)
        {
            using (var context = new Context())
            {
                if (string.IsNullOrEmpty(combustivel) || string.IsNullOrWhiteSpace(combustivel))
                    return -1;
                else
                    return context.Combustiveis.Where(w => w.Tipo.Equals(combustivel)).Select(s => s.Id).FirstOrDefault();
            }
        }
    }
}
