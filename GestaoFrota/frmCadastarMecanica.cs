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
    public partial class frmCadastarMecanica : Form
    {
        MecanicaBLL mecanicaBLL = MecanicaBLL.Instancia;
        Mecanica mecanica;

        public frmCadastarMecanica()
        {
            InitializeComponent();            
            btnAdicionar.Visible = true;
            btnEditar.Visible = false;
            btnSalvar.Visible = false;
        }

        public frmCadastarMecanica(int Id)
        {
            InitializeComponent();            
            btnAdicionar.Visible = false;
            btnEditar.Visible = true;
            mecanica = mecanicaBLL.Get(Id);
            PreencherFormulario();
            DesabilitarCampos();
            btnEditar.Location = new Point(595, 417);
            btnSalvar.Visible = false;
        }
        
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Mecanica mecanica = new Mecanica
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
                mecanicaBLL.Insert(mecanica);
                this.Close();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnEditar.Visible = false;
            btnSalvar.Location = new Point(595, 417);
            btnSalvar.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mecanica.Nome = txtNome.Text;
            mecanica.Endereco = txtEndereco.Text;
            mecanica.Complemento = txtComplemento.Text;
            mecanica.Numero = txtNumero.Text;
            mecanica.CEP = txtCEP.Text;
            mecanica.Bairro = txtBairro.Text;
            mecanica.Cidade = txtCidade.Text;
            mecanica.UF = cmbUf.Text;
            mecanica.Site = txtSite.Text;
            mecanica.Email = txtEmail.Text;
            mecanica.Telefone1 = txtFone1.Text;
            mecanica.Telefone2 = txtFone2.Text;
            mecanica.Celular1 = txtCelular1.Text;
            mecanica.Celular2 = txtCelular2.Text;
            mecanica.Celular1Operadora = cmbOperadora1.Text;
            mecanica.Celular2Operadora = cmbOperadora2.Text;
            mecanica.Contatos = txtContatos.Text;

            try
            {
                mecanicaBLL.Save(mecanica);
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

        private void PreencherFormulario()
        {            
            txtNome.Text = mecanica.Nome;
            txtEndereco.Text = mecanica.Endereco;
            txtComplemento.Text = mecanica.Complemento;
            txtNumero.Text = mecanica.Numero;
            txtCEP.Text = mecanica.CEP;
            txtBairro.Text = mecanica.Bairro;
            txtCidade.Text = mecanica.Cidade;
            cmbUf.Text = mecanica.UF;
            txtSite.Text = mecanica.Site;
            txtEmail.Text = mecanica.Email;
            txtFone1.Text = mecanica.Telefone1;
            txtFone2.Text = mecanica.Telefone2;
            txtCelular1.Text = mecanica.Celular1;
            txtCelular2.Text = mecanica.Celular2;
            cmbOperadora1.Text = mecanica.Celular1Operadora;
            cmbOperadora2.Text = mecanica.Celular2Operadora;
            txtContatos.Text = mecanica.Contatos;
        }

        private void DesabilitarCampos()
        {
            txtNome.ReadOnly = true;
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
    }
}
