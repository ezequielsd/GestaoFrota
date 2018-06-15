namespace GestaoFrota
{
    partial class frmSeguradoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeguradoras));
            this.dtSeguradoras = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtSeguradoras)).BeginInit();
            this.SuspendLayout();
            // 
            // dtSeguradoras
            // 
            this.dtSeguradoras.AllowUserToAddRows = false;
            this.dtSeguradoras.AllowUserToDeleteRows = false;
            this.dtSeguradoras.AllowUserToResizeColumns = false;
            this.dtSeguradoras.AllowUserToResizeRows = false;
            this.dtSeguradoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtSeguradoras.Location = new System.Drawing.Point(7, 12);
            this.dtSeguradoras.Name = "dtSeguradoras";
            this.dtSeguradoras.ReadOnly = true;
            this.dtSeguradoras.Size = new System.Drawing.Size(804, 379);
            this.dtSeguradoras.TabIndex = 26;
            // 
            // btnInserir
            // 
            this.btnInserir.BackColor = System.Drawing.Color.Yellow;
            this.btnInserir.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Location = new System.Drawing.Point(655, 397);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 29;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVisualizar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Location = new System.Drawing.Point(736, 397);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 28;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // frmSeguradoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 432);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.dtSeguradoras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeguradoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguradoras";
            this.Load += new System.EventHandler(this.frmSeguradoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtSeguradoras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtSeguradoras;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnVisualizar;
    }
}