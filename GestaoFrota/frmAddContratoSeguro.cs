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
    public partial class frmAddContratoSeguro : Form
    {
        Veiculo veiculo;
        SeguradoraBLL seguradoraBLL = SeguradoraBLL.Instancia;
        ContratoSeguradoraBLL contratoSeguradoraBLL = ContratoSeguradoraBLL.Instancia;
        List<DGridSeguradoraInfo> seguradoras = new List<DGridSeguradoraInfo>();
        string pathOrigemOrcamento = string.Empty;
        string pathDestinoOrcamento = string.Empty;
        string fileNameOrcamento = string.Empty;
        string pathOrigemCartao = string.Empty;
        string pathDestinoCartao = string.Empty;
        string fileNameCartao = string.Empty;
        string pathSeguro = Path.Combine(Environment.CurrentDirectory, "Seguros");        

        public ContratoSeguro Contrato { get; private set; }

        public frmAddContratoSeguro()
        {
            InitializeComponent();
        }

        public frmAddContratoSeguro(Veiculo info)
        {
            InitializeComponent();
            veiculo = info;
        }

        private void frmAddContratoSeguro_Load(object sender, EventArgs e)
        {
            CarregarComboBoxSeguradora();
            dateTimePickerInicioContrato.Value = DateTime.Now;
            dateTimePickerFinalContrato.Value = DateTime.Now;
            lblMensagem.Visible = false;
        }

        private void CarregarComboBoxSeguradora()
        {
            try
            {
                seguradoras = seguradoraBLL.ListDt();

                //preenche o combo carros
                cmbSeguradora.DataSource = seguradoras;
                cmbSeguradora.DisplayMember = "Nome";
                cmbSeguradora.ValueMember = "id";
                cmbSeguradora.SelectedIndex = -1;                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtPathCartaoSeguro.Text) || !String.IsNullOrWhiteSpace(txtPathCartaoSeguro.Text))
                    {
                        VerificaPasta(pathSeguro);
                        CopiaComprovante(pathOrigemCartao, pathDestinoCartao);
                    }

                    if (!String.IsNullOrEmpty(txtPathOrcamentoSeguro.Text) || !String.IsNullOrWhiteSpace(txtPathOrcamentoSeguro.Text))
                    {
                        VerificaPasta(pathSeguro);
                        CopiaComprovante(pathOrigemOrcamento, pathDestinoOrcamento);
                    }

                    ContratoSeguro contrato = new ContratoSeguro
                    {
                        DataInicialContrato = dateTimePickerInicioContrato.Value.Date,
                        DataFinalContrato = dateTimePickerFinalContrato.Value.Date,
                        NumeroApolice = txtNumeroContrato.Text,
                        SeguradoraId = (int)cmbSeguradora.SelectedValue,
                        Veiculo = veiculo,
                        PathCartaoPDF = fileNameCartao,
                        PathOrcamentoPDF = fileNameOrcamento,
                        VeiculoID = veiculo.Placa,
                        Ativo = true                        
                    };

                    contrato.Seguradora = seguradoraBLL.Get(contrato.SeguradoraId);
                    contratoSeguradoraBLL.Insert(contrato);
                    this.Contrato = contrato;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problemas ao inserir contrato: {ex.Message}", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnexarOrcamentoSeguro_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemOrcamento = this.openFileDialog1.FileName;
                fileNameOrcamento = this.openFileDialog1.SafeFileName;
                pathDestinoOrcamento = Path.Combine(pathSeguro, fileNameOrcamento);
                txtPathOrcamentoSeguro.Text = pathOrigemOrcamento;
            }
        }

        private void btnAnexarCartaoSeguro_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOrigemCartao = this.openFileDialog1.FileName;
                fileNameCartao = this.openFileDialog1.SafeFileName;
                pathDestinoCartao = Path.Combine(pathSeguro, fileNameCartao);
                txtPathCartaoSeguro.Text = pathOrigemCartao;
            }
        }

        private bool ValidaCampos()
        {
            if (String.IsNullOrEmpty(txtNumeroContrato.Text) || String.IsNullOrWhiteSpace(txtNumeroContrato.Text))
            {                
                lblMensagem.Text = "O Numero do contrato deve ser preenchido corretamente!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {                
                lblMensagem.Visible = false;
            }

            if (cmbSeguradora.SelectedIndex == -1)
            {
                lblMensagem.Text = "Selecione uma seguradora!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                lblMensagem.Visible = false;
            }

            if (dateTimePickerInicioContrato.Value == dateTimePickerFinalContrato.Value)
            {
                lblMensagem.Text = "Selecione uma data correta para vigencia do contrato!";
                lblMensagem.Visible = true;
                return false;
            }
            else
            {
                lblMensagem.Visible = false;
            }

            return true;
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
                    frmRenomearArquivo frmAlterar = new frmRenomearArquivo(fileNameOrcamento);
                    frmAlterar.ShowDialog();

                    if (frmAlterar.FileName != null)
                    {
                        var destino = Path.Combine(pathSeguro, frmAlterar.FileName);
                        fileNameOrcamento = frmAlterar.FileName;
                        CopiaComprovante(fileOrigem, destino);
                    }
                }
            }
        }
    }
}
