using CFSqlCe.Dal;
using GestaoFrota.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFrota
{
    public partial class frmCNH : Form
    {
        CNHBLL cNHBLL = CNHBLL.Instancia;
        string reg = string.Empty;
        CNH cnh = new CNH();
        string pathOrigemDocumento = string.Empty;
        string pathDestinoDocumento = string.Empty;
        string pathDocumentos = Path.Combine(Environment.CurrentDirectory, "Documentos");
        string fileNameDocumento = string.Empty;
        bool anexouDocumento = false;

        public frmCNH()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnSalvar.Visible = false;
        }

        public frmCNH(string registro)
        {
            InitializeComponent();
            cnh = cNHBLL.Get(registro);
            DesativaControle();
            CarregaComponentes();
            btnAdicionar.Visible = false;
            btnEditar.Location = new Point(454, 431);
            btnSalvar.Visible = false;
        }

        private void frmCNH_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAnexarDocumento.Text) || String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                btnVisualizarDocumento.Visible = false;
            else
                btnVisualizarDocumento.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (anexouDocumento && (!String.IsNullOrEmpty(cnh.PathDocumentoPDF) && !String.IsNullOrWhiteSpace(cnh.PathDocumentoPDF)))
            {
                string pathDocumentoExistente = Path.Combine(pathDocumentos, cnh.PathDocumentoPDF);
                if (File.Exists(pathDocumentoExistente))
                {
                    try
                    {
                        File.Delete(pathDocumentoExistente);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Não foi possivel apagar o antigo documento, acesse a pasta Documentos e apague manualmente!", "Não foi possivel apagar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!String.IsNullOrEmpty(txtAnexarDocumento.Text) || !String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                {
                    CopiaComprovante(pathOrigemDocumento, pathDestinoDocumento);
                }
            }

            cnh.PathDocumentoPDF = fileNameDocumento;
            cnh.Categoria = txtCategoria.Text;
            cnh.CPF = txtCPF.Text;
            cnh.Filiacao = txtFiliacao.Text;
            cnh.Local = txtLocal.Text;
            cnh.Nome = txtNome.Text;
            cnh.NumeroRegistro = txtRegistro.Text;
            cnh.Emissao = dateTimePickerEmissao.Value;
            cnh.PrimeiraHabilitacao = dateTimePickerPrimeiraHabilitacao.Value;
            cnh.Validade = dateTimePickerValidade.Value;
            cnh.Nascimento = dateTimePickerNascimento.Value;

            try
            {
                cNHBLL.Alterar(cnh);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel salvar a alteração! {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AtivaControle();
            btnSalvar.Visible = true;
            btnSalvar.Location = new Point(454, 431);
            btnEditar.Visible = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAnexarDocumento.Text) || !String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                {
                    VerificaPasta(pathDocumentos);
                    CopiaComprovante(pathOrigemDocumento, pathDestinoDocumento);
                }

                CNH cnh = new CNH
                {
                    Aivo = true,
                    NumeroRegistro = txtRegistro.Text,
                    Categoria = txtCategoria.Text,
                    CPF = txtCPF.Text,
                    Filiacao = txtFiliacao.Text,
                    Nome = txtNome.Text,
                    Nascimento = dateTimePickerNascimento.Value,
                    PrimeiraHabilitacao = dateTimePickerPrimeiraHabilitacao.Value,
                    Local = txtLocal.Text,
                    Emissao = dateTimePickerEmissao.Value,
                    Validade = dateTimePickerValidade.Value,
                    PathDocumentoPDF = fileNameDocumento
                };


                cNHBLL.Insert(cnh);
                LimpaCampos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar o registro. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnexarDocumento_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemDocumento = this.openFileDialog1.FileName;
                fileNameDocumento = this.openFileDialog1.SafeFileName;
                pathDestinoDocumento = Path.Combine(pathDocumentos, fileNameDocumento);
                txtAnexarDocumento.Text = pathOrigemDocumento;
                anexouDocumento = true;
            }
        }

        private void btnVisualizarDocumento_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAnexarDocumento.Text) || String.IsNullOrWhiteSpace(txtAnexarDocumento.Text))
                MessageBox.Show("Este registro não possui documento anexado.", "Sem comprovante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    pathDestinoDocumento = Path.Combine(pathDocumentos, txtAnexarDocumento.Text);
                    Process.Start(pathDestinoDocumento);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao localizar documento. {ex.Message}", "Sem documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AtivaControle()
        {
            txtAnexarDocumento.ReadOnly = false;
            txtCategoria.ReadOnly = false;
            txtCPF.ReadOnly = false;
            txtFiliacao.ReadOnly = false;
            txtLocal.ReadOnly = false;
            txtNome.ReadOnly = false;
            txtRegistro.ReadOnly = false;
            dateTimePickerEmissao.Enabled = true;
            dateTimePickerPrimeiraHabilitacao.Enabled = true;
            dateTimePickerValidade.Enabled = true;
            dateTimePickerNascimento.Enabled = true;
            btnAnexarDocumento.Enabled = true;
        }

        private void DesativaControle()
        {
            txtAnexarDocumento.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtCPF.ReadOnly = true;
            txtFiliacao.ReadOnly = true;
            txtLocal.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtRegistro.ReadOnly = true;
            dateTimePickerEmissao.Enabled = false;
            dateTimePickerPrimeiraHabilitacao.Enabled = false;
            dateTimePickerValidade.Enabled = false;
            dateTimePickerNascimento.Enabled = false;
            btnAnexarDocumento.Enabled = false;
        }

        private void CarregaComponentes()
        {
            txtAnexarDocumento.Text = cnh.PathDocumentoPDF;
            txtCategoria.Text = cnh.Categoria;
            txtCPF.Text = cnh.CPF;
            txtFiliacao.Text = cnh.Filiacao;
            txtLocal.Text = cnh.Local;
            txtNome.Text = cnh.Nome;
            txtRegistro.Text = cnh.NumeroRegistro;
            dateTimePickerEmissao.Value = cnh.Emissao;
            dateTimePickerPrimeiraHabilitacao.Value = cnh.PrimeiraHabilitacao;
            dateTimePickerValidade.Value = cnh.Validade;
            dateTimePickerNascimento.Value = cnh.Nascimento;

        }

        private void LimpaCampos()
        {
            txtAnexarDocumento.Clear();
            txtCategoria.Clear();
            txtCPF.Clear();
            txtFiliacao.Clear();
            txtLocal.Clear();
            txtNome.Clear();
            txtRegistro.Clear();
            dateTimePickerEmissao.Value = DateTime.Now;
            dateTimePickerPrimeiraHabilitacao.Value = DateTime.Now;
            dateTimePickerValidade.Value = DateTime.Now;
            dateTimePickerNascimento.Value = DateTime.Now;
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
                    frmRenomearArquivo frmAlterar = new frmRenomearArquivo(fileNameDocumento);
                    frmAlterar.ShowDialog();

                    if (frmAlterar.FileName != null)
                    {
                        var destino = Path.Combine(pathDestinoDocumento, frmAlterar.FileName);
                        fileNameDocumento = frmAlterar.FileName;
                        CopiaComprovante(fileOrigem, destino);
                    }
                    else
                        throw new Exception("Não foi possivel salvar o documento");
                }
            }
        }

    }
}
