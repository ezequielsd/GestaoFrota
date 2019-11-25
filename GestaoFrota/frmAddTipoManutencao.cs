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
    public partial class frmAddTipoManutencao : Form
    {
        public frmAddTipoManutencao()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTipoManutencao.Text) && !String.IsNullOrWhiteSpace(txtTipoManutencao.Text))
            {
                TipoManutencao tipoManutencao = new TipoManutencao { Descricao = txtTipoManutencao.Text };
                new ManutencaoBLL().InsertTipoManutencao(tipoManutencao);
                Close();
            }
            else
                MessageBox.Show("Informe uma descrição válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
