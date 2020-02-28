using CFSqlCe.Dal;
using GestaoFrota.BLL;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFrota
{
    public partial class frmAdicionarComprovante : Form
    {
        AbastecimentoBLL abastecimentoBLL = AbastecimentoBLL.Instancia;
        ManutencaoBLL manutencaoBLL = ManutencaoBLL.Instancia;
        MultaBLL multaBLL = MultaBLL.Instancia;
        string pathOrigemComprovante = string.Empty;
        string pathDestinoComprovante = string.Empty;
        string pathOrigemMulta = string.Empty;
        string pathDestinoMulta = string.Empty;
        string pathComprovante = Path.Combine(Environment.CurrentDirectory, "Comprovantes");
        string pathMultas = Path.Combine(Environment.CurrentDirectory, "Multas");
        string fileNameComprovante = string.Empty;
        string fileNameMulta = string.Empty;
        TipoAnexo tipoComprovanteAnexa;
        int idC = 0;

        public frmAdicionarComprovante(int id, TipoAnexo tipoComprovante)
        {
            InitializeComponent();
            tipoComprovanteAnexa = tipoComprovante;
            idC = id;
        }

        private void frmAdicionarComprovante_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAnexarComprovante_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (tipoComprovanteAnexa == TipoAnexo.Multa)
                {
                    pathOrigemMulta = this.openFileDialog1.FileName;
                    fileNameMulta = this.openFileDialog1.SafeFileName;
                    pathDestinoMulta = Path.Combine(pathMultas, fileNameMulta);
                    txtPathComprovanteAbastecimento.Text = pathOrigemMulta;
                }
                else
                {
                    pathOrigemComprovante = this.openFileDialog1.FileName;
                    fileNameComprovante = this.openFileDialog1.SafeFileName;
                    pathDestinoComprovante = Path.Combine(pathComprovante, fileNameComprovante);
                    txtPathComprovanteAbastecimento.Text = pathOrigemComprovante;
                }                
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            switch (tipoComprovanteAnexa)
            {
                case TipoAnexo.Abastecimento:
                    if (!String.IsNullOrEmpty(txtPathComprovanteAbastecimento.Text) || !String.IsNullOrWhiteSpace(txtPathComprovanteAbastecimento.Text))
                    {
                        VerificaPasta(pathComprovante);
                        CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                        abastecimentoBLL.AnexarComprovante(idC, fileNameComprovante);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Selecionar um arquivo para anexar!", "Selecioner um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;               
                case TipoAnexo.Manutencao:
                    if (!String.IsNullOrEmpty(txtPathComprovanteAbastecimento.Text) || !String.IsNullOrWhiteSpace(txtPathComprovanteAbastecimento.Text))
                    {
                        VerificaPasta(pathComprovante);
                        CopiaComprovante(pathOrigemComprovante, pathDestinoComprovante);
                        manutencaoBLL.AnexarComprovante(idC, fileNameComprovante);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Selecionar um arquivo para anexar!", "Selecioner um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoAnexo.Multa:
                    if (!String.IsNullOrEmpty(txtPathComprovanteAbastecimento.Text) || !String.IsNullOrWhiteSpace(txtPathComprovanteAbastecimento.Text))
                    {
                        VerificaPasta(pathMultas);
                        CopiaComprovante(pathOrigemMulta, pathDestinoMulta);
                        multaBLL.AnexarComprovante(idC, fileNameMulta);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Selecionar um arquivo para anexar!", "Selecioner um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerificaPasta(string path)
        {
            //Verifica se existe, senão cria   
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        private void CopiaComprovante(string fileOrigem, string fileDestino)
        {
            try
            {
                File.SetAttributes(fileOrigem, FileAttributes.Normal);
                File.Copy(fileOrigem, fileDestino, false);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show($"Diretório de origem ou de destino não foi encontrado! {ex.Message}", "Diretório não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Não foi possivel localizar o arquivo! {ex.Message}", "Arquivo não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show($"Arquivo está no formato invalido! {ex.Message}", "Arquivo não localizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                if (MessageBox.Show("Arquivo já existe! Repetir para vincular este registro com o comprovante existente, ou Cancelar para renomear o arquivo", "Arquivo já existe com este nome", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                {
                    File.SetAttributes(fileOrigem, FileAttributes.Normal);
                    File.Copy(fileOrigem, fileDestino, true);
                }
                else
                {
                    frmRenomearArquivo frmAlterar = new frmRenomearArquivo(fileNameComprovante);
                    frmAlterar.ShowDialog();

                    if (frmAlterar.FileName != null)
                    {
                        var destino = Path.Combine(pathComprovante, frmAlterar.FileName);
                        fileNameComprovante = frmAlterar.FileName;
                        CopiaComprovante(fileOrigem, destino);
                    }
                }
            }
        }
    }
}
