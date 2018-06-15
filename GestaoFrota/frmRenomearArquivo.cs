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
    public partial class frmRenomearArquivo : Form
    {
        string fileName = string.Empty;
        string[] fileNameArray;
        public string FileName { get; private set; }

        public frmRenomearArquivo(string arq)
        {
            InitializeComponent();
            fileNameArray = arq.Split('.');
        }

        private void frmRenomearArquivo_Load(object sender, EventArgs e)
        {
            if (fileNameArray.Count() > 1)
                cmbTipoExtensao.Text = $".{fileNameArray[1]}";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbTipoExtensao.SelectedIndex != -1)
            {
                FileName = $"{txtNewFileName.Text}{cmbTipoExtensao.Text}";
                this.Close();
            }            
            else
                MessageBox.Show("Selecione uma extensão para o arquivo!", "Sem extensão definido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
