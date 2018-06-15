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
using CFSqlCe.Dal;

namespace GestaoFrota
{
    public partial class frmAlterarVeiculo : Form
    {
        Veiculo veiculo = new Veiculo();
        List<CarroFIPEinfo> carros = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAno = new List<CarroAnoFIPEinfo>();

        public Veiculo Veiculo { get; private set; }

        public frmAlterarVeiculo(Veiculo info)
        {
            InitializeComponent();
            veiculo = info;
            cmbAnoModelo.Enabled = false;
        }

        private void frmAlterarVeiculo_Load(object sender, EventArgs e)
        {
            CarregarComboBoxModelo();
        }

        private void cmbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                carrosAno = new FIPEBLL().FindCarrosAnoFIPE(veiculo.Tipo, veiculo.IdFIPEMarca, (long)cmbModelo.SelectedValue);

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

        private void CarregarComboBoxModelo()
        {
            try
            {
                carros = new FIPEBLL().FindCarrosFIPE(veiculo.Tipo,  veiculo.IdFIPEMarca);

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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            veiculo.FIPEModelo = cmbModelo.Text;
            veiculo.IdFIPEModelo = (long)cmbModelo.SelectedValue;           
            veiculo.KeyFIPEModelo = carros.Where(w => w.id.Equals(veiculo.IdFIPEModelo)).Select(s => s.key).First();
            veiculo.AnoModelo = cmbAnoModelo.Text;
            veiculo.IdFipeAno = (string)cmbAnoModelo.SelectedValue;
            veiculo.FipeNameAno = cmbAnoModelo.Text;

            Veiculo = veiculo;

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
