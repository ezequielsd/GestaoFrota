namespace GestaoFrota
{
    partial class frmCNH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCNH));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFiliacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dateTimePickerNascimento = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerPrimeiraHabilitacao = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerEmissao = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerValidade = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAnexarDocumento = new System.Windows.Forms.Button();
            this.txtAnexarDocumento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnVisualizarDocumento = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(455, 373);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(454, 402);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "Filiação";
            // 
            // txtFiliacao
            // 
            this.txtFiliacao.Location = new System.Drawing.Point(12, 216);
            this.txtFiliacao.Multiline = true;
            this.txtFiliacao.Name = "txtFiliacao";
            this.txtFiliacao.Size = new System.Drawing.Size(234, 59);
            this.txtFiliacao.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Local";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "CPF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Registro";
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(295, 174);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(234, 20);
            this.txtLocal.TabIndex = 10;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(12, 173);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(109, 20);
            this.txtCPF.TabIndex = 4;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(141, 173);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(63, 20);
            this.txtCategoria.TabIndex = 5;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 79);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(234, 20);
            this.txtNome.TabIndex = 2;
            // 
            // txtRegistro
            // 
            this.txtRegistro.Location = new System.Drawing.Point(12, 32);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(234, 20);
            this.txtRegistro.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(373, 431);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(454, 431);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 17;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dateTimePickerNascimento
            // 
            this.dateTimePickerNascimento.Location = new System.Drawing.Point(12, 126);
            this.dateTimePickerNascimento.Name = "dateTimePickerNascimento";
            this.dateTimePickerNascimento.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerNascimento.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "Nascimento";
            // 
            // dateTimePickerPrimeiraHabilitacao
            // 
            this.dateTimePickerPrimeiraHabilitacao.Location = new System.Drawing.Point(295, 32);
            this.dateTimePickerPrimeiraHabilitacao.Name = "dateTimePickerPrimeiraHabilitacao";
            this.dateTimePickerPrimeiraHabilitacao.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerPrimeiraHabilitacao.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 93;
            this.label10.Text = "Primeira habilitação";
            // 
            // dateTimePickerEmissao
            // 
            this.dateTimePickerEmissao.Location = new System.Drawing.Point(295, 80);
            this.dateTimePickerEmissao.Name = "dateTimePickerEmissao";
            this.dateTimePickerEmissao.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerEmissao.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(295, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 95;
            this.label12.Text = "Emissão";
            // 
            // dateTimePickerValidade
            // 
            this.dateTimePickerValidade.Location = new System.Drawing.Point(295, 126);
            this.dateTimePickerValidade.Name = "dateTimePickerValidade";
            this.dateTimePickerValidade.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerValidade.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(295, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 97;
            this.label13.Text = "Validade";
            // 
            // btnAnexarDocumento
            // 
            this.btnAnexarDocumento.Location = new System.Drawing.Point(320, 17);
            this.btnAnexarDocumento.Name = "btnAnexarDocumento";
            this.btnAnexarDocumento.Size = new System.Drawing.Size(34, 23);
            this.btnAnexarDocumento.TabIndex = 14;
            this.btnAnexarDocumento.Text = "...";
            this.btnAnexarDocumento.UseVisualStyleBackColor = true;
            this.btnAnexarDocumento.Click += new System.EventHandler(this.btnAnexarDocumento_Click);
            // 
            // txtAnexarDocumento
            // 
            this.txtAnexarDocumento.Location = new System.Drawing.Point(6, 19);
            this.txtAnexarDocumento.Name = "txtAnexarDocumento";
            this.txtAnexarDocumento.Size = new System.Drawing.Size(308, 20);
            this.txtAnexarDocumento.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVisualizarDocumento);
            this.groupBox1.Controls.Add(this.txtAnexarDocumento);
            this.groupBox1.Controls.Add(this.btnAnexarDocumento);
            this.groupBox1.Location = new System.Drawing.Point(27, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 48);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anexar documento CNH";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnVisualizarDocumento
            // 
            this.btnVisualizarDocumento.BackColor = System.Drawing.Color.Gold;
            this.btnVisualizarDocumento.Location = new System.Drawing.Point(361, 17);
            this.btnVisualizarDocumento.Name = "btnVisualizarDocumento";
            this.btnVisualizarDocumento.Size = new System.Drawing.Size(113, 23);
            this.btnVisualizarDocumento.TabIndex = 15;
            this.btnVisualizarDocumento.Text = "Visualizar Doc.";
            this.btnVisualizarDocumento.UseVisualStyleBackColor = false;
            this.btnVisualizarDocumento.Click += new System.EventHandler(this.btnVisualizarDocumento_Click);
            // 
            // frmCNH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePickerValidade);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dateTimePickerEmissao);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTimePickerPrimeiraHabilitacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePickerNascimento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFiliacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtRegistro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCNH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CNH";
            this.Load += new System.EventHandler(this.frmCNH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFiliacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DateTimePicker dateTimePickerNascimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerPrimeiraHabilitacao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerEmissao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAnexarDocumento;
        private System.Windows.Forms.TextBox txtAnexarDocumento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnVisualizarDocumento;
    }
}