namespace GestaoFrota
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxAvisos = new System.Windows.Forms.ListBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.linkAddVeiculo = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.atualizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.linkLabel4);
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.linkAddVeiculo);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Name = "panel1";
            // 
            // linkLabel4
            // 
            resources.ApplyResources(this.linkLabel4, "linkLabel4");
            this.linkLabel4.Image = global::GestaoFrota.Properties.Resources.if_chat_173174;
            this.linkLabel4.LinkColor = System.Drawing.Color.Red;
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.TabStop = true;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.Image = global::GestaoFrota.Properties.Resources.if_security_1054983;
            this.linkLabel3.LinkColor = System.Drawing.Color.Red;
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.listBoxAvisos);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // listBoxAvisos
            // 
            resources.ApplyResources(this.listBoxAvisos, "listBoxAvisos");
            this.listBoxAvisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAvisos.ForeColor = System.Drawing.Color.Red;
            this.listBoxAvisos.FormattingEnabled = true;
            this.listBoxAvisos.Name = "listBoxAvisos";
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Image = global::GestaoFrota.Properties.Resources.if_paper_document_107198;
            this.linkLabel2.LinkColor = System.Drawing.Color.Red;
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes")))});
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // linkAddVeiculo
            // 
            resources.ApplyResources(this.linkAddVeiculo, "linkAddVeiculo");
            this.linkAddVeiculo.Image = global::GestaoFrota.Properties.Resources.if_flat_style_circle_add_1312548;
            this.linkAddVeiculo.LinkColor = System.Drawing.Color.Green;
            this.linkAddVeiculo.Name = "linkAddVeiculo";
            this.linkAddVeiculo.TabStop = true;
            this.linkAddVeiculo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddVeiculo_LinkClicked);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizaçãoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // atualizaçãoToolStripMenuItem
            // 
            resources.ApplyResources(this.atualizaçãoToolStripMenuItem, "atualizaçãoToolStripMenuItem");
            this.atualizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarDadosToolStripMenuItem,
            this.importarDadosToolStripMenuItem});
            this.atualizaçãoToolStripMenuItem.Name = "atualizaçãoToolStripMenuItem";
            // 
            // exportarDadosToolStripMenuItem
            // 
            resources.ApplyResources(this.exportarDadosToolStripMenuItem, "exportarDadosToolStripMenuItem");
            this.exportarDadosToolStripMenuItem.Name = "exportarDadosToolStripMenuItem";
            this.exportarDadosToolStripMenuItem.Click += new System.EventHandler(this.exportarDadosToolStripMenuItem_Click);
            // 
            // importarDadosToolStripMenuItem
            // 
            resources.ApplyResources(this.importarDadosToolStripMenuItem, "importarDadosToolStripMenuItem");
            this.importarDadosToolStripMenuItem.Name = "importarDadosToolStripMenuItem";
            // 
            // sobreToolStripMenuItem
            // 
            resources.ApplyResources(this.sobreToolStripMenuItem, "sobreToolStripMenuItem");
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conatoToolStripMenuItem,
            this.sobreToolStripMenuItem1,
            this.manualToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            // 
            // conatoToolStripMenuItem
            // 
            resources.ApplyResources(this.conatoToolStripMenuItem, "conatoToolStripMenuItem");
            this.conatoToolStripMenuItem.Name = "conatoToolStripMenuItem";
            // 
            // sobreToolStripMenuItem1
            // 
            resources.ApplyResources(this.sobreToolStripMenuItem1, "sobreToolStripMenuItem1");
            this.sobreToolStripMenuItem1.Name = "sobreToolStripMenuItem1";
            this.sobreToolStripMenuItem1.Click += new System.EventHandler(this.sobreToolStripMenuItem1_Click);
            // 
            // manualToolStripMenuItem
            // 
            resources.ApplyResources(this.manualToolStripMenuItem, "manualToolStripMenuItem");
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkAddVeiculo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem atualizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxAvisos;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel4;
    }
}

