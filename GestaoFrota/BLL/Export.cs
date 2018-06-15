using CFSqlCe.Dal;
using GestaoFrota.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota
{    
    public class Export
    {        
        static readonly object _logLockObj = new object();

        public static void ExportDB()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Export");

            VerificaPastaExportacao(path);
            ExportVeiculos(path);
            ExportMecanica(path);
            ExportAbastecimento(path);
            ExportOleo(path);
            ExportManutencao(path);
        }

        static void VerificaPastaExportacao(string path)
        {
            //Verifica se existe, senão cria   
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        static void ExportVeiculos(string path)
        {
            string fileName = Path.Combine(path, "Veiculo.txt");

            List<Veiculo> list = new VeiculoBLL().ListExport();
            StringBuilder conteudo = new StringBuilder();

            foreach (Veiculo item in list)
            {
                conteudo.AppendLine($"{item.Placa};{item.Tipo};{item.FipeNameMarca};{item.IdFIPEMarca};{item.KeyFIPEMarca};{item.FIPEModelo};{item.IdFIPEModelo};{item.KeyFIPEModelo};{item.FipeNameAno};{item.IdFipeAno};{item.Renavam};{item.Chassi};{item.Combustivel};{item.AnoFab};{item.AnoModelo};{item.Capacidade};{item.Cor};{item.Cidade};{item.UF};{item.CPFCNPJ};{item.Categoria};{item.KM};{item.NomeEndereco};{item.DataAquisicao};{item.Observacao};{item.Potencia};{item.Ativo}");
            }

            lock (_logLockObj)
            {                               
                try
                {
                    FileInfo t = new FileInfo(fileName);
                    using (StreamWriter Tex = t.CreateText())
                    {
                        Tex.WriteLine(conteudo.ToString()); //Aqui vai o conteúdo que já existia                        
                    }                                                    
                }
                catch (Exception)
                {
                    throw;
                }                
            }
        }

        static void ExportMecanica(string path)
        {
            string fileName = Path.Combine(path, "Mecanica.txt");

            List<Mecanica> list = new MecanicaBLL().ListExport();
            StringBuilder conteudo = new StringBuilder();

            foreach (Mecanica item in list)
            {
                conteudo.AppendLine($"{item.Id};{item.Nome};{item.Endereco};{item.Numero};{item.Complemento};{item.CEP};{item.Bairro};{item.Cidade};{item.UF};{item.Site};{item.Email};{item.Telefone1};{item.Telefone2};{item.Celular1};{item.Celular1Operadora};{item.Celular2};{item.Celular2Operadora};{item.Contatos};{item.Observacao}");
            }

            lock (_logLockObj)
            {
                try
                {
                    FileInfo t = new FileInfo(fileName);
                    using (StreamWriter Tex = t.CreateText())
                    {
                        Tex.WriteLine(conteudo.ToString()); //Aqui vai o conteúdo que já existia                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        static void ExportAbastecimento(string path)
        {           
            string fileName = Path.Combine(path, "Abastecimento.txt");

            List<Abastecimento> list = new AbastecimentoBLL().ListExport();
            StringBuilder conteudo = new StringBuilder();

            foreach (Abastecimento item in list)
            {
                conteudo.AppendLine($"{item.Id};{item.Quantidade};{item.CombustivelId};{item.Valor};{item.KM};{item.Data};{item.VeiculoID}");
            }

            lock (_logLockObj)
            {
                try
                {
                    FileInfo t = new FileInfo(fileName);
                    using (StreamWriter Tex = t.CreateText())
                    {
                        Tex.WriteLine(conteudo.ToString()); //Aqui vai o conteúdo que já existia                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        static void ExportOleo(string path)
        {
            string fileName = Path.Combine(path, "Oleo.txt");

            List<Oleo> list = new OleoBLL().ListExport();
            StringBuilder conteudo = new StringBuilder();

            foreach (Oleo item in list)
            {
                conteudo.AppendLine($"{item.Id};{item.Data};{item.TipoOperacao};{item.TipoOleo};{item.Quantidade};{item.Valor};{item.KM};{item.VeiculoID}");
            }

            lock (_logLockObj)
            {
                try
                {
                    FileInfo t = new FileInfo(fileName);
                    using (StreamWriter Tex = t.CreateText())
                    {
                        Tex.WriteLine(conteudo.ToString()); //Aqui vai o conteúdo que já existia                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        static void ExportManutencao(string path)
        {
            string fileName = Path.Combine(path, "Manutencao.txt");

            List<Manutencao> list = new ManutencaoBLL().ListExport();
            StringBuilder conteudo = new StringBuilder();

            foreach (Manutencao item in list)
            {
                conteudo.AppendLine($"{item.Id};{item.Data};{item.Valor};{item.Descricao};{item.KM};{item.VeiculoID};{item.MecanicaID}");
            }

            lock (_logLockObj)
            {
                try
                {
                    FileInfo t = new FileInfo(fileName);
                    using (StreamWriter Tex = t.CreateText())
                    {
                        Tex.WriteLine(conteudo.ToString()); //Aqui vai o conteúdo que já existia                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
