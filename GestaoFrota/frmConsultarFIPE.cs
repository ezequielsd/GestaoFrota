using GestaoFrota.BLL;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIPE;

namespace GestaoFrota
{
    public partial class frmConsultarFIPE : Form
    {
        List<TipoFIPEinfo> tipos = new List<TipoFIPEinfo>();
        List<MarcaFIPEinfo> marcasFIPE = new List<MarcaFIPEinfo>();
        List<CarroFIPEinfo> carrosFIPE = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAnoFIPE = new List<CarroAnoFIPEinfo>();

        public frmConsultarFIPE()
        {
            InitializeComponent();
        }

        private void frmConsultarFIPE_Load(object sender, EventArgs e)
        {
            PreencherComboBoxTipo();
            cmbFabricante.Enabled = false;
            cmbModelo.Enabled = false;
            cmbAnoModelo.Enabled = false;
        }

        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                marcasFIPE = new FIPEBLL().FindMarcasFIPE((string)cmbTipo.SelectedValue);

                //preenche o combo fabricantes
                cmbFabricante.DataSource = marcasFIPE;
                cmbFabricante.DisplayMember = "Fipe_Name";
                cmbFabricante.ValueMember = "Id";
                cmbFabricante.SelectedIndex = -1;

                cmbFabricante.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                carrosFIPE = new FIPEBLL().FindCarrosFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue);

                //preenche o combo carros
                cmbModelo.DataSource = carrosFIPE;
                cmbModelo.DisplayMember = "fipe_name";
                cmbModelo.ValueMember = "id";
                cmbModelo.SelectedIndex = -1;

                cmbModelo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }           
        }

        private void cmbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                carrosAnoFIPE = new FIPEBLL().FindCarrosAnoFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue, (long)cmbModelo.SelectedValue);

                //preenche o combo carros
                cmbAnoModelo.DataSource = carrosAnoFIPE;
                cmbAnoModelo.DisplayMember = "name";
                cmbAnoModelo.ValueMember = "id";
                cmbAnoModelo.SelectedIndex = -1;

                cmbAnoModelo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
            
        }

        private void btnConsultarFIPE_Click(object sender, EventArgs e)
        {
            ConsultaFIPEOutroCarro((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue, (long)cmbModelo.SelectedValue, (string)cmbAnoModelo.SelectedValue);
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

        private void ConsultaFIPEOutroCarro(string tipo, int idMarca, long idModelo, string idAnoModelo)
        {
            try
            {
                ConsultaFIPEinfo consulta = new FIPEBLL().FindPrecoFIPE(tipo, idMarca, idModelo, idAnoModelo);

                label24.Text = $"Marca: {consulta.marca}";
                label23.Text = $"Veiculo: {consulta.veiculo}";
                label22.Text = $"Ano modelo: {consulta.ano_modelo}";
                label21.Text = $"Combustivel: {consulta.combustivel}";
                label20.Text = $"Preço: {consulta.preco}";
                label19.Text = $"Referência: {consulta.referencia}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
