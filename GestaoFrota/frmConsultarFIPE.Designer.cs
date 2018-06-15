namespace GestaoFrota
{
    partial class frmConsultarFIPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarFIPE));
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnConsultarFIPE = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbAnoModelo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox22.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox22
            // 
            this.groupBox22.BackColor = System.Drawing.Color.White;
            this.groupBox22.Controls.Add(this.label1);
            this.groupBox22.Controls.Add(this.cmbTipo);
            this.groupBox22.Controls.Add(this.btnConsultarFIPE);
            this.groupBox22.Controls.Add(this.label19);
            this.groupBox22.Controls.Add(this.label20);
            this.groupBox22.Controls.Add(this.label21);
            this.groupBox22.Controls.Add(this.label22);
            this.groupBox22.Controls.Add(this.label23);
            this.groupBox22.Controls.Add(this.label24);
            this.groupBox22.Controls.Add(this.cmbAnoModelo);
            this.groupBox22.Controls.Add(this.label16);
            this.groupBox22.Controls.Add(this.cmbModelo);
            this.groupBox22.Controls.Add(this.label17);
            this.groupBox22.Controls.Add(this.cmbFabricante);
            this.groupBox22.Controls.Add(this.label18);
            this.groupBox22.Location = new System.Drawing.Point(12, 12);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(552, 224);
            this.groupBox22.TabIndex = 90;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Consultar veículo na FIPE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.White;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(9, 36);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(277, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectionChangeCommitted += new System.EventHandler(this.cmbTipo_SelectionChangeCommitted);
            // 
            // btnConsultarFIPE
            // 
            this.btnConsultarFIPE.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnConsultarFIPE.FlatAppearance.BorderColor = System.Drawing.Color.MediumAquamarine;
            this.btnConsultarFIPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarFIPE.Location = new System.Drawing.Point(211, 192);
            this.btnConsultarFIPE.Name = "btnConsultarFIPE";
            this.btnConsultarFIPE.Size = new System.Drawing.Size(75, 23);
            this.btnConsultarFIPE.TabIndex = 5;
            this.btnConsultarFIPE.Text = "Consultar";
            this.btnConsultarFIPE.UseVisualStyleBackColor = false;
            this.btnConsultarFIPE.Click += new System.EventHandler(this.btnConsultarFIPE_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(295, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Referencia:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(295, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Preço:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(295, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "Combustivel:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(295, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "Ano modelo:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(295, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Veiculo:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(295, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "Marca:";
            // 
            // cmbAnoModelo
            // 
            this.cmbAnoModelo.BackColor = System.Drawing.Color.White;
            this.cmbAnoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnoModelo.FormattingEnabled = true;
            this.cmbAnoModelo.Location = new System.Drawing.Point(9, 163);
            this.cmbAnoModelo.Name = "cmbAnoModelo";
            this.cmbAnoModelo.Size = new System.Drawing.Size(277, 21);
            this.cmbAnoModelo.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Ano modelo";
            // 
            // cmbModelo
            // 
            this.cmbModelo.BackColor = System.Drawing.Color.White;
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(9, 116);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(277, 21);
            this.cmbModelo.TabIndex = 3;
            this.cmbModelo.SelectionChangeCommitted += new System.EventHandler(this.cmbModelo_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Marca";
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.BackColor = System.Drawing.Color.White;
            this.cmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Location = new System.Drawing.Point(9, 76);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(277, 21);
            this.cmbFabricante.TabIndex = 2;
            this.cmbFabricante.SelectionChangeCommitted += new System.EventHandler(this.cmbFabricante_SelectionChangeCommitted);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Modelo";
            // 
            // frmConsultarFIPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 248);
            this.Controls.Add(this.groupBox22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarFIPE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar na FIPE";
            this.Load += new System.EventHandler(this.frmConsultarFIPE_Load);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Button btnConsultarFIPE;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbAnoModelo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbFabricante;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipo;
    }
}