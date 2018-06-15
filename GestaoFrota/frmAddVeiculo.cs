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
        List<TipoFIPEinfo> tipos = new List<TipoFIPEinfo>();
        List<MarcaFIPEinfo> marcas = new List<MarcaFIPEinfo>();
        List<CarroFIPEinfo> carros = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAno = new List<CarroAnoFIPEinfo>();

        public frmAddVeiculo()
        {
            InitializeComponent();
        }

        private void frmAddVeiculo_Load(object sender, EventArgs e)
        {
            PreencherComboBoxTipo();
            cmbFabricante.Enabled = false;
            cmbModelo.Enabled = false;
            cmbAnoModelo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            VeiculoBLL veiculoBll = new VeiculoBLL();

            Veiculo info = new Veiculo();

            info.FIPEModelo = cmbModelo.Text;
            info.IdFIPEModelo = (long)cmbModelo.SelectedValue;         
            info.FipeNameMarca = cmbFabricante.Text;
            info.KeyFIPEModelo = carros.Where(w => w.id.Equals(info.IdFIPEModelo)).Select(s => s.key).First();
            info.IdFIPEMarca = (int)cmbFabricante.SelectedValue;
            info.KeyFIPEMarca = marcas.Where(w => w.Id.Equals(info.IdFIPEMarca)).Select(s => s.Key).First();
            info.AnoModelo = cmbAnoModelo.Text;
            info.IdFipeAno = (string)cmbAnoModelo.SelectedValue;
            info.FipeNameAno = cmbAnoModelo.Text;
            info.Placa = txtPlaca.Text.ToUpper();
            info.Combustivel = 1;
            info.Tipo = (string)cmbTipo.SelectedValue;
            info.Ativo = true;
            info.DataVencimentoIPVA = DateTime.Now;

            try
            {
                veiculoBll.Insert(info);
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
            try
            {
                marcas = new FIPEBLL().FindMarcasFIPE((string)cmbTipo.SelectedValue);

                //preenche o combo fabricantes
                cmbFabricante.DataSource = marcas;
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
                carros = new FIPEBLL().FindCarrosFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue);

                //preenche o combo carros
                cmbModelo.DataSource = carros;
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
                carrosAno = new FIPEBLL().FindCarrosAnoFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue, (long)cmbModelo.SelectedValue);

                //preenche o combo carros
                cmbAnoModelo.DataSource = carrosAno;
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
    }
}
