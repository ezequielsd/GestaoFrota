namespace GestaoFrota
{
    partial class frmAdicionarComprovante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionarComprovante));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAnexarComprovante = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.txtPathComprovanteAbastecimento = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(227, 70);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(308, 70);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAnexarComprovante
            // 
            this.btnAnexarComprovante.Location = new System.Drawing.Point(349, 41);
            this.btnAnexarComprovante.Name = "btnAnexarComprovante";
            this.btnAnexarComprovante.Size = new System.Drawing.Size(34, 23);
            this.btnAnexarComprovante.TabIndex = 26;
            this.btnAnexarComprovante.Text = "...";
            this.btnAnexarComprovante.UseVisualStyleBackColor = true;
            this.btnAnexarComprovante.Click += new System.EventHandler(this.btnAnexarComprovante_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(12, 27);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(105, 13);
            this.label37.TabIndex = 27;
            this.label37.Text = "Anexar comprovante";
            // 
            // txtPathComprovanteAbastecimento
            // 
            this.txtPathComprovanteAbastecimento.Location = new System.Drawing.Point(12, 43);
            this.txtPathComprovanteAbastecimento.Name = "txtPathComprovanteAbastecimento";
            this.txtPathComprovanteAbastecimento.Size = new System.Drawing.Size(331, 20);
            this.txtPathComprovanteAbastecimento.TabIndex = 25;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAdicionarComprovante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 109);
            this.Controls.Add(this.btnAnexarComprovante);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtPathComprovanteAbastecimento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdicionarComprovante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar comprovante";
            this.Load += new System.EventHandler(this.frmAdicionarComprovante_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAnexarComprovante;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtPathComprovanteAbastecimento;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}