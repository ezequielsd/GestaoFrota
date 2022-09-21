using CFSqlCe.Dal;
using GestaoFrota.BLL;
using GestaoFrota.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoFrota
{
    public partial class frmSelecionarPais : Form
    {
        ConfiguracaoBLL configuracaoBLL = ConfiguracaoBLL.Instancia;

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

            if (cmbPais.SelectedIndex == -1)
                MessageBox.Show("Selecione seu País / Select your country!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Configuracao config = new Configuracao();
                Internacionalizacao internacionalizacaoSelecionado = (Internacionalizacao)cmbPais.SelectedItem;
                config.CodPais = internacionalizacaoSelecionado.CodPais;
                config.CultureInfo = internacionalizacaoSelecionado.CodCultura;
                config.Idioma = internacionalizacaoSelecionado.Idioma;

                configuracaoBLL.Insert(config);
                this.Close();
            }            
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
