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
    public partial class frmTipoManutencao : Form
    {
        ManutencaoBLL manutencaoBLL = ManutencaoBLL.Instancia;

        public frmTipoManutencao()
        {
            InitializeComponent();
        }

        private void frmTipoManutencao_Load(object sender, EventArgs e)
        {
            CarregaDatagrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmAddTipoManutencao frm = new frmAddTipoManutencao();
            frm.ShowDialog();
            CarregaDatagrid();
        }

        private void CarregaDatagrid()
        {
            dtTipoManutencao.DataSource = manutencaoBLL.ListTipoManutencao();

            FormartaDataGridViewAbastecimentos();
        }

        private void FormartaDataGridViewAbastecimentos()
        {
            //ajusta lagura da coluna
            dtTipoManutencao.Columns["Id"].Width = 50;
            dtTipoManutencao.Columns["Descricao"].Width = 302;            

            //ajusta o texto header do grid            
            dtTipoManutencao.Columns["Descricao"].HeaderText = "Descrição";

            //alinhamento dos headers das colunas
            foreach (DataGridViewColumn col in dtTipoManutencao.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //alinhamento das colunas
            dtTipoManutencao.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtTipoManutencao.Columns["Descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

    }
}
