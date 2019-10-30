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

namespace GestaoFrota
{
    public partial class frmSelecionarPais : Form
    {
        public frmSelecionarPais()
        {
            InitializeComponent();
        }

        private void frmSelecionarPais_Load(object sender, EventArgs e)
        {
            PreencherComboBoxPais();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreencherComboBoxPais()
        {
            List<Internacionalizacao> inter = InternacionalizacaoBLL.ListInternacionalizacao();

            //preenche o combo fabricantes
            cmbPais.DataSource = inter;
            cmbPais.DisplayMember = "Pais";
            cmbPais.ValueMember = "CodPais";
            cmbPais.SelectedIndex = -1;

        }

        
    }
}
