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
    public partial class frmSeguradoras : Form
    {
        SeguradoraBLL seguradoraBLL = SeguradoraBLL.Instancia;

        public frmSeguradoras()
        {
            InitializeComponent();
        }

        private void frmSeguradoras_Load(object sender, EventArgs e)
        {
            PreencherDtSeguradoras();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmSeguradora frm = new frmSeguradora();
            frm.ShowDialog();
            PreencherDtSeguradoras();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dtSeguradoras.RowCount == 0)
            {
                MessageBox.Show("Não existe registro a ser visualizado!", "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = (int)dtSeguradoras.CurrentRow.Cells[0].Value;
                frmSeguradora frm = new frmSeguradora(id);
                frm.ShowDialog();
                PreencherDtSeguradoras();
            }
        }

        private void PreencherDtSeguradoras()
        {
            dtSeguradoras.DataSource = seguradoraBLL.ListDt();

            ////esconde as colunas desnecessárias
            //dtAbastecimento.Columns["NumeroOrcamento"].Visible = false;
            //dtAbastecimento.Columns["Id"].Visible = false;
            //dtAbastecimento.Columns["Revisao"].Visible = false;

            //ajusta lagura da coluna
            dtSeguradoras.Columns["Id"].Width = 50;
            dtSeguradoras.Columns["Nome"].Width = 300;
            dtSeguradoras.Columns["Telefone1"].Width = 80;
            dtSeguradoras.Columns["Celular"].Width = 100;
            dtSeguradoras.Columns["Email"].Width = 230;

            //ajusta o texto header do grid
            // dtMecanicas.Columns["Quantidade"].HeaderText = "Qntd. (lts/m³)";
        }
               
    }
}
