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
        }

        private void frmAlterarVeiculo_Load(object sender, EventArgs e)
        {
            txtModelo.Text = veiculo.FIPEModelo;
            txtAnoModelo.Text = veiculo.AnoModelo;
        }
               
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtAnoModelo.Text) || String.IsNullOrWhiteSpace(txtAnoModelo.Text))
            {
                MessageBox.Show("Informe um ano válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtModelo.Text) || String.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Informe um modelo válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            veiculo.FIPEModelo = txtModelo.Text;                        
            veiculo.AnoModelo = txtAnoModelo.Text;            
            
            Veiculo = veiculo;

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
