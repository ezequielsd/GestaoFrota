namespace GestaoFrota
{
    partial class frmTipoManutencao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoManutencao));
            this.btnInserir = new System.Windows.Forms.Button();
            this.dtTipoManutencao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtTipoManutencao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.BackColor = System.Drawing.Color.Yellow;
            this.btnInserir.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Location = new System.Drawing.Point(328, 397);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 30;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // dtTipoManutencao
            // 
            this.dtTipoManutencao.AllowUserToAddRows = false;
            this.dtTipoManutencao.AllowUserToDeleteRows = false;
            this.dtTipoManutencao.AllowUserToResizeColumns = false;
            this.dtTipoManutencao.AllowUserToResizeRows = false;
            this.dtTipoManutencao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTipoManutencao.Location = new System.Drawing.Point(8, 12);
            this.dtTipoManutencao.Name = "dtTipoManutencao";
            this.dtTipoManutencao.ReadOnly = true;
            this.dtTipoManutencao.Size = new System.Drawing.Size(395, 379);
            this.dtTipoManutencao.TabIndex = 29;
            // 
            // frmTipoManutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 432);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dtTipoManutencao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoManutencao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Manutenção";
            this.Load += new System.EventHandler(this.frmTipoManutencao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtTipoManutencao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.DataGridView dtTipoManutencao;
    }
}