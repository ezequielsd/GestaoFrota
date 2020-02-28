using CFSqlCe.Dal;
using GestaoFrota.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFrota
{
    public partial class frmSeguradora : Form
    {
        SeguradoraBLL seguradoraBLL = SeguradoraBLL.Instancia;
        Seguradora seguradora;

        public frmSeguradora()
        {
            InitializeComponent();
            btnAdicionar.Visible = true;
            btnEditar.Visible = false;
            btnSalvar.Visible = false;
        }

        public frmSeguradora(int Id)
        {
            InitializeComponent();
            btnAdicionar.Visible = false;
            btnEditar.Visible = true;
            seguradora = seguradoraBLL.Get(Id);
            PreencherFormulario();
            DesabilitarCampos();
            btnEditar.Location = new Point(595, 417);
            btnSalvar.Visible = false;
        }

            private void frmSeguradora_Load(object sender, EventArgs e)
        {

        }

        private void PreencherFormulario()
        {
            txtNome.Text = seguradora.Nome;
            txtEndereco.Text = seguradora.Endereco;
            txtComplemento.Text = seguradora.Complemento;
            txtNumero.Text = seguradora.Numero;
            txtCEP.Text = seguradora.CEP;
            txtBairro.Text = seguradora.Bairro;
            txtCidade.Text = seguradora.Cidade;
            cmbUf.Text = seguradora.UF;
            txtSite.Text = seguradora.Site;
            txtEmail.Text = seguradora.Email;
            txtFone1.Text = seguradora.Telefone1;
            txtFone2.Text = seguradora.Telefone2;
            txtCelular1.Text = seguradora.Celular1;
            txtCelular2.Text = seguradora.Celular2;
            cmbOperadora1.Text = seguradora.Celular1Operadora;
            cmbOperadora2.Text = seguradora.Celular2Operadora;
            txtContatos.Text = seguradora.Contatos;
        }

        private void DesabilitarCampos()
        {
            txtNome.ReadOnly = true;
            txtCorretor.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtComplemento.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtCEP.ReadOnly = true;
            txtBairro.ReadOnly = true;
            txtCidade.ReadOnly = true;
            cmbUf.Enabled = false;
            txtSite.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtFone1.ReadOnly = true;
            txtFone2.ReadOnly = true;
            txtCelular1.ReadOnly = true;
            txtCelular2.ReadOnly = true;
            cmbOperadora1.Enabled = false;
            cmbOperadora2.Enabled = false;
            txtContatos.ReadOnly = true;
        }

        private void HabilitarCampos()
        {
            txtNome.ReadOnly = false;
            txtCorretor.ReadOnly = false;
            txtEndereco.ReadOnly = false;
            txtComplemento.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtCEP.ReadOnly = false;
            txtBairro.ReadOnly = false;
            txtCidade.ReadOnly = false;
            cmbUf.Enabled = true;
            txtSite.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtFone1.ReadOnly = false;
            txtFone2.ReadOnly = false;
            txtCelular1.ReadOnly = false;
            txtCelular2.ReadOnly = false;
            cmbOperadora1.Enabled = true;
            cmbOperadora2.Enabled = true;
            txtContatos.ReadOnly = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Seguradora segurad = new Seguradora
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Complemento = txtComplemento.Text,
                Numero = txtNumero.Text,
                CEP = txtCEP.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                UF = cmbUf.Text,
                Site = txtSite.Text,
                Email = txtEmail.Text,
                Telefone1 = txtFone1.Text,
                Telefone2 = txtFone2.Text,
                Celular1 = txtCelular1.Text,
                Celular2 = txtCelular2.Text,
                Celular1Operadora = cmbOperadora1.Text,
                Celular2Operadora = cmbOperadora2.Text,
                Contatos = txtContatos.Text
            };

            try
            {
                seguradoraBLL.Insert(segurad);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnEditar.Visible = false;
            btnSalvar.Location = new Point(595, 417);
            btnSalvar.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            seguradora.Nome = txtNome.Text;
            seguradora.Endereco = txtEndereco.Text;
            seguradora.Complemento = txtComplemento.Text;
            seguradora.Numero = txtNumero.Text;
            seguradora.CEP = txtCEP.Text;
            seguradora.Bairro = txtBairro.Text;
            seguradora.Cidade = txtCidade.Text;
            seguradora.UF = cmbUf.Text;
            seguradora.Site = txtSite.Text;
            seguradora.Email = txtEmail.Text;
            seguradora.Telefone1 = txtFone1.Text;
            seguradora.Telefone2 = txtFone2.Text;
            seguradora.Celular1 = txtCelular1.Text;
            seguradora.Celular2 = txtCelular2.Text;
            seguradora.Celular1Operadora = cmbOperadora1.Text;
            seguradora.Celular2Operadora = cmbOperadora2.Text;
            seguradora.Contatos = txtContatos.Text;

            try
            {
                seguradoraBLL.Save(seguradora);
                DesabilitarCampos();
                btnEditar.Visible = true;
                btnSalvar.Visible = false;
                btnEditar.Location = new Point(595, 417);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
