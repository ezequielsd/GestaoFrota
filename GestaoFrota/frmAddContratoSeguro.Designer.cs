namespace GestaoFrota
{
    partial class frmAddContratoSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddContratoSeguro));
            this.cmbSeguradora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerInicioContrato = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFinalContrato = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtNumeroContrato = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnAnexarCartaoSeguro = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.txtPathCartaoSeguro = new System.Windows.Forms.TextBox();
            this.btnAnexarOrcamentoSeguro = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.txtPathOrcamentoSeguro = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cmbSeguradora
            // 
            this.cmbSeguradora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeguradora.FormattingEnabled = true;
            this.cmbSeguradora.Location = new System.Drawing.Point(13, 36);
            this.cmbSeguradora.Name = "cmbSeguradora";
            this.cmbSeguradora.Size = new System.Drawing.Size(492, 21);
            this.cmbSeguradora.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seguradora";
            // 
            // dateTimePickerInicioContrato
            // 
            this.dateTimePickerInicioContrato.Location = new System.Drawing.Point(12, 81);
            this.dateTimePickerInicioContrato.Name = "dateTimePickerInicioContrato";
            this.dateTimePickerInicioContrato.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerInicioContrato.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data inicio contrato";
            // 
            // dateTimePickerFinalContrato
            // 
            this.dateTimePickerFinalContrato.Location = new System.Drawing.Point(271, 81);
            this.dateTimePickerFinalContrato.Name = "dateTimePickerFinalContrato";
            this.dateTimePickerFinalContrato.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerFinalContrato.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data final contrato";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(349, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(430, 215);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 12;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtNumeroContrato
            // 
            this.txtNumeroContrato.Location = new System.Drawing.Point(13, 127);
            this.txtNumeroContrato.Name = "txtNumeroContrato";
            this.txtNumeroContrato.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroContrato.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Numero apólice";
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.ForeColor = System.Drawing.Color.Red;
            this.lblMensagem.Location = new System.Drawing.Point(12, 4);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(35, 13);
            this.lblMensagem.TabIndex = 82;
            this.lblMensagem.Text = "label3";
            // 
            // btnAnexarCartaoSeguro
            // 
            this.btnAnexarCartaoSeguro.Location = new System.Drawing.Point(240, 212);
            this.btnAnexarCartaoSeguro.Name = "btnAnexarCartaoSeguro";
            this.btnAnexarCartaoSeguro.Size = new System.Drawing.Size(34, 23);
            this.btnAnexarCartaoSeguro.TabIndex = 11;
            this.btnAnexarCartaoSeguro.Text = "...";
            this.btnAnexarCartaoSeguro.UseVisualStyleBackColor = true;
            this.btnAnexarCartaoSeguro.Click += new System.EventHandler(this.btnAnexarCartaoSeguro_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(12, 199);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(73, 13);
            this.label52.TabIndex = 88;
            this.label52.Text = "Anexar cartão";
            // 
            // txtPathCartaoSeguro
            // 
            this.txtPathCartaoSeguro.Location = new System.Drawing.Point(12, 215);
            this.txtPathCartaoSeguro.Name = "txtPathCartaoSeguro";
            this.txtPathCartaoSeguro.Size = new System.Drawing.Size(222, 20);
            this.txtPathCartaoSeguro.TabIndex = 10;
            // 
            // btnAnexarOrcamentoSeguro
            // 
            this.btnAnexarOrcamentoSeguro.Location = new System.Drawing.Point(240, 167);
            this.btnAnexarOrcamentoSeguro.Name = "btnAnexarOrcamentoSeguro";
            this.btnAnexarOrcamentoSeguro.Size = new System.Drawing.Size(34, 23);
            this.btnAnexarOrcamentoSeguro.TabIndex = 8;
            this.btnAnexarOrcamentoSeguro.Text = "...";
            this.btnAnexarOrcamentoSeguro.UseVisualStyleBackColor = true;
            this.btnAnexarOrcamentoSeguro.Click += new System.EventHandler(this.btnAnexarOrcamentoSeguro_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(12, 154);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(93, 13);
            this.label51.TabIndex = 85;
            this.label51.Text = "Anexar orcamento";
            // 
            // txtPathOrcamentoSeguro
            // 
            this.txtPathOrcamentoSeguro.Location = new System.Drawing.Point(12, 170);
            this.txtPathOrcamentoSeguro.Name = "txtPathOrcamentoSeguro";
            this.txtPathOrcamentoSeguro.Size = new System.Drawing.Size(222, 20);
            this.txtPathOrcamentoSeguro.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddContratoSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 245);
            this.Controls.Add(this.btnAnexarCartaoSeguro);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.txtPathCartaoSeguro);
            this.Controls.Add(this.btnAnexarOrcamentoSeguro);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtPathOrcamentoSeguro);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumeroContrato);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dateTimePickerFinalContrato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerInicioContrato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSeguradora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddContratoSeguro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Contrator de Seguro";
            this.Load += new System.EventHandler(this.frmAddContratoSeguro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSeguradora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicioContrato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinalContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtNumeroContrato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnAnexarCartaoSeguro;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtPathCartaoSeguro;
        private System.Windows.Forms.Button btnAnexarOrcamentoSeguro;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtPathOrcamentoSeguro;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}