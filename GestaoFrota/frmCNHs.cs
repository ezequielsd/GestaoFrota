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
    public partial class frmCNHs : Form
    {
        CNHBLL cNHBLL = CNHBLL.Instancia;

        public frmCNHs()
        {
            InitializeComponent();
        }

        private void frmCNHs_Load(object sender, EventArgs e)
        {
            CarregaDatagrid();
        }       

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmCNH frm = new frmCNH();
            frm.ShowDialog();
            CarregaDatagrid();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if(dtCNHs.RowCount == 0)
            {
                MessageBox.Show("Não existe registro a ser visualizado!", "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string registro = (string)dtCNHs.CurrentRow.Cells[0].Value;
                frmCNH frmCNH = new frmCNH(registro);
                frmCNH.ShowDialog();
                CarregaDatagrid();
            }            
        }

        private void CarregaDatagrid()
        {
            dtCNHs.DataSource = cNHBLL.ListDt();

            FormartaDataGridViewAbastecimentos();
        }

        private void FormartaDataGridViewAbastecimentos()
        {
            ////esconde as colunas desnecessárias
            //dtAbastecimento.Columns["NumeroOrcamento"].Visible = false;
            //dtAbastecimento.Columns["Id"].Visible = false;
            //dtAbastecimento.Columns["Revisao"].Visible = false;

            //ajusta lagura da coluna
            dtCNHs.Columns["NumeroRegistro"].Width = 150;
            dtCNHs.Columns["Nome"].Width = 300;
            dtCNHs.Columns["Validade"].Width = 143;

            //ajusta o texto header do grid
            //dtAbastecimento.Columns["Quantidade"].HeaderText = "Qntd. (lts/m³)";
            //dtAbastecimento.Columns["PathComprovantePDF"].HeaderText = "Comprovante";

            //alinhamento dos headers das colunas
            foreach (DataGridViewColumn col in dtCNHs.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //alinhamento das colunas
            dtCNHs.Columns["NumeroRegistro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCNHs.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCNHs.Columns["Validade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
