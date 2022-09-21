using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Reflection;

namespace CFSqlCe.Dal
{
    public class Context : DbContext
    {
        static Context()
        {
            // Not initialize database
            //  Database.SetInitializer<ProjectDatabase>(null);
            // Database initialize
            Database.SetInitializer<Context>(new DbInitializer());
            using (Context db = new Context())
                db.Database.Initialize(false);
        }

        public DbSet<Configuracao> Configuracaos { get; set; }
        public DbSet<Abastecimento> Abastecimentos { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }        
        public DbSet<Veiculo> Veiculos { get; set; }        
        public DbSet<Mecanica> Mecanicas { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<TipoManutencao> TipoManutencaos { get; set; }        
        public DbSet<CNH> CNHs { get; set; }
        public DbSet<Seguradora> Seguradoras { get; set; }
        public DbSet<ContratoSeguro> ContratoSeguros { get; set; }
        public DbSet<PagamentosSeguro> PagamentosSeguro { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<PagamentoDocumento> PagamentoDocumentos { get; set; } 
    }

    class DbInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {            
            context.Combustiveis.AddRange(new List<Combustivel>
            {
                new Combustivel { Tipo = "Não definido"},
                new Combustivel { Tipo = "Gasolina"},
                new Combustivel { Tipo = "Alcool"},
                new Combustivel { Tipo = "Flex"},
                new Combustivel { Tipo = "GNV"},
                new Combustivel { Tipo = "Gasolina/GNV"},
                new Combustivel { Tipo = "Flex/GNV"},
                new Combustivel { Tipo = "Diesel"},
                new Combustivel { Tipo = "Tri-Combustivel"},
                new Combustivel { Tipo = "Diesel/GNV"}
            });

            context.Versoes.Add(new Versao { Version = Assembly.GetExecutingAssembly().GetName().Version.ToString() });
                        
            base.Seed(context);
        }
    }
}
