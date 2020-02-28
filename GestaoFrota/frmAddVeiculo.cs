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
using GestaoFrota.Models;
using FIPE;
using CFSqlCe.Dal;

namespace GestaoFrota
{
    public partial class frmAddVeiculo : Form
    {
        #region Variaveis

        CombustivelBLL combustivelBLL = CombustivelBLL.Instancia;
        VeiculoBLL veiculoBLL = VeiculoBLL.Instancia;
        List<TipoFIPEinfo> tipos = new List<TipoFIPEinfo>();
        List<MarcaFIPEinfo> marcas = new List<MarcaFIPEinfo>();
        List<CarroFIPEinfo> carros = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAno = new List<CarroAnoFIPEinfo>();
        string cultureInfo = string.Empty;

        #endregion

        #region Construtores

        public frmAddVeiculo(string culture)
        {
            this.cultureInfo = culture;
            InitializeComponent();
        }

        #endregion

        private void frmAddVeiculo_Load(object sender, EventArgs e)
        {
            PreencherComboBoxTipo();
            PreencherComboBoxCombustivel();
            txtFabricante.Enabled = false;
            txtModelo.Enabled = false;
            txtAnoModelo.Enabled = false;
            txtPlaca.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(txtFabricante.Text) || String.IsNullOrWhiteSpace(txtFabricante.Text))
            {
                MessageBox.Show("Informe um fabricante válido.", "mesagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtModelo.Text) || String.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Informe um nodelo válido.", "mesagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtAnoModelo.Text) || String.IsNullOrWhiteSpace(txtAnoModelo.Text))
            {
                MessageBox.Show("Informe o ano do modelo corretamente.", "mesagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtAnoModelo.Text) || String.IsNullOrWhiteSpace(txtAnoModelo.Text))
            {
                MessageBox.Show("Informe a placa do veículo corretamente.", "mesagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Veiculo info = new Veiculo();

            info.FIPEModelo = txtModelo.Text;                
            info.FipeNameMarca = txtFabricante.Text;           
            info.AnoModelo = txtAnoModelo.Text;                        
            info.Placa = txtPlaca.Text.ToUpper();           
            info.Combustivel = (int)cmbCombustivel.SelectedValue;
            info.Tipo = (string)cmbTipo.SelectedValue;
            info.Ativo = true;
            info.DataVencimentoIPVA = DateTime.Now;
            info.CultureInfo = cultureInfo;

            try
            {
                veiculoBLL.Insert(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar veículo: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void PreencherComboBoxTipo()
        {
            try
            {
                tipos = new FIPEBLL().FindTiposFIPE();

                //preenche o combo fabricantes
                cmbTipo.DataSource = tipos;
                cmbTipo.DisplayMember = "Descricao";
                cmbTipo.ValueMember = "Tipo";
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtFabricante.Enabled = true;
            txtModelo.Enabled = true;
            txtAnoModelo.Enabled = true;
            txtPlaca.Enabled = true;
        }

        private void PreencherComboBoxCombustivel()
        {
            var combusitiveis = combustivelBLL.GetList();

            //preenche o combo combustivel
            cmbCombustivel.DataSource = combusitiveis;
            cmbCombustivel.DisplayMember = "Tipo";
            cmbCombustivel.ValueMember = "Id";
            cmbCombustivel.SelectedIndex = -1;
        }

    }
}
