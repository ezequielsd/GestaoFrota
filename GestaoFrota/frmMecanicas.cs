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
    public partial class frmMecanicas : Form
    {
        MecanicaBLL mecanicaBLL = MecanicaBLL.Instancia;

        public frmMecanicas()
        {
            InitializeComponent();
        }

        private void frmMecanicas_Load(object sender, EventArgs e)
        {
            PreencherDtMecanicas();
        }

        private void PreencherDtMecanicas()
        {
            dtMecanicas.DataSource = mecanicaBLL.ListDt();

            ////esconde as colunas desnecessárias
            //dtAbastecimento.Columns["NumeroOrcamento"].Visible = false;
            //dtAbastecimento.Columns["Id"].Visible = false;
            //dtAbastecimento.Columns["Revisao"].Visible = false;

            //ajusta lagura da coluna
            dtMecanicas.Columns["Id"].Width = 50;
            dtMecanicas.Columns["Nome"].Width = 300;
            dtMecanicas.Columns["Telefone1"].Width = 80;
            dtMecanicas.Columns["Celular"].Width = 100;
            dtMecanicas.Columns["Email"].Width = 230;

            //ajusta o texto header do grid
           // dtMecanicas.Columns["Quantidade"].HeaderText = "Qntd. (lts/m³)";
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {          
            int id = (int)dtMecanicas.CurrentRow.Cells[0].Value;
            frmCadastarMecanica frmVisuaMeca = new frmCadastarMecanica(id);
            frmVisuaMeca.ShowDialog();
            PreencherDtMecanicas();
        }
    }
}
