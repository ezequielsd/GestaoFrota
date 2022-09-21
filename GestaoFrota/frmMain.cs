using System;
using System.Linq;
using System.Windows.Forms;
using GestaoFrota.BLL;
using System.Collections.Generic;
using GestaoFrota.Models;
using CFSqlCe.Dal;
using System.IO;
using System.Diagnostics;

namespace GestaoFrota
{
    public partial class frmMain : Form
    {
        ConfiguracaoBLL configuracaoBLL = ConfiguracaoBLL.Instancia;
        VeiculoBLL veiculoBLL = VeiculoBLL.Instancia;
        string fileNameManual = "GUIA RÁPIDO DE UTILIZAÇÃO DO GESTÃO DE FROTA PORTABLE.pdf";
        string pathManual = Environment.CurrentDirectory;
        string pathDestinoManual = string.Empty;       
        string culture = "pt-BR";

        public frmMain()
        {            
            Configuracao config = configuracaoBLL.Get();
            if (config != null)
            {
                culture = config.CultureInfo;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture, true);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture, true);
            }                

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AtualizaTreeView();
            GetAvisos();
                        
            Configuracao config = configuracaoBLL.Get();

            if (config == null)
            {
                this.Visible = false;
                frmSelecionarPais frm = new frmSelecionarPais();
                frm.ShowDialog();               
                this.Visible = true;
                config = configuracaoBLL.Get();
                culture = config.CultureInfo;
            }
        }

        private void linkAddVeiculo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmAddVeiculo frm = new frmAddVeiculo(culture))
            {
                frm.ShowDialog();
            }

            List<VeiculosTreeViewInfo> list = veiculoBLL.GetListTreeView();
            AtualizaTreeView();
            GetAvisos();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var nodeSelecionado = e.Node.Text;
            string[] veiculo = nodeSelecionado.Split('_');
            Veiculo veicu = veiculoBLL.GetPorPlaca(veiculo[0]);
            if (veicu == null)
                MessageBox.Show("Selecione um veículo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {

                switch (culture)
                {
                    case "pt-BR":
                        using (frmVeiculoBRA frmVeicu = new frmVeiculoBRA(veicu))
                        {
                            frmVeicu.ShowDialog();
                        }
                        break;
                    case "pt-PT":
                        using (frmVeiculoPRT frmVeicu = new frmVeiculoPRT(veicu))
                        {
                            frmVeicu.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }

               
                AtualizaTreeView();
            }
        }
              
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmCNHs frmCNH = new frmCNHs())
            {
                frmCNH.ShowDialog();
            }
            GetAvisos();
        }

        private void exportarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Export");
                Export.ExportDB();
                MessageBox.Show($"Exportação realizada com sucesso em {path}", "Exportação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir manutenção: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmAboutBox frmSobre = new frmAboutBox())
            {
                frmSobre.ShowDialog();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmSeguradoras frm = new frmSeguradoras())
            {
                frm.ShowDialog();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goo.gl/forms/AAALQdO85uRI6yQZ2");
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pathDestinoManual = Path.Combine(pathManual, fileNameManual);
                Process.Start(pathDestinoManual);
            }
            catch (Exception)
            {
                MessageBox.Show($"Falha ao localizar manual, ente em contato pelo email ezequielsd@gmail.com e solicite o seu.", "Sem manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Interno

        private void AtualizaTreeView()
        {
            List<VeiculosTreeViewInfo> list = veiculoBLL.GetListTreeView();

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Clear();                
            }

            TreeNode nodePrincipal = new TreeNode("Veiculos");

            //adiciona as listas em nó filhos da principal
            foreach (VeiculosTreeViewInfo item in list)
            {
                nodePrincipal.Nodes.Add(new TreeNode(item.ToString()));
            }

            //adiciona o nó na treeview
            treeView1.Nodes.Add(nodePrincipal);
            //expande todos os nós
            treeView1.ExpandAll();
        }

        private void GetAvisos()
        {
            listBoxAvisos.Items.Clear();

            listBoxAvisos.Items.AddRange(new Avisos().AvisosCNH().ToArray());
            listBoxAvisos.Items.AddRange(new Avisos().AvisoMulta().ToArray());
            listBoxAvisos.Items.AddRange(new Avisos().AvisoDocumento().ToArray());
        }


        #endregion

        
    }
}
