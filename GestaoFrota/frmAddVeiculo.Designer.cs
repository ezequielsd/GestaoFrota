namespace GestaoFrota
{
    partial class frmAddVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddVeiculo));
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.cmbAnoModelo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(214, 239);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(133, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modelo";
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.BackColor = System.Drawing.Color.White;
            this.cmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Location = new System.Drawing.Point(12, 74);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(277, 21);
            this.cmbFabricante.TabIndex = 2;
            this.cmbFabricante.SelectionChangeCommitted += new System.EventHandler(this.cmbFabricante_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fabricante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Placa";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(12, 210);
            this.txtPlaca.Mask = "AAA-9999";
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(58, 20);
            this.txtPlaca.TabIndex = 5;
            // 
            // cmbModelo
            // 
            this.cmbModelo.BackColor = System.Drawing.Color.White;
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(12, 117);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(277, 21);
            this.cmbModelo.TabIndex = 3;
            this.cmbModelo.SelectionChangeCommitted += new System.EventHandler(this.cmbModelo_SelectionChangeCommitted);
            // 
            // cmbAnoModelo
            // 
            this.cmbAnoModelo.BackColor = System.Drawing.Color.White;
            this.cmbAnoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnoModelo.FormattingEnabled = true;
            this.cmbAnoModelo.Location = new System.Drawing.Point(10, 161);
            this.cmbAnoModelo.Name = "cmbAnoModelo";
            this.cmbAnoModelo.Size = new System.Drawing.Size(277, 21);
            this.cmbAnoModelo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ano modelo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.White;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(11, 30);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(277, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectionChangeCommitted += new System.EventHandler(this.cmbTipo_SelectionChangeCommitted);
            // 
            // frmAddVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 273);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbAnoModelo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFabricante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddVeiculo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Veículo";
            this.Load += new System.EventHandler(this.frmAddVeiculo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFabricante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPlaca;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.ComboBox cmbAnoModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipo;
    }
}